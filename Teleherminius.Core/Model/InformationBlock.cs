using Teleherminius.Core.Model.Value;

namespace Teleherminius.Core.Model;

public class InformationBlock
{
    public int? Id { get; set; }
    public Information? Information { get; set; }
    public DateTime? CreationTime { get; set; }
}