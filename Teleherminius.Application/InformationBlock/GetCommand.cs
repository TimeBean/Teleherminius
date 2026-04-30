using MediatR;
using Teleherminius.Core.Dto;

namespace Teleherminius.Application.InformationBlock;

public record GetCommand(int Id) : IRequest<InformationBlockDto>;