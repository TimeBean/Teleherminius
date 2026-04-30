namespace Teleherminius.Core.Model.Value;

/// <summary>
/// Represents CPU usage statistics for a system or process.
/// </summary>
public class CpuUsage
{
    /// <summary>
    /// Identifier for the CPU source.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Average CPU usage across all cores (0–100).
    /// </summary>
    public double AverageProcessorTime =>
        _perCoreUsage.Count == 0 ? 0 : _perCoreUsage.Average();

    private readonly List<double> _perCoreUsage;

    /// <summary>
    /// Creates a CPU usage snapshot from per-core values.
    /// </summary>
    public CpuUsage(string name, params ulong[] perCoreUsage)
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException("Name cannot be null or empty.", nameof(name))
            : name;

        _perCoreUsage = perCoreUsage?.Select(ConvertAndValidate).ToList() ?? [];
    }

    private static double ConvertAndValidate(ulong value)
    {
        if (value > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(value),
                "CPU usage must be between 0 and 100.");
        }

        return value;
    }
}