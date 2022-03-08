﻿// <auto-generated />
using System;
using Api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220308181527_add-ApiKey-to-Company-model")]
    partial class addApiKeytoCompanymodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api.Entities.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CreatedByApiKey")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedApiKey")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            City = "Los Angeles",
                            Country = "USA",
                            CreatedByApiKey = "a2229196-5eb8-4a14-a234-b5451df0a08b",
                            CreatedDate = new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47),
                            IsDeleted = false,
                            LastModifiedApiKey = "a2229196-5eb8-4a14-a234-b5451df0a08b",
                            LastModifiedDate = new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47),
                            Name = "IT_Solutions Ltd",
                            Phone = "800-123-4567",
                            State = "CA",
                            ZipCode = "90001"
                        },
                        new
                        {
                            Id = 2,
                            Address = "312 Forest Avenue, BF 923",
                            City = "New York",
                            Country = "USA",
                            CreatedByApiKey = "a2229196-5eb8-4a14-a234-b5451df0a08b",
                            CreatedDate = new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47),
                            IsDeleted = false,
                            LastModifiedApiKey = "a2229196-5eb8-4a14-a234-b5451df0a08b",
                            LastModifiedDate = new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47),
                            Name = "Admin_Solutions Ltd",
                            Phone = "888-123-4567",
                            State = "NY",
                            ZipCode = "10001"
                        },
                        new
                        {
                            Id = 3,
                            Address = "10000 North Loop East",
                            City = "Houston",
                            Country = "USA",
                            CreatedByApiKey = "a2229196-5eb8-4a14-a234-b5451df0a08b",
                            CreatedDate = new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47),
                            IsDeleted = false,
                            LastModifiedApiKey = "a2229196-5eb8-4a14-a234-b5451df0a08b",
                            LastModifiedDate = new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47),
                            Name = "New Generation Electronics",
                            Phone = "866-100-2000",
                            State = "TX",
                            ZipCode = "77002"
                        });
                });

            modelBuilder.Entity("Api.Entities.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FirstName", "MiddleName", "LastName")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 26,
                            CompanyId = 1,
                            FirstName = "Sam",
                            LastName = "Raiden",
                            MiddleName = "A",
                            Phone = "713-100-0000",
                            Position = "Software developer"
                        },
                        new
                        {
                            Id = 2,
                            Age = 30,
                            CompanyId = 1,
                            FirstName = "Jana",
                            LastName = "McLeaf",
                            MiddleName = "B",
                            Phone = "832-200-0000",
                            Position = "Software developer"
                        },
                        new
                        {
                            Id = 3,
                            Age = 35,
                            CompanyId = 2,
                            FirstName = "Kane",
                            LastName = "Miller",
                            MiddleName = "C",
                            Phone = "100-300-0000",
                            Position = "Administrator"
                        },
                        new
                        {
                            Id = 4,
                            Age = 25,
                            CompanyId = 2,
                            FirstName = "Michael",
                            LastName = "Worth",
                            MiddleName = "D",
                            Phone = "200-300-0000",
                            Position = "Support I"
                        },
                        new
                        {
                            Id = 5,
                            Age = 35,
                            CompanyId = 2,
                            FirstName = "Nina",
                            LastName = "Hawk",
                            MiddleName = "E",
                            Phone = "300-300-0000",
                            Position = "Support II"
                        },
                        new
                        {
                            Id = 6,
                            Age = 29,
                            CompanyId = 2,
                            FirstName = "John",
                            LastName = "Spike",
                            MiddleName = "F",
                            Phone = "400-300-0000",
                            Position = "Support III"
                        },
                        new
                        {
                            Id = 7,
                            Age = 20,
                            CompanyId = 2,
                            FirstName = "Michael",
                            LastName = "Fins",
                            MiddleName = "G",
                            Phone = "500-300-0000",
                            Position = "Support VI"
                        },
                        new
                        {
                            Id = 8,
                            Age = 22,
                            CompanyId = 2,
                            FirstName = "Martha",
                            LastName = "Growns",
                            MiddleName = "H",
                            Phone = "500-300-0000",
                            Position = "Developer I"
                        },
                        new
                        {
                            Id = 9,
                            Age = 24,
                            CompanyId = 2,
                            FirstName = "Kirk",
                            LastName = "Metha",
                            MiddleName = "H",
                            Phone = "600-300-0000",
                            Position = "Developer II"
                        },
                        new
                        {
                            Id = 10,
                            Age = 25,
                            CompanyId = 3,
                            FirstName = "John",
                            LastName = "Smith",
                            MiddleName = "I",
                            Phone = "500-300-0000",
                            Position = "Developer III"
                        },
                        new
                        {
                            Id = 11,
                            Age = 25,
                            CompanyId = 3,
                            FirstName = "Walter",
                            LastName = "White",
                            MiddleName = "J",
                            Phone = "600-300-0000",
                            Position = "Developer IV"
                        });
                });

            modelBuilder.Entity("Api.Entities.Models.Employee", b =>
                {
                    b.HasOne("Api.Entities.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Api.Entities.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
