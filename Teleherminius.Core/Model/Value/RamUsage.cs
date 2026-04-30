namespace Teleherminius.Core.Model.Value;

/// <summary>
/// Represents percent of used RAM.
/// </summary>
public sealed class RamUsage
{
    public long PhysicalTotal { get; set; }
    public long PhysicalAvailable { get; set; }
    public long PhysicalOccupied => PhysicalTotal - PhysicalAvailable;

    public long VirtualTotal { get; set; }
    public long VirtualAvailable { get; set; }
    public long VirtualOccupied => VirtualTotal - VirtualAvailable;

    public long OverallTotal => PhysicalTotal + VirtualTotal;
    public long OverallAvailable => PhysicalAvailable + VirtualAvailable;
    public long OverallOccupied => PhysicalOccupied + VirtualOccupied;

    public RamUsage(ulong physicalTotal, ulong physicalAvailable, ulong virtualTotal, ulong virtualAvailable)
    {
        PhysicalTotal = (long)physicalTotal;
        PhysicalAvailable = (long)physicalAvailable;
        VirtualTotal = (long)virtualTotal;
        VirtualAvailable = (long)virtualAvailable;
    }
}