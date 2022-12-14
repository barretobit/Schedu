// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Schedu.Models;

#nullable disable

namespace Schedu.Migrations
{
    [DbContext(typeof(ScheduDbContext))]
    [Migration("20221005213259_ScheduContext")]
    partial class ScheduContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Schedu.Models.Business", b =>
                {
                    b.Property<int>("BusinessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusinessId"), 1L, 1);

                    b.Property<string>("BusinessEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("BusinessOwnerId")
                        .HasColumnType("int");

                    b.Property<int>("BusinessPhone")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegistryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BusinessId");

                    b.HasIndex("BusinessOwnerId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("Schedu.Models.BusinessOwner", b =>
                {
                    b.Property<int>("BusinessOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusinessOwnerId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("OwnerPhone")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BusinessOwnerId");

                    b.ToTable("BusinessesOwners");
                });

            modelBuilder.Entity("Schedu.Models.Business", b =>
                {
                    b.HasOne("Schedu.Models.BusinessOwner", "BusinessOwner")
                        .WithMany()
                        .HasForeignKey("BusinessOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessOwner");
                });
#pragma warning restore 612, 618
        }
    }
}
