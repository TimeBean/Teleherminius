using MediatR;

namespace Teleherminius.Application.InformationBlock;

public record CreateCommand(Core.Model.Information Information) : IRequest;