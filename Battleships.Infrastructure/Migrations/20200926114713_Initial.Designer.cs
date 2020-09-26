﻿// <auto-generated />
using Battleships.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Battleships.Infrastructure.Migrations
{
    [DbContext(typeof(BattleshipsDbContext))]
    [Migration("20200926114713_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.BoardEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.CoordinateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Column")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Coordinates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Column = "a",
                            Row = 1
                        },
                        new
                        {
                            Id = 2,
                            Column = "b",
                            Row = 1
                        },
                        new
                        {
                            Id = 3,
                            Column = "c",
                            Row = 1
                        },
                        new
                        {
                            Id = 4,
                            Column = "d",
                            Row = 1
                        },
                        new
                        {
                            Id = 5,
                            Column = "e",
                            Row = 1
                        },
                        new
                        {
                            Id = 6,
                            Column = "f",
                            Row = 1
                        },
                        new
                        {
                            Id = 7,
                            Column = "g",
                            Row = 1
                        },
                        new
                        {
                            Id = 8,
                            Column = "h",
                            Row = 1
                        },
                        new
                        {
                            Id = 9,
                            Column = "i",
                            Row = 1
                        },
                        new
                        {
                            Id = 10,
                            Column = "j",
                            Row = 1
                        },
                        new
                        {
                            Id = 11,
                            Column = "a",
                            Row = 2
                        },
                        new
                        {
                            Id = 12,
                            Column = "b",
                            Row = 2
                        },
                        new
                        {
                            Id = 13,
                            Column = "c",
                            Row = 2
                        },
                        new
                        {
                            Id = 14,
                            Column = "d",
                            Row = 2
                        },
                        new
                        {
                            Id = 15,
                            Column = "e",
                            Row = 2
                        },
                        new
                        {
                            Id = 16,
                            Column = "f",
                            Row = 2
                        },
                        new
                        {
                            Id = 17,
                            Column = "g",
                            Row = 2
                        },
                        new
                        {
                            Id = 18,
                            Column = "h",
                            Row = 2
                        },
                        new
                        {
                            Id = 19,
                            Column = "i",
                            Row = 2
                        },
                        new
                        {
                            Id = 20,
                            Column = "j",
                            Row = 2
                        },
                        new
                        {
                            Id = 21,
                            Column = "a",
                            Row = 3
                        },
                        new
                        {
                            Id = 22,
                            Column = "b",
                            Row = 3
                        },
                        new
                        {
                            Id = 23,
                            Column = "c",
                            Row = 3
                        },
                        new
                        {
                            Id = 24,
                            Column = "d",
                            Row = 3
                        },
                        new
                        {
                            Id = 25,
                            Column = "e",
                            Row = 3
                        },
                        new
                        {
                            Id = 26,
                            Column = "f",
                            Row = 3
                        },
                        new
                        {
                            Id = 27,
                            Column = "g",
                            Row = 3
                        },
                        new
                        {
                            Id = 28,
                            Column = "h",
                            Row = 3
                        },
                        new
                        {
                            Id = 29,
                            Column = "i",
                            Row = 3
                        },
                        new
                        {
                            Id = 30,
                            Column = "j",
                            Row = 3
                        },
                        new
                        {
                            Id = 31,
                            Column = "a",
                            Row = 4
                        },
                        new
                        {
                            Id = 32,
                            Column = "b",
                            Row = 4
                        },
                        new
                        {
                            Id = 33,
                            Column = "c",
                            Row = 4
                        },
                        new
                        {
                            Id = 34,
                            Column = "d",
                            Row = 4
                        },
                        new
                        {
                            Id = 35,
                            Column = "e",
                            Row = 4
                        },
                        new
                        {
                            Id = 36,
                            Column = "f",
                            Row = 4
                        },
                        new
                        {
                            Id = 37,
                            Column = "g",
                            Row = 4
                        },
                        new
                        {
                            Id = 38,
                            Column = "h",
                            Row = 4
                        },
                        new
                        {
                            Id = 39,
                            Column = "i",
                            Row = 4
                        },
                        new
                        {
                            Id = 40,
                            Column = "j",
                            Row = 4
                        },
                        new
                        {
                            Id = 41,
                            Column = "a",
                            Row = 5
                        },
                        new
                        {
                            Id = 42,
                            Column = "b",
                            Row = 5
                        },
                        new
                        {
                            Id = 43,
                            Column = "c",
                            Row = 5
                        },
                        new
                        {
                            Id = 44,
                            Column = "d",
                            Row = 5
                        },
                        new
                        {
                            Id = 45,
                            Column = "e",
                            Row = 5
                        },
                        new
                        {
                            Id = 46,
                            Column = "f",
                            Row = 5
                        },
                        new
                        {
                            Id = 47,
                            Column = "g",
                            Row = 5
                        },
                        new
                        {
                            Id = 48,
                            Column = "h",
                            Row = 5
                        },
                        new
                        {
                            Id = 49,
                            Column = "i",
                            Row = 5
                        },
                        new
                        {
                            Id = 50,
                            Column = "j",
                            Row = 5
                        },
                        new
                        {
                            Id = 51,
                            Column = "a",
                            Row = 6
                        },
                        new
                        {
                            Id = 52,
                            Column = "b",
                            Row = 6
                        },
                        new
                        {
                            Id = 53,
                            Column = "c",
                            Row = 6
                        },
                        new
                        {
                            Id = 54,
                            Column = "d",
                            Row = 6
                        },
                        new
                        {
                            Id = 55,
                            Column = "e",
                            Row = 6
                        },
                        new
                        {
                            Id = 56,
                            Column = "f",
                            Row = 6
                        },
                        new
                        {
                            Id = 57,
                            Column = "g",
                            Row = 6
                        },
                        new
                        {
                            Id = 58,
                            Column = "h",
                            Row = 6
                        },
                        new
                        {
                            Id = 59,
                            Column = "i",
                            Row = 6
                        },
                        new
                        {
                            Id = 60,
                            Column = "j",
                            Row = 6
                        },
                        new
                        {
                            Id = 61,
                            Column = "a",
                            Row = 7
                        },
                        new
                        {
                            Id = 62,
                            Column = "b",
                            Row = 7
                        },
                        new
                        {
                            Id = 63,
                            Column = "c",
                            Row = 7
                        },
                        new
                        {
                            Id = 64,
                            Column = "d",
                            Row = 7
                        },
                        new
                        {
                            Id = 65,
                            Column = "e",
                            Row = 7
                        },
                        new
                        {
                            Id = 66,
                            Column = "f",
                            Row = 7
                        },
                        new
                        {
                            Id = 67,
                            Column = "g",
                            Row = 7
                        },
                        new
                        {
                            Id = 68,
                            Column = "h",
                            Row = 7
                        },
                        new
                        {
                            Id = 69,
                            Column = "i",
                            Row = 7
                        },
                        new
                        {
                            Id = 70,
                            Column = "j",
                            Row = 7
                        },
                        new
                        {
                            Id = 71,
                            Column = "a",
                            Row = 8
                        },
                        new
                        {
                            Id = 72,
                            Column = "b",
                            Row = 8
                        },
                        new
                        {
                            Id = 73,
                            Column = "c",
                            Row = 8
                        },
                        new
                        {
                            Id = 74,
                            Column = "d",
                            Row = 8
                        },
                        new
                        {
                            Id = 75,
                            Column = "e",
                            Row = 8
                        },
                        new
                        {
                            Id = 76,
                            Column = "f",
                            Row = 8
                        },
                        new
                        {
                            Id = 77,
                            Column = "g",
                            Row = 8
                        },
                        new
                        {
                            Id = 78,
                            Column = "h",
                            Row = 8
                        },
                        new
                        {
                            Id = 79,
                            Column = "i",
                            Row = 8
                        },
                        new
                        {
                            Id = 80,
                            Column = "j",
                            Row = 8
                        },
                        new
                        {
                            Id = 81,
                            Column = "a",
                            Row = 9
                        },
                        new
                        {
                            Id = 82,
                            Column = "b",
                            Row = 9
                        },
                        new
                        {
                            Id = 83,
                            Column = "c",
                            Row = 9
                        },
                        new
                        {
                            Id = 84,
                            Column = "d",
                            Row = 9
                        },
                        new
                        {
                            Id = 85,
                            Column = "e",
                            Row = 9
                        },
                        new
                        {
                            Id = 86,
                            Column = "f",
                            Row = 9
                        },
                        new
                        {
                            Id = 87,
                            Column = "g",
                            Row = 9
                        },
                        new
                        {
                            Id = 88,
                            Column = "h",
                            Row = 9
                        },
                        new
                        {
                            Id = 89,
                            Column = "i",
                            Row = 9
                        },
                        new
                        {
                            Id = 90,
                            Column = "j",
                            Row = 9
                        },
                        new
                        {
                            Id = 91,
                            Column = "a",
                            Row = 10
                        },
                        new
                        {
                            Id = 92,
                            Column = "b",
                            Row = 10
                        },
                        new
                        {
                            Id = 93,
                            Column = "c",
                            Row = 10
                        },
                        new
                        {
                            Id = 94,
                            Column = "d",
                            Row = 10
                        },
                        new
                        {
                            Id = 95,
                            Column = "e",
                            Row = 10
                        },
                        new
                        {
                            Id = 96,
                            Column = "f",
                            Row = 10
                        },
                        new
                        {
                            Id = 97,
                            Column = "g",
                            Row = 10
                        },
                        new
                        {
                            Id = 98,
                            Column = "h",
                            Row = 10
                        },
                        new
                        {
                            Id = 99,
                            Column = "i",
                            Row = 10
                        },
                        new
                        {
                            Id = 100,
                            Column = "j",
                            Row = 10
                        });
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComputerBoardId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerBoardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComputerBoardId")
                        .IsUnique();

                    b.HasIndex("PlayerBoardId")
                        .IsUnique();

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.HitShotEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<int>("CoordinateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("CoordinateId");

                    b.ToTable("HitShots");
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.MissShotEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<int>("CoordinateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("CoordinateId");

                    b.ToTable("MissShots");
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.ShipEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.ShipPositionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoordinateId")
                        .HasColumnType("int");

                    b.Property<int>("ShipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoordinateId");

                    b.HasIndex("ShipId");

                    b.ToTable("ShipPositions");
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.GameEntity", b =>
                {
                    b.HasOne("Battleships.Infrastructure.DatabaseEntities.BoardEntity", "ComputerBoard")
                        .WithOne()
                        .HasForeignKey("Battleships.Infrastructure.DatabaseEntities.GameEntity", "ComputerBoardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Battleships.Infrastructure.DatabaseEntities.BoardEntity", "PlayerBoard")
                        .WithOne()
                        .HasForeignKey("Battleships.Infrastructure.DatabaseEntities.GameEntity", "PlayerBoardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.HitShotEntity", b =>
                {
                    b.HasOne("Battleships.Infrastructure.DatabaseEntities.BoardEntity", "Board")
                        .WithMany("HitShots")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Battleships.Infrastructure.DatabaseEntities.CoordinateEntity", "Coordinate")
                        .WithMany()
                        .HasForeignKey("CoordinateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.MissShotEntity", b =>
                {
                    b.HasOne("Battleships.Infrastructure.DatabaseEntities.BoardEntity", "Board")
                        .WithMany("MissShots")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Battleships.Infrastructure.DatabaseEntities.CoordinateEntity", "Coordinate")
                        .WithMany()
                        .HasForeignKey("CoordinateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.ShipEntity", b =>
                {
                    b.HasOne("Battleships.Infrastructure.DatabaseEntities.BoardEntity", "Board")
                        .WithMany("Ships")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Battleships.Infrastructure.DatabaseEntities.ShipPositionEntity", b =>
                {
                    b.HasOne("Battleships.Infrastructure.DatabaseEntities.CoordinateEntity", "Coordinate")
                        .WithMany()
                        .HasForeignKey("CoordinateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Battleships.Infrastructure.DatabaseEntities.ShipEntity", "Ship")
                        .WithMany("ShipPositions")
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}