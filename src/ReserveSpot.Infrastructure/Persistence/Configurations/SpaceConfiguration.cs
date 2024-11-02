using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReserveSpot.Domain.Models.Spaces;

namespace ReserveSpot.Infrastructure.Persistence.Configurations;

internal sealed class SpaceConfiguration : IEntityTypeConfiguration<Space>
{
    public void Configure(EntityTypeBuilder<Space> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.IsAvailable).IsRequired();
    
    }
}
