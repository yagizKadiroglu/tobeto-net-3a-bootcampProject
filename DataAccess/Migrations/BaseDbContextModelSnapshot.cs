﻿// <auto-generated />
using System;
using DataAccess.Concretes.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateOfBirth");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("NationalIdentity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NationalIdentity");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Entities.Applicant", b =>
                {
                    b.HasBaseType("Entities.User");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("About");

                    b.HasDiscriminator().HasValue("Applicant");
                });

            modelBuilder.Entity("Entities.Employee", b =>
                {
                    b.HasBaseType("Entities.User");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Position");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Entities.Instructor", b =>
                {
                    b.HasBaseType("Entities.User");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyName");

                    b.HasDiscriminator().HasValue("Instructor");
                });
#pragma warning restore 612, 618
        }
    }
}
