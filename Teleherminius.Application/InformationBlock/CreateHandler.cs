using MediatR;
using Teleherminius.Core.Dto;
using Teleherminius.Core.Repository;

namespace Teleherminius.Application.InformationBlock;

public class CreateHandler : IRequestHandler<CreateCommand>
{
    private readonly IInformationBlockRepository _repository;

    public CreateHandler(IInformationBlockRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        var cpuUsage = command.Information.CpuUsage;
        var ramUsage = command.Information.RamUsage;
        
        InformationBlockDto dto = new InformationBlockDto
        {
            CpuUsage_Name = cpuUsage.Name,
            CpuUsage_AverageProcessorTime = cpuUsage.AverageProcessorTime,
            RamUsage_PhysicalTotal =  ramUsage.PhysicalTotal,
            RamUsage_PhysicalAvailable =  ramUsage.PhysicalAvailable,
            RamUsage_VirtualTotal = ramUsage.VirtualTotal,
            RamUsage_VirtualAvailable = ramUsage.VirtualAvailable,
            CreationTime = DateTime.UtcNow
        };

        await _repository.CreateAsync(dto, cancellationToken);
    }
}