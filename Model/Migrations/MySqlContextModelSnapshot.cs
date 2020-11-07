﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Users.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Apartment")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apartment = 0,
                            CityId = 21000,
                            Floor = 0,
                            Number = 4,
                            Street = "Radnicka"
                        },
                        new
                        {
                            Id = 2,
                            Apartment = 0,
                            CityId = 11000,
                            Floor = 0,
                            Number = 5,
                            Street = "Gospodara Vucica"
                        });
                });

            modelBuilder.Entity("Model.Users.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("StateId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 21000,
                            Name = "Novi Sad",
                            StateId = 1L
                        },
                        new
                        {
                            Id = 11000,
                            Name = "Beograd",
                            StateId = 1L
                        });
                });

            modelBuilder.Entity("Model.Users.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdditionalNotes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("AllowedForPublishing")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Anonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RegisteredUserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RegisteredUserId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdditionalNotes = "Sve je super!",
                            AllowedForPublishing = true,
                            Anonymous = false,
                            Approved = true,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegisteredUserId = "2406978890045"
                        },
                        new
                        {
                            Id = 2,
                            AdditionalNotes = "Bolnica je veoma losa, bas sam razocaran! Rupe u zidovima, voda curi na sve strane, treba vas zatvoriti!!!",
                            AllowedForPublishing = true,
                            Anonymous = false,
                            Approved = false,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegisteredUserId = "2406978890045"
                        },
                        new
                        {
                            Id = 3,
                            AdditionalNotes = "Predivno, ali i ruzno! Sramite se! Cestitke... <3",
                            AllowedForPublishing = false,
                            Anonymous = false,
                            Approved = false,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegisteredUserId = "2406978890045"
                        },
                        new
                        {
                            Id = 4,
                            AdditionalNotes = "Odlicno!",
                            AllowedForPublishing = false,
                            Anonymous = false,
                            Approved = false,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegisteredUserId = "2406978890045"
                        });
                });

            modelBuilder.Entity("Model.Users.InsurancePolicy", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Company")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("PolicyEndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("PolicyStartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("InsurancePolicies");

                    b.HasData(
                        new
                        {
                            Id = "policy1",
                            Company = "Dunav osiguranje d.o.o",
                            PolicyEndDate = new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PolicyStartDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Model.Users.RegisteredUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("CurrResidenceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EducationLevel")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("InsurancePolicyId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PlaceOfBirthId")
                        .HasColumnType("int");

                    b.Property<string>("Profession")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CurrResidenceId");

                    b.HasIndex("InsurancePolicyId");

                    b.HasIndex("PlaceOfBirthId");

                    b.ToTable("RegisteredUsers");

                    b.HasData(
                        new
                        {
                            Id = "2406978890045",
                            CurrResidenceId = 1,
                            DateOfBirth = new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfCreation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EducationLevel = 2,
                            Email = "marko@gmail.com",
                            Gender = 0,
                            InsurancePolicyId = "policy1",
                            Name = "Marko",
                            Password = "marko1978",
                            Phone = "065/123-4554",
                            PlaceOfBirthId = 11000,
                            Profession = "vodoinstalater",
                            ProfileImage = ".",
                            Surname = "Markovic",
                            Username = "markic"
                        });
                });

            modelBuilder.Entity("Model.Users.State", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Serbia"
                        });
                });

            modelBuilder.Entity("Model.Users.Address", b =>
                {
                    b.HasOne("Model.Users.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Users.City", b =>
                {
                    b.HasOne("Model.Users.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Users.Feedback", b =>
                {
                    b.HasOne("Model.Users.RegisteredUser", "RegisteredUser")
                        .WithMany()
                        .HasForeignKey("RegisteredUserId");
                });

            modelBuilder.Entity("Model.Users.RegisteredUser", b =>
                {
                    b.HasOne("Model.Users.Address", "CurrResidence")
                        .WithMany()
                        .HasForeignKey("CurrResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Users.InsurancePolicy", "InsurancePolicy")
                        .WithMany()
                        .HasForeignKey("InsurancePolicyId");

                    b.HasOne("Model.Users.City", "PlaceOfBirth")
                        .WithMany()
                        .HasForeignKey("PlaceOfBirthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
