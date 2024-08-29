using CycleTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleTracker.Infra.Mappings;

public class RelacionamentoSexualMapping : IEntityTypeConfiguration<RelacionamentoSexual>
{
    public void Configure(EntityTypeBuilder<RelacionamentoSexual> builder)
    {
        builder
            .Property(c => c.Id)
            .IsRequired();

        builder
            .Property(c => c.Data)
            .IsRequired();
    }
}