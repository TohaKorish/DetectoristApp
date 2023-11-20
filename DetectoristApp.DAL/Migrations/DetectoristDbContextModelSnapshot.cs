﻿// <auto-generated />
using DetectoristApp.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DetectoristApp.DAL.Migrations
{
    [DbContext(typeof(DetectoristDbContext))]
    partial class DetectoristDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DetectoristApp.DAL.Entities.Coil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Diameter")
                        .HasColumnType("double");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Coils");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Nel",
                            Diameter = 6.5,
                            Model = "Tornado"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Minelab",
                            Diameter = 11.0,
                            Model = "EQX 15 Double-D"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Deus",
                            Diameter = 9.0,
                            Model = "9'' FMF"
                        });
                });

            modelBuilder.Entity("DetectoristApp.DAL.Entities.Detectorist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("MetaldetectorId")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MetaldetectorId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Detectorists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 25,
                            MetaldetectorId = 1,
                            Sex = "Male",
                            Username = "Kola1"
                        },
                        new
                        {
                            Id = 2,
                            Age = 30,
                            MetaldetectorId = 2,
                            Sex = "Female",
                            Username = "Kola2"
                        },
                        new
                        {
                            Id = 3,
                            Age = 40,
                            MetaldetectorId = 3,
                            Sex = "Male",
                            Username = "Halk"
                        });
                });

            modelBuilder.Entity("DetectoristApp.DAL.Entities.Metaldetector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CoilId")
                        .HasColumnType("int");

                    b.Property<bool>("IsWaterproof")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CoilId");

                    b.ToTable("Metaldetectors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Garrett",
                            CoilId = 1,
                            IsWaterproof = false,
                            Model = "Ace 250",
                            Weight = 2.7000000000000002
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Minelab",
                            CoilId = 2,
                            IsWaterproof = true,
                            Model = "Equinox 800",
                            Weight = 2.96
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Deus",
                            CoilId = 3,
                            IsWaterproof = false,
                            Model = "2",
                            Weight = 2.2999999999999998
                        });
                });

            modelBuilder.Entity("DetectoristApp.DAL.Entities.Detectorist", b =>
                {
                    b.HasOne("DetectoristApp.DAL.Entities.Metaldetector", "Metaldetector")
                        .WithMany("Detectorists")
                        .HasForeignKey("MetaldetectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Metaldetector");
                });

            modelBuilder.Entity("DetectoristApp.DAL.Entities.Metaldetector", b =>
                {
                    b.HasOne("DetectoristApp.DAL.Entities.Coil", "Coil")
                        .WithMany("Metaldetectors")
                        .HasForeignKey("CoilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Coil");
                });

            modelBuilder.Entity("DetectoristApp.DAL.Entities.Coil", b =>
                {
                    b.Navigation("Metaldetectors");
                });

            modelBuilder.Entity("DetectoristApp.DAL.Entities.Metaldetector", b =>
                {
                    b.Navigation("Detectorists");
                });
#pragma warning restore 612, 618
        }
    }
}
