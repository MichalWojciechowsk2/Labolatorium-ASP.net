﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231212212433_TestMig")]
    partial class TestMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Data.Entities.BookEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ISBN")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublishingHouse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Regon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nip = "83492384",
                            Regon = "13424234",
                            Title = "WSEI"
                        },
                        new
                        {
                            Id = 2,
                            Nip = "2498534",
                            Regon = "0873439249",
                            Title = "Firma"
                        });
                });

            modelBuilder.Entity("Data.LibraryEntities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("ISBN")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublishingHouse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("priority")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Michal Wojciechowski",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISBN = 123,
                            NumberOfPages = 100,
                            PublicationDate = new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishingHouse = "Wsei",
                            Title = "Test book",
                            priority = 0
                        },
                        new
                        {
                            Id = 2,
                            Author = "Wojciech Michałowski",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ISBN = 321,
                            NumberOfPages = 200,
                            PublicationDate = new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishingHouse = "Agh",
                            Title = "Book 2",
                            priority = 0
                        });
                });

            modelBuilder.Entity("Data.Entities.BookEntity", b =>
                {
                    b.HasOne("Data.Entities.OrganizationEntity", "Organization")
                        .WithMany("Book")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.OwnsOne("ModelsLibrary.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityId");

                            b1.ToTable("Organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityId = 1,
                                    City = "Kraków",
                                    PostalCode = "31-150",
                                    Region = "małopolskie",
                                    Street = "Św. Filipa 17"
                                },
                                new
                                {
                                    OrganizationEntityId = 2,
                                    City = "Kraków",
                                    PostalCode = "31-150",
                                    Region = "małopolskie",
                                    Street = "Krowoderska 45/6"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}