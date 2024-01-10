﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestWithAsp.Net.Model.Context;

#nullable disable

namespace RestWithAsp.Net.Migrations
{
    [DbContext(typeof(RestWithAspDotNetContext))]
    [Migration("20240109210205_user-changes")]
    partial class userchanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestWithAsp.Net.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Author");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Launch Date");

                    b.Property<decimal>("Price")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal(20,2)")
                        .HasColumnName("Price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Michael C. Feathers",
                            LaunchDate = new DateTime(2017, 11, 29, 13, 50, 5, 878, DateTimeKind.Unspecified),
                            Price = 49.00m,
                            Title = "Working effectively with legacy code"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Ralph Johnson, Erich Gamma, John Vlissides e Richard Helm",
                            LaunchDate = new DateTime(2017, 11, 29, 15, 15, 13, 636, DateTimeKind.Unspecified),
                            Price = 77.00m,
                            Title = "Design Patterns"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Robert C. Martin",
                            LaunchDate = new DateTime(2009, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 67.00m,
                            Title = "Clean Code"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Crockford",
                            LaunchDate = new DateTime(2017, 11, 7, 15, 9, 1, 674, DateTimeKind.Unspecified),
                            Price = 67.00m,
                            Title = "JavaScript"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Steve McConnell",
                            LaunchDate = new DateTime(2017, 11, 7, 15, 9, 1, 674, DateTimeKind.Unspecified),
                            Price = 58.00m,
                            Title = "Refactoring"
                        });
                });

            modelBuilder.Entity("RestWithAsp.Net.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("First Name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("Last Name");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "São Paulo - Brasil",
                            FirstName = "Ayrton",
                            Gender = "Male",
                            LastName = "Senna"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Anchiano - Italy",
                            FirstName = "Leonardo",
                            Gender = "Male",
                            LastName = "da Vinci"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Porbandar - India",
                            FirstName = "Mahatma",
                            Gender = "Male",
                            LastName = "Gandhi"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Kentuky - USA",
                            FirstName = "Mohamed",
                            Gender = "Male",
                            LastName = "Ali"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Mvezo - South Africa",
                            FirstName = "Nelson",
                            Gender = "Male",
                            LastName = "Mandela"
                        });
                });

            modelBuilder.Entity("RestWithAsp.Net.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Full Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Refresh Token");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("Refresh Token Expiry Time");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("User Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
