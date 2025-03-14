﻿// <auto-generated />
using System;
using Infrastructure.Data.Postgres.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.Postgres.EntityFramework.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20250311202501_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Data.Postgres.Entities.ParkingRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckedInAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CheckedOutAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("HourlyFee")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ParkingSpotId")
                        .HasColumnType("integer");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParkingSpotId");

                    b.ToTable("ParkingRecords");
                });

            modelBuilder.Entity("Infrastructure.Data.Postgres.Entities.ParkingSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AllowedVehicleSize")
                        .HasColumnType("integer");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("ParkingZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParkingZoneId");

                    b.ToTable("ParkingSpots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AllowedVehicleSize = 5,
                            IsOccupied = false,
                            Name = "A-1",
                            ParkingZoneId = 1
                        },
                        new
                        {
                            Id = 2,
                            AllowedVehicleSize = 5,
                            IsOccupied = false,
                            Name = "A-2",
                            ParkingZoneId = 1
                        },
                        new
                        {
                            Id = 3,
                            AllowedVehicleSize = 5,
                            IsOccupied = false,
                            Name = "A-3",
                            ParkingZoneId = 1
                        },
                        new
                        {
                            Id = 4,
                            AllowedVehicleSize = 10,
                            IsOccupied = false,
                            Name = "A-4",
                            ParkingZoneId = 1
                        },
                        new
                        {
                            Id = 5,
                            AllowedVehicleSize = 10,
                            IsOccupied = false,
                            Name = "A-5",
                            ParkingZoneId = 1
                        },
                        new
                        {
                            Id = 6,
                            AllowedVehicleSize = 15,
                            IsOccupied = false,
                            Name = "A-6",
                            ParkingZoneId = 1
                        },
                        new
                        {
                            Id = 7,
                            AllowedVehicleSize = 5,
                            IsOccupied = false,
                            Name = "B-1",
                            ParkingZoneId = 2
                        },
                        new
                        {
                            Id = 8,
                            AllowedVehicleSize = 5,
                            IsOccupied = false,
                            Name = "B-2",
                            ParkingZoneId = 2
                        },
                        new
                        {
                            Id = 9,
                            AllowedVehicleSize = 10,
                            IsOccupied = false,
                            Name = "B-3",
                            ParkingZoneId = 2
                        },
                        new
                        {
                            Id = 10,
                            AllowedVehicleSize = 10,
                            IsOccupied = false,
                            Name = "B-4",
                            ParkingZoneId = 2
                        },
                        new
                        {
                            Id = 11,
                            AllowedVehicleSize = 15,
                            IsOccupied = false,
                            Name = "B-5",
                            ParkingZoneId = 2
                        },
                        new
                        {
                            Id = 12,
                            AllowedVehicleSize = 15,
                            IsOccupied = false,
                            Name = "B-6",
                            ParkingZoneId = 2
                        },
                        new
                        {
                            Id = 13,
                            AllowedVehicleSize = 5,
                            IsOccupied = false,
                            Name = "C-1",
                            ParkingZoneId = 3
                        },
                        new
                        {
                            Id = 14,
                            AllowedVehicleSize = 5,
                            IsOccupied = false,
                            Name = "C-2",
                            ParkingZoneId = 3
                        },
                        new
                        {
                            Id = 15,
                            AllowedVehicleSize = 5,
                            IsOccupied = false,
                            Name = "C-3",
                            ParkingZoneId = 3
                        },
                        new
                        {
                            Id = 16,
                            AllowedVehicleSize = 5,
                            IsOccupied = false,
                            Name = "C-4",
                            ParkingZoneId = 3
                        },
                        new
                        {
                            Id = 17,
                            AllowedVehicleSize = 10,
                            IsOccupied = false,
                            Name = "C-5",
                            ParkingZoneId = 3
                        },
                        new
                        {
                            Id = 18,
                            AllowedVehicleSize = 10,
                            IsOccupied = false,
                            Name = "C-6",
                            ParkingZoneId = 3
                        },
                        new
                        {
                            Id = 19,
                            AllowedVehicleSize = 10,
                            IsOccupied = false,
                            Name = "C-7",
                            ParkingZoneId = 3
                        },
                        new
                        {
                            Id = 20,
                            AllowedVehicleSize = 15,
                            IsOccupied = false,
                            Name = "C-8",
                            ParkingZoneId = 3
                        },
                        new
                        {
                            Id = 21,
                            AllowedVehicleSize = 15,
                            IsOccupied = false,
                            Name = "C-9",
                            ParkingZoneId = 3
                        },
                        new
                        {
                            Id = 22,
                            AllowedVehicleSize = 15,
                            IsOccupied = false,
                            Name = "C-10",
                            ParkingZoneId = 3
                        });
                });

            modelBuilder.Entity("Infrastructure.Data.Postgres.Entities.ParkingZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<double>("HourlyFee")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("ParkingZones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 6,
                            HourlyFee = 60.0,
                            Name = "Parking Zone A"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 6,
                            HourlyFee = 100.0,
                            Name = "Parking Zone B"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 10,
                            HourlyFee = 75.0,
                            Name = "Parking Zone C"
                        });
                });

            modelBuilder.Entity("Infrastructure.Data.Postgres.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.Data.Postgres.Entities.UserToken", b =>
                {
                    b.Property<string>("Token")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("TokenType")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Infrastructure.Data.Postgres.Entities.ParkingRecord", b =>
                {
                    b.HasOne("Infrastructure.Data.Postgres.Entities.ParkingSpot", "ParkingSpot")
                        .WithMany()
                        .HasForeignKey("ParkingSpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingSpot");
                });

            modelBuilder.Entity("Infrastructure.Data.Postgres.Entities.ParkingSpot", b =>
                {
                    b.HasOne("Infrastructure.Data.Postgres.Entities.ParkingZone", "ParkingZone")
                        .WithMany("ParkingSpots")
                        .HasForeignKey("ParkingZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingZone");
                });

            modelBuilder.Entity("Infrastructure.Data.Postgres.Entities.UserToken", b =>
                {
                    b.HasOne("Infrastructure.Data.Postgres.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Data.Postgres.Entities.ParkingZone", b =>
                {
                    b.Navigation("ParkingSpots");
                });
#pragma warning restore 612, 618
        }
    }
}
