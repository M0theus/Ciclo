using CycleTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CycleTracker.Infra.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(c => c.Id)
            .IsRequired();
        
        builder
            .Property(c => c.Nome)
            .HasMaxLength(250)
            .IsRequired();

        builder
            .Property(c => c.Email)
            .HasMaxLength(250)
            .IsRequired();

        builder
            .Property(c => c.Senha)
            .IsRequired();

        builder
            .Property(c => c.Apelido)
            .HasMaxLength(250)
            .IsRequired(false);
    }
}