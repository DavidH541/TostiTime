﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TostiTime.Data;

#nullable disable

namespace TostiTime.Data.Migrations
{
    [DbContext(typeof(TostiTimeDb))]
    partial class TostiTimeDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TostiTime.Core.Entities.Iron", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Irons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Grijs",
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Zwart",
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Klein",
                            OfficeId = 5
                        },
                        new
                        {
                            Id = 4,
                            Name = "Groot",
                            OfficeId = 5
                        },
                        new
                        {
                            Id = 5,
                            Name = "",
                            OfficeId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "",
                            OfficeId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "",
                            OfficeId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "",
                            OfficeId = 6
                        },
                        new
                        {
                            Id = 9,
                            Name = "",
                            OfficeId = 7
                        });
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "K.P. van der Mandelelaan 60",
                            City = "Rotterdam",
                            CityCode = "010",
                            Country = "The Netherlands",
                            PostalCode = "3062 MB"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Joop Geesinkweg 801",
                            City = "Amsterdam",
                            CityCode = "020",
                            Country = "The Netherlands",
                            PostalCode = "1114 AB"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Oude Middenweg 17",
                            City = "The Hague",
                            CityCode = "070",
                            Country = "The Netherlands",
                            PostalCode = "2491 AC"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Burgemeester Verderlaan 15b",
                            City = "Utrecht",
                            CityCode = "030",
                            Country = "The Netherlands",
                            PostalCode = "3544 AD"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Flight Forum 86",
                            City = "Eindhoven",
                            CityCode = "040",
                            Country = "The Netherlands",
                            PostalCode = "5657 DC"
                        },
                        new
                        {
                            Id = 6,
                            Address = "J.C. Wilslaan 29",
                            City = "Apeldoorn",
                            CityCode = "055",
                            Country = "The Netherlands",
                            PostalCode = "7313 HK"
                        },
                        new
                        {
                            Id = 7,
                            Address = "Vladimira Popovića 40",
                            City = "Belgrade",
                            CityCode = "011",
                            Country = "Serbia",
                            PostalCode = "11000"
                        });
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "David",
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Alexander",
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Casper",
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Marnix",
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Jesse",
                            OfficeId = 2
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Judith",
                            OfficeId = 3
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Youri",
                            OfficeId = 4
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Gijs",
                            OfficeId = 5
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "Jimmy",
                            OfficeId = 6
                        },
                        new
                        {
                            Id = 10,
                            FirstName = "Goran",
                            OfficeId = 7
                        });
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Reservation", b =>
                {
                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OccupiedSince")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OccupiedUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("SlotId", "PersonId", "OccupiedSince");

                    b.HasIndex("PersonId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Slot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IronId")
                        .HasColumnType("int");

                    b.Property<string>("SlotName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IronId");

                    b.ToTable("Slots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IronId = 1,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 2,
                            IronId = 1,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 3,
                            IronId = 1,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 4,
                            IronId = 1,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 5,
                            IronId = 2,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 6,
                            IronId = 2,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 7,
                            IronId = 2,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 8,
                            IronId = 2,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 9,
                            IronId = 3,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 10,
                            IronId = 3,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 11,
                            IronId = 3,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 12,
                            IronId = 3,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 13,
                            IronId = 4,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 14,
                            IronId = 4,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 15,
                            IronId = 4,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 16,
                            IronId = 4,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 17,
                            IronId = 4,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 18,
                            IronId = 4,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 19,
                            IronId = 5,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 20,
                            IronId = 5,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 21,
                            IronId = 6,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 22,
                            IronId = 6,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 23,
                            IronId = 7,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 24,
                            IronId = 7,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 25,
                            IronId = 7,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 26,
                            IronId = 7,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 27,
                            IronId = 8,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 28,
                            IronId = 8,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 29,
                            IronId = 9,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 30,
                            IronId = 9,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 31,
                            IronId = 9,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 32,
                            IronId = 9,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 33,
                            IronId = 9,
                            SlotName = ""
                        },
                        new
                        {
                            Id = 34,
                            IronId = 9,
                            SlotName = ""
                        });
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Iron", b =>
                {
                    b.HasOne("TostiTime.Core.Entities.Office", "Office")
                        .WithMany("Irons")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Person", b =>
                {
                    b.HasOne("TostiTime.Core.Entities.Office", "Office")
                        .WithMany("Persons")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Reservation", b =>
                {
                    b.HasOne("TostiTime.Core.Entities.Person", "Person")
                        .WithMany("Reservations")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("TostiTime.Core.Entities.Slot", "Slot")
                        .WithMany("Reservations")
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Slot", b =>
                {
                    b.HasOne("TostiTime.Core.Entities.Iron", "Iron")
                        .WithMany("Slots")
                        .HasForeignKey("IronId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Iron");
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Iron", b =>
                {
                    b.Navigation("Slots");
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Office", b =>
                {
                    b.Navigation("Irons");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Person", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("TostiTime.Core.Entities.Slot", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
