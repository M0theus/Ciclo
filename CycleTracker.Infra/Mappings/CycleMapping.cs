using CycleTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleTracker.Infra.Mappings;

public class CycleMapping : IEntityTypeConfiguration<Cycle>
{
    public void Configure(EntityTypeBuilder<Cycle> builder)
    {
        builder
            .Property(c => c.Id)
            .IsRequired();

        builder
            .Property(c => c.DataInicio)
            .IsRequired();

        builder
            .Property(c => c.DuracaoCiclo)
            .IsRequired();

        builder
            .Property(c => c.DuracaoMenstrual)
            .IsRequired();

        builder
            .Property(c => c.DataInicioUltimoCiclo)
            .IsRequired();

        builder
            .HasMany(c => c.RelacionamentoSexuals)
            .WithOne(c => c.Cicly)
            .HasForeignKey(c => c.CicloId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(c => c.User)
            .WithOne(c => c.Ciclo)
            .OnDelete(DeleteBehavior.Restrict);
    }
}