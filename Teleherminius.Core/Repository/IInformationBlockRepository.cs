using Teleherminius.Core.Dto;

namespace Teleherminius.Core.Repository;

public interface IInformationBlockRepository
{
    public Task CreateAsync(InformationBlockDto informationBlock, CancellationToken cancellationToken = default);
    public Task<InformationBlockDto> GetAsync(int id, CancellationToken cancellationToken = default);
}