﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnologiesOnPlatformNET.Infrastructure.Context;

#nullable disable

namespace TechnologiesOnPlatformNET.Infrastructure.Migrations
{
    [DbContext(typeof(TechnologiesDbContext))]
    [Migration("20250517171324_AddIsCloudReadyToAspNetCore")]
    partial class AddIsCloudReadyToAspNetCore
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("TechnologiesOnPlatformNET.Infrastructure.Models.AspNetCoreModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("SupportsMinimalAPI")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WebTechnologyId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WebTechnologyId")
                        .IsUnique();

                    b.ToTable("AspNetCores");
                });

            modelBuilder.Entity("TechnologiesOnPlatformNET.Infrastructure.Models.DotNetTechnologyModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DotNetTechnologies");
                });

            modelBuilder.Entity("TechnologiesOnPlatformNET.Infrastructure.Models.WebTechnologyModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DotNetTechnologyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("FrontendFramework")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCloudReady")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DotNetTechnologyId")
                        .IsUnique();

                    b.ToTable("WebTechnologies");
                });

            modelBuilder.Entity("TechnologiesOnPlatformNET.Infrastructure.Models.AspNetCoreModel", b =>
                {
                    b.HasOne("TechnologiesOnPlatformNET.Infrastructure.Models.WebTechnologyModel", "WebTechnology")
                        .WithOne("AspNetCore")
                        .HasForeignKey("TechnologiesOnPlatformNET.Infrastructure.Models.AspNetCoreModel", "WebTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WebTechnology");
                });

            modelBuilder.Entity("TechnologiesOnPlatformNET.Infrastructure.Models.WebTechnologyModel", b =>
                {
                    b.HasOne("TechnologiesOnPlatformNET.Infrastructure.Models.DotNetTechnologyModel", "DotNetTechnology")
                        .WithOne("WebTechnology")
                        .HasForeignKey("TechnologiesOnPlatformNET.Infrastructure.Models.WebTechnologyModel", "DotNetTechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DotNetTechnology");
                });

            modelBuilder.Entity("TechnologiesOnPlatformNET.Infrastructure.Models.DotNetTechnologyModel", b =>
                {
                    b.Navigation("WebTechnology")
                        .IsRequired();
                });

            modelBuilder.Entity("TechnologiesOnPlatformNET.Infrastructure.Models.WebTechnologyModel", b =>
                {
                    b.Navigation("AspNetCore")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
