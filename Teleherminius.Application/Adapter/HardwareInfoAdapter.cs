using Hardware.Info;
using Teleherminius.Core.Adapter;
using Teleherminius.Core.Model;
using Teleherminius.Core.Model.Value;

namespace Teleherminius.Application.Adapter;

public class HardwareInfoAdapter : IHardwareInformationAdapter
{
    private readonly HardwareInfo _hardwareInfo;

    public HardwareInfoAdapter(HardwareInfo hardwareInfo)
    {
        _hardwareInfo = hardwareInfo;
    }

    public Information Get()
    {
        var information = new Information()
        {
            CpuUsage = GetCpuUsage(),
            RamUsage = GetRamUsage()
        };

        return information;
    }

    private CpuUsage GetCpuUsage()
    {
        _hardwareInfo.RefreshCPUList();
        var firstCpu = _hardwareInfo.CpuList[0];

        var cores = firstCpu.CpuCoreList;
        var coresProcessTime = new ulong[cores.Count];
        for (var i = 0; i < cores.Count; i++)
        {
            coresProcessTime[i] = cores[i].PercentProcessorTime;
        }

        var cpuUsage = new CpuUsage(firstCpu.Name, coresProcessTime);
        return cpuUsage;
    }

    private RamUsage GetRamUsage()
    {
        _hardwareInfo.RefreshMemoryStatus();

        var totalPhysical = _hardwareInfo.MemoryStatus.TotalPhysical;
        var availablePhysical = _hardwareInfo.MemoryStatus.AvailablePhysical;
        var totalVirtual = _hardwareInfo.MemoryStatus.TotalVirtual;
        var availableVirtual = _hardwareInfo.MemoryStatus.AvailableVirtual;

        var ramUsage = new RamUsage(totalPhysical, availablePhysical, totalVirtual, availableVirtual);
        return ramUsage;
    }
}