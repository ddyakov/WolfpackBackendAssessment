﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WolfpackBackendAssessment.Infrastructure.Persistance;

namespace WolfpackBackendAssessment.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(WolfPackDbContext))]
    partial class WolfPackDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WolfpackBackendAssessment.Domain.Models.Packs.Pack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Packs");
                });

            modelBuilder.Entity("WolfpackBackendAssessment.Domain.Models.Wolves.Wolf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("PackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PackId");

                    b.ToTable("Wolves");
                });

            modelBuilder.Entity("WolfpackBackendAssessment.Domain.Models.Wolves.Wolf", b =>
                {
                    b.HasOne("WolfpackBackendAssessment.Domain.Models.Packs.Pack", null)
                        .WithMany("Wolves")
                        .HasForeignKey("PackId");

                    b.OwnsOne("WolfpackBackendAssessment.Domain.Models.Wolves.Gender", "Gender", b1 =>
                        {
                            b1.Property<int>("WolfId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("WolfId");

                            b1.ToTable("Wolves");

                            b1.WithOwner()
                                .HasForeignKey("WolfId");
                        });

                    b.OwnsOne("WolfpackBackendAssessment.Domain.Models.Wolves.Location", "Location", b1 =>
                        {
                            b1.Property<int>("WolfId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Latitude")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Longitude")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("WolfId");

                            b1.ToTable("Wolves");

                            b1.WithOwner()
                                .HasForeignKey("WolfId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}