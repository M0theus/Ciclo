﻿// <auto-generated />
using System;
using CycleTracker.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CycleTracker.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CycleTracker.Domain.Entity.Cycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataInicio")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInicioUltimoCiclo")
                        .HasColumnType("date");

                    b.Property<int>("DuracaoCiclo")
                        .HasColumnType("int");

                    b.Property<int>("DuracaoMenstrual")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cycles");
                });

            modelBuilder.Entity("CycleTracker.Domain.Entity.RelacionamentoSexual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CicloId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CicloId");

                    b.ToTable("RelacionamentoSexuals");
                });

            modelBuilder.Entity("CycleTracker.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CycleTracker.Domain.Entity.Cycle", b =>
                {
                    b.HasOne("CycleTracker.Domain.Entity.User", "User")
                        .WithOne("Ciclo")
                        .HasForeignKey("CycleTracker.Domain.Entity.Cycle", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CycleTracker.Domain.Entity.RelacionamentoSexual", b =>
                {
                    b.HasOne("CycleTracker.Domain.Entity.Cycle", "Cicly")
                        .WithMany("RelacionamentoSexuals")
                        .HasForeignKey("CicloId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cicly");
                });

            modelBuilder.Entity("CycleTracker.Domain.Entity.Cycle", b =>
                {
                    b.Navigation("RelacionamentoSexuals");
                });

            modelBuilder.Entity("CycleTracker.Domain.Entity.User", b =>
                {
                    b.Navigation("Ciclo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
