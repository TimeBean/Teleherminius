using Teleherminius.Core.Model.Value;

namespace Teleherminius.Core.Model;

public sealed class Information
{
    public CpuUsage? CpuUsage { get; set; }
    public RamUsage? RamUsage { get; set; }
}