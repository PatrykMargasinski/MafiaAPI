// <auto-generated />
using System;
using MafiaAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MafiaAPI.Migrations
{
    [DbContext(typeof(MafiaDBContext))]
    [Migration("20210727182158_firstNameAndLastName")]
    partial class firstNameAndLastName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Polish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MafiaAPI.Models.Agent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BossId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Income")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BossId");

                    b.ToTable("Agent");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BossId = 1L,
                            FirstName = "Kujo",
                            Income = 100,
                            LastName = "Jotaro",
                            Strength = 10
                        },
                        new
                        {
                            Id = 2L,
                            BossId = 1L,
                            FirstName = "Mickiewicz",
                            Income = 50,
                            LastName = "Adam",
                            Strength = 5
                        },
                        new
                        {
                            Id = 3L,
                            BossId = 2L,
                            FirstName = "Natsu",
                            Income = 70,
                            LastName = "Natalia",
                            Strength = 7
                        },
                        new
                        {
                            Id = 4L,
                            FirstName = "Eleonora",
                            Income = 30,
                            LastName = "Lora",
                            Strength = 8
                        },
                        new
                        {
                            Id = 5L,
                            BossId = 1L,
                            FirstName = "Robert",
                            Income = 200,
                            LastName = "Makłowicz",
                            Strength = 3
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.Boss", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastSeen")
                        .HasColumnType("datetime");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Boss");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FirstName = "Rico",
                            LastName = "Patricio",
                            LastSeen = new DateTime(2021, 7, 27, 20, 21, 56, 997, DateTimeKind.Local).AddTicks(556),
                            Money = 5000
                        },
                        new
                        {
                            Id = 2L,
                            FirstName = "Margherita",
                            LastName = "Rodrigo",
                            LastSeen = new DateTime(2021, 7, 27, 20, 21, 57, 1, DateTimeKind.Local).AddTicks(8033),
                            Money = 5000
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.FirstName", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FirstName");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Gianna"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Blanka"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Lucia"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Romeo"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Capri"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Armani"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Giuseppe"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Secondo"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Allegra"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Brandy"
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.LastName", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("LastName");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Ferrari"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Colombo"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Conti"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "De Luca"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Rizzo"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Lombardi"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Moretti"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Greco"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Bruno"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Marino"
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<long?>("FromBossId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Seen")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ToBossId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FromBossId");

                    b.HasIndex("ToBossId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("MafiaAPI.Models.Mission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<int?>("Loot")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Mission");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DifficultyLevel = 7,
                            Duration = 30.0,
                            Loot = 5000,
                            Name = "Bank robbery"
                        },
                        new
                        {
                            Id = 2L,
                            DifficultyLevel = 9,
                            Duration = 60.0,
                            Loot = 10000,
                            Name = "Senator assassination"
                        },
                        new
                        {
                            Id = 3L,
                            DifficultyLevel = 2,
                            Duration = 10.0,
                            Loot = 100,
                            Name = "Party"
                        },
                        new
                        {
                            Id = 4L,
                            DifficultyLevel = 1,
                            Duration = 5.0,
                            Loot = 10,
                            Name = "Buy a coffee"
                        },
                        new
                        {
                            Id = 5L,
                            DifficultyLevel = 5,
                            Duration = 55.0,
                            Loot = 1000,
                            Name = "Money laundering"
                        },
                        new
                        {
                            Id = 6L,
                            DifficultyLevel = 6,
                            Duration = 3600.0,
                            Loot = 2000,
                            Name = "Car theft"
                        },
                        new
                        {
                            Id = 7L,
                            DifficultyLevel = 8,
                            Duration = 15.0,
                            Loot = 4000,
                            Name = "Arms trade"
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.PerformingMission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AgentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CompletionTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("MissionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("MissionId");

                    b.ToTable("PerformingMission");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AgentId = 1L,
                            CompletionTime = new DateTime(2021, 7, 27, 20, 21, 57, 7, DateTimeKind.Local).AddTicks(6467),
                            MissionId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            AgentId = 3L,
                            CompletionTime = new DateTime(2021, 7, 27, 20, 21, 57, 7, DateTimeKind.Local).AddTicks(7252),
                            MissionId = 2L
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BossId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nick")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BossId" }, "UQ__Player__07C93FB72CC07189")
                        .IsUnique();

                    b.ToTable("Player");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BossId = 1L,
                            Nick = "mafia",
                            Password = "tlnK6HiwFF4+b4DRVaVdRlIPtzduirsf8W3+nbXlLWlf9c/J"
                        },
                        new
                        {
                            Id = 2L,
                            BossId = 2L,
                            Nick = "tomek",
                            Password = "d2JZt0Jz9UzgW1l544W2WnOaX14u/pfGUDYTQzv5AEWk3W7D"
                        });
                });

            modelBuilder.Entity("MafiaAPI.Models.Agent", b =>
                {
                    b.HasOne("MafiaAPI.Models.Boss", "Boss")
                        .WithMany("Agents")
                        .HasForeignKey("BossId")
                        .HasConstraintName("FK__Agent__BossId__4BAC3F29");

                    b.Navigation("Boss");
                });

            modelBuilder.Entity("MafiaAPI.Models.Message", b =>
                {
                    b.HasOne("MafiaAPI.Models.Boss", "FromBoss")
                        .WithMany("MessageFromBosses")
                        .HasForeignKey("FromBossId")
                        .HasConstraintName("FK__Message__FromBos__2180FB33");

                    b.HasOne("MafiaAPI.Models.Boss", "ToBoss")
                        .WithMany("MessageToBosses")
                        .HasForeignKey("ToBossId")
                        .HasConstraintName("FK__Message__ToBossI__208CD6FA");

                    b.Navigation("FromBoss");

                    b.Navigation("ToBoss");
                });

            modelBuilder.Entity("MafiaAPI.Models.PerformingMission", b =>
                {
                    b.HasOne("MafiaAPI.Models.Agent", "Agent")
                        .WithMany("PerformingMissions")
                        .HasForeignKey("AgentId")
                        .HasConstraintName("FK__Performin__Agent__5165187F");

                    b.HasOne("MafiaAPI.Models.Mission", "Mission")
                        .WithMany("PerformingMissions")
                        .HasForeignKey("MissionId")
                        .HasConstraintName("FK__Performin__Missi__5070F446");

                    b.Navigation("Agent");

                    b.Navigation("Mission");
                });

            modelBuilder.Entity("MafiaAPI.Models.Player", b =>
                {
                    b.HasOne("MafiaAPI.Models.Boss", "Boss")
                        .WithOne("Player")
                        .HasForeignKey("MafiaAPI.Models.Player", "BossId")
                        .HasConstraintName("FK__Player__BossId__1DB06A4F")
                        .IsRequired();

                    b.Navigation("Boss");
                });

            modelBuilder.Entity("MafiaAPI.Models.Agent", b =>
                {
                    b.Navigation("PerformingMissions");
                });

            modelBuilder.Entity("MafiaAPI.Models.Boss", b =>
                {
                    b.Navigation("Agents");

                    b.Navigation("MessageFromBosses");

                    b.Navigation("MessageToBosses");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MafiaAPI.Models.Mission", b =>
                {
                    b.Navigation("PerformingMissions");
                });
#pragma warning restore 612, 618
        }
    }
}
