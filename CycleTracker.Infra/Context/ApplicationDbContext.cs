using System.ComponentModel.DataAnnotations;
using System.Reflection;
using CycleTracker.Domain.Contracts;
using CycleTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CycleTracker.Infra.Context;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        ApplyConfiguration(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Cycle> Cycles { get; set; } = null!;
    public DbSet<RelacionamentoSexual> RelacionamentoSexuals { get; set; } = null!;
    
    private static void ApplyConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
    }

    public async Task<bool> Commit() => await SaveChangesAsync() > 0;
}