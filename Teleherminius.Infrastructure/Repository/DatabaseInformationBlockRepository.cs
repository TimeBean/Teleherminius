using Microsoft.EntityFrameworkCore;
using Teleherminius.Core.Dto;
using Teleherminius.Core.Repository;

namespace Teleherminius.Infrastructure.Repository;

public class DatabaseInformationBlockRepository : IInformationBlockRepository
{
    private readonly AppDbContext _context;

    public DatabaseInformationBlockRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(InformationBlockDto informationBlock, CancellationToken cancellationToken = default)
    {
        var entity = new InformationBlockDto()
        {
            Id = informationBlock.Id,
            CpuUsage_Name = informationBlock.CpuUsage_Name,
            CpuUsage_AverageProcessorTime = informationBlock.CpuUsage_AverageProcessorTime,
            RamUsage_PhysicalTotal = informationBlock.RamUsage_PhysicalTotal,
            RamUsage_PhysicalAvailable = informationBlock.RamUsage_PhysicalAvailable,
            RamUsage_VirtualTotal = informationBlock.RamUsage_VirtualTotal,
            RamUsage_VirtualAvailable = informationBlock.RamUsage_VirtualAvailable,
            CreationTime = informationBlock.CreationTime,
        };

        await _context.InformationBlocks.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<InformationBlockDto> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.InformationBlocks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new KeyNotFoundException($"InformationBlock with Id={id} not found.");
        }

        return entity;
    }
}