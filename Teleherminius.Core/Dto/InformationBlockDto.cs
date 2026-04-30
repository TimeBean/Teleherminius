using System.Diagnostics.CodeAnalysis;

namespace Teleherminius.Core.Dto;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class InformationBlockDto
{
    public int? Id { get; set; }
    public string CpuUsage_Name { get; set; }
    public double CpuUsage_AverageProcessorTime { get; set; }
    public long RamUsage_PhysicalTotal { get; set; }
    public long RamUsage_PhysicalAvailable { get; set; }
    public long RamUsage_VirtualTotal { get; set; }
    public long RamUsage_VirtualAvailable { get; set; }
    public DateTime? CreationTime { get; set; }
}