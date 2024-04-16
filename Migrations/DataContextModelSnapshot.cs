﻿// <auto-generated />
using System;
using CoffePartners.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeePartners.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoffePartners.Models.Cultivation", b =>
                {
                    b.Property<int>("IdCultivation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCultivation"));

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<DateTime>("DateCultivation")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdFarm1")
                        .HasColumnType("int");

                    b.Property<int>("IdStateCultivation1")
                        .HasColumnType("int");

                    b.HasKey("IdCultivation");

                    b.HasIndex("IdFarm1");

                    b.HasIndex("IdStateCultivation1");

                    b.ToTable("Cultivations");
                });

            modelBuilder.Entity("CoffePartners.Models.CultivationHarvest", b =>
                {
                    b.Property<int>("IdCultivationHarvest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCultivationHarvest"));

                    b.Property<int>("IdCultivation1")
                        .HasColumnType("int");

                    b.Property<int>("IdHarvest1")
                        .HasColumnType("int");

                    b.Property<float>("WeightHarvest")
                        .HasColumnType("real");

                    b.HasKey("IdCultivationHarvest");

                    b.HasIndex("IdCultivation1");

                    b.HasIndex("IdHarvest1");

                    b.ToTable("CultivationHarvests");
                });

            modelBuilder.Entity("CoffePartners.Models.Farm", b =>
                {
                    b.Property<int>("IdFarm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFarm"));

                    b.Property<int>("IdPlayer1")
                        .HasColumnType("int");

                    b.Property<string>("NameFarm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SizeFarm")
                        .HasColumnType("real");

                    b.HasKey("IdFarm");

                    b.HasIndex("IdPlayer1");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("CoffePartners.Models.Harvest", b =>
                {
                    b.Property<int>("IdHarvest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHarvest"));

                    b.Property<DateTime>("DateHarvest")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTypeQuality1")
                        .HasColumnType("int");

                    b.HasKey("IdHarvest");

                    b.HasIndex("IdTypeQuality1");

                    b.ToTable("Harvests");
                });

            modelBuilder.Entity("CoffePartners.Models.HarvestProcess", b =>
                {
                    b.Property<int>("IdHarvestProcess")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHarvestProcess"));

                    b.Property<float>("HeightWastedGrain")
                        .HasColumnType("real");

                    b.Property<int>("IdCultivationHarvest1")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeProcess1")
                        .HasColumnType("int");

                    b.HasKey("IdHarvestProcess");

                    b.HasIndex("IdCultivationHarvest1");

                    b.HasIndex("IdTypeProcess1");

                    b.ToTable("HarvestProcesss");
                });

            modelBuilder.Entity("CoffePartners.Models.Level", b =>
                {
                    b.Property<int>("IdLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLevel"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.HasKey("IdLevel");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("CoffePartners.Models.Machinery", b =>
                {
                    b.Property<int>("IdMachinery")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMachinery"));

                    b.Property<string>("DescriptionMachine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameMachine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PriceMachine")
                        .HasColumnType("real");

                    b.HasKey("IdMachinery");

                    b.ToTable("Machinerys");
                });

            modelBuilder.Entity("CoffePartners.Models.Player", b =>
                {
                    b.Property<int>("IdPlayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlayer"));

                    b.Property<string>("EmailPlayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NicknamePlayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordPlayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPlayer");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CoffePartners.Models.Score", b =>
                {
                    b.Property<int>("IdScore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdScore"));

                    b.Property<int>("IdFarm1")
                        .HasColumnType("int");

                    b.Property<int>("IdLevel1")
                        .HasColumnType("int");

                    b.Property<float>("Points")
                        .HasColumnType("real");

                    b.HasKey("IdScore");

                    b.HasIndex("IdFarm1");

                    b.HasIndex("IdLevel1");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("CoffePartners.Models.StatesCultivation", b =>
                {
                    b.Property<int>("IdStateCultivation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStateCultivation"));

                    b.Property<string>("NameStateCultivation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStateCultivation");

                    b.ToTable("StatesCultivations");
                });

            modelBuilder.Entity("CoffePartners.Models.TypeProcess", b =>
                {
                    b.Property<int>("IdTypeProcess")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypeProcess"));

                    b.Property<string>("DescriptionProcess")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdMachinery1")
                        .HasColumnType("int");

                    b.Property<string>("NameProcess")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTypeProcess");

                    b.HasIndex("IdMachinery1");

                    b.ToTable("TypeProcesss");
                });

            modelBuilder.Entity("CoffePartners.Models.TypeQuality", b =>
                {
                    b.Property<int>("IdTypeQuality")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypeQuality"));

                    b.Property<string>("NameQuality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PriceByGr")
                        .HasColumnType("real");

                    b.HasKey("IdTypeQuality");

                    b.ToTable("TypeQualitys");
                });

            modelBuilder.Entity("CoffePartners.Models.Cultivation", b =>
                {
                    b.HasOne("CoffePartners.Models.Farm", "IdFarm")
                        .WithMany()
                        .HasForeignKey("IdFarm1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffePartners.Models.StatesCultivation", "IdStateCultivation")
                        .WithMany("Cultivation")
                        .HasForeignKey("IdStateCultivation1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdFarm");

                    b.Navigation("IdStateCultivation");
                });

            modelBuilder.Entity("CoffePartners.Models.CultivationHarvest", b =>
                {
                    b.HasOne("CoffePartners.Models.Cultivation", "IdCultivation")
                        .WithMany()
                        .HasForeignKey("IdCultivation1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffePartners.Models.Harvest", "IdHarvest")
                        .WithMany()
                        .HasForeignKey("IdHarvest1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCultivation");

                    b.Navigation("IdHarvest");
                });

            modelBuilder.Entity("CoffePartners.Models.Farm", b =>
                {
                    b.HasOne("CoffePartners.Models.Player", "IdPlayer")
                        .WithMany("Farms")
                        .HasForeignKey("IdPlayer1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdPlayer");
                });

            modelBuilder.Entity("CoffePartners.Models.Harvest", b =>
                {
                    b.HasOne("CoffePartners.Models.TypeQuality", "IdTypeQuality")
                        .WithMany("Harvest")
                        .HasForeignKey("IdTypeQuality1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdTypeQuality");
                });

            modelBuilder.Entity("CoffePartners.Models.HarvestProcess", b =>
                {
                    b.HasOne("CoffePartners.Models.CultivationHarvest", "IdCultivationHarvest")
                        .WithMany("HarvestProcesses")
                        .HasForeignKey("IdCultivationHarvest1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffePartners.Models.TypeProcess", "IdTypeProcess")
                        .WithMany("HarvestProcesses")
                        .HasForeignKey("IdTypeProcess1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCultivationHarvest");

                    b.Navigation("IdTypeProcess");
                });

            modelBuilder.Entity("CoffePartners.Models.Score", b =>
                {
                    b.HasOne("CoffePartners.Models.Farm", "IdFarm")
                        .WithMany("Scores")
                        .HasForeignKey("IdFarm1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffePartners.Models.Level", "IdLevel")
                        .WithMany("Scores")
                        .HasForeignKey("IdLevel1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdFarm");

                    b.Navigation("IdLevel");
                });

            modelBuilder.Entity("CoffePartners.Models.TypeProcess", b =>
                {
                    b.HasOne("CoffePartners.Models.Machinery", "IdMachinery")
                        .WithMany("TypeProcesses")
                        .HasForeignKey("IdMachinery1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdMachinery");
                });

            modelBuilder.Entity("CoffePartners.Models.CultivationHarvest", b =>
                {
                    b.Navigation("HarvestProcesses");
                });

            modelBuilder.Entity("CoffePartners.Models.Farm", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("CoffePartners.Models.Level", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("CoffePartners.Models.Machinery", b =>
                {
                    b.Navigation("TypeProcesses");
                });

            modelBuilder.Entity("CoffePartners.Models.Player", b =>
                {
                    b.Navigation("Farms");
                });

            modelBuilder.Entity("CoffePartners.Models.StatesCultivation", b =>
                {
                    b.Navigation("Cultivation");
                });

            modelBuilder.Entity("CoffePartners.Models.TypeProcess", b =>
                {
                    b.Navigation("HarvestProcesses");
                });

            modelBuilder.Entity("CoffePartners.Models.TypeQuality", b =>
                {
                    b.Navigation("Harvest");
                });
#pragma warning restore 612, 618
        }
    }
}
