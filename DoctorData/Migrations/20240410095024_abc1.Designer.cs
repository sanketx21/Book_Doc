﻿using Hospital.Models;
using Hospital.HospitalData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240410095024_abc1")]
    partial class abc1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Docinfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "test1",
                            Specialisation = "neuro"
                        },
                        new
                        {
                            Id = 2,
                            Name = "test2",
                            Specialisation = "ortho"
                        },
                        new
                        {
                            Id = 3,
                            Name = "test3",
                            Specialisation = "surgeon"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}