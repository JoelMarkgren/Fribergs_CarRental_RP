﻿// <auto-generated />
using Fribergs_CarRental_RP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fribergs_CarRental_RP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240127074507_hehe")]
    partial class hehe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fribergs_CarRental_RP.Data.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Fribergs_CarRental_RP.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Fribergs_CarRental_RP.Data.Admin", b =>
                {
                    b.HasBaseType("Fribergs_CarRental_RP.Data.User");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("Fribergs_CarRental_RP.Data.Customer", b =>
                {
                    b.HasBaseType("Fribergs_CarRental_RP.Data.User");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Fribergs_CarRental_RP.Data.Admin", b =>
                {
                    b.HasOne("Fribergs_CarRental_RP.Data.User", null)
                        .WithOne()
                        .HasForeignKey("Fribergs_CarRental_RP.Data.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fribergs_CarRental_RP.Data.Customer", b =>
                {
                    b.HasOne("Fribergs_CarRental_RP.Data.User", null)
                        .WithOne()
                        .HasForeignKey("Fribergs_CarRental_RP.Data.Customer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
