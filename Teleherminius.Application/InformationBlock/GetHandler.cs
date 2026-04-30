using MediatR;
using Teleherminius.Core.Dto;
using Teleherminius.Core.Repository;

namespace Teleherminius.Application.InformationBlock;

public class GetHandler : IRequestHandler<GetCommand, InformationBlockDto>
{
    private readonly IInformationBlockRepository _repository;

    public GetHandler(IInformationBlockRepository repository)
    {
        _repository = repository;
    }

    public async Task<InformationBlockDto> Handle(GetCommand command, CancellationToken cancellationToken) =>
        await _repository.GetAsync(command.Id, cancellationToken);
}