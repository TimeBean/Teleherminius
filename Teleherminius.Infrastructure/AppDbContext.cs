using Microsoft.EntityFrameworkCore;
using Teleherminius.Core.Dto;

namespace Teleherminius.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<InformationBlockDto> InformationBlocks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}