﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test_webapi.Data;

#nullable disable

namespace test_webapi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250309092954_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Summary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Summaries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Freezing"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Bracing"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Chilly"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Cool"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Mild"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Warm"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Balmy"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Hot"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Sweltering"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Scorching"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
