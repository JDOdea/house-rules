﻿// <auto-generated />
using System;
using HouseRules.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HouseRules.Migrations
{
    [DbContext(typeof(HouseRulesDbContext))]
    partial class HouseRulesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HouseRules.Models.Chore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChoreFrequencyDays")
                        .HasColumnType("integer");

                    b.Property<int>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Chores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChoreFrequencyDays = 5,
                            Difficulty = 2,
                            Name = "Vacuuming"
                        },
                        new
                        {
                            Id = 2,
                            ChoreFrequencyDays = 7,
                            Difficulty = 4,
                            Name = "Mow the Lawn"
                        },
                        new
                        {
                            Id = 3,
                            ChoreFrequencyDays = 2,
                            Difficulty = 3,
                            Name = "Clean Litterboxes"
                        },
                        new
                        {
                            Id = 4,
                            ChoreFrequencyDays = 2,
                            Difficulty = 3,
                            Name = "Dishes"
                        },
                        new
                        {
                            Id = 5,
                            ChoreFrequencyDays = 4,
                            Difficulty = 3,
                            Name = "Take Out Trash"
                        });
                });

            modelBuilder.Entity("HouseRules.Models.ChoreAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChoreId")
                        .HasColumnType("integer");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChoreId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("ChoreAssignments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChoreId = 3,
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 2,
                            ChoreId = 5,
                            UserProfileId = 3
                        },
                        new
                        {
                            Id = 3,
                            ChoreId = 2,
                            UserProfileId = 4
                        },
                        new
                        {
                            Id = 4,
                            ChoreId = 4,
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 5,
                            ChoreId = 1,
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 6,
                            ChoreId = 3,
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 7,
                            ChoreId = 5,
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 8,
                            ChoreId = 4,
                            UserProfileId = 4
                        },
                        new
                        {
                            Id = 9,
                            ChoreId = 1,
                            UserProfileId = 3
                        });
                });

            modelBuilder.Entity("HouseRules.Models.ChoreCompletion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChoreId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CompletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChoreId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("ChoreCompletions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChoreId = 3,
                            CompletedOn = new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 4
                        },
                        new
                        {
                            Id = 2,
                            ChoreId = 1,
                            CompletedOn = new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 3,
                            ChoreId = 4,
                            CompletedOn = new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 4,
                            ChoreId = 2,
                            CompletedOn = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 3
                        },
                        new
                        {
                            Id = 5,
                            ChoreId = 5,
                            CompletedOn = new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 6,
                            ChoreId = 3,
                            CompletedOn = new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 4
                        },
                        new
                        {
                            Id = 7,
                            ChoreId = 4,
                            CompletedOn = new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 8,
                            ChoreId = 1,
                            CompletedOn = new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 3
                        },
                        new
                        {
                            Id = 9,
                            ChoreId = 2,
                            CompletedOn = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        });
                });

            modelBuilder.Entity("HouseRules.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "101 Main Street",
                            FirstName = "Admina",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            LastName = "Strator"
                        },
                        new
                        {
                            Id = 2,
                            Address = "834 Road St",
                            FirstName = "JD",
                            IdentityUserId = "8b84b12a-0727-41dc-82e3-f44f1f038541",
                            LastName = "Fitzmartin"
                        },
                        new
                        {
                            Id = 3,
                            Address = "421 High Way",
                            FirstName = "Josh",
                            IdentityUserId = "9cb98efe-c05e-4992-9827-bb3f9f0d68ea",
                            LastName = "Barton"
                        },
                        new
                        {
                            Id = 4,
                            Address = "5253 Vista St",
                            FirstName = "Greg",
                            IdentityUserId = "e8fd99fa-a22c-412c-b45c-703c85ab4585",
                            LastName = "Korte"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            ConcurrencyStamp = "499b929a-5e70-4f2c-8953-d0820cfbb834",
                            Name = "Admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "319c4762-9053-4460-85aa-9d5ab64985ce",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAENWLEAwIv9ieQGaINF7RmbBhtrWc9EebkDj60rtphghncJBpWtsf49vcjeFfQ5LKRA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b4505604-70bd-4331-8217-ce16dc5b5336",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        },
                        new
                        {
                            Id = "8b84b12a-0727-41dc-82e3-f44f1f038541",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "df39e2db-707f-4b94-af8a-1edc98de8f52",
                            Email = "jdfitz@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEEbC8tWoqBvfEseL2WGiqpi1Ct2K+j/I4YVQwtrE/ehvLX23k+jVNB1hFAbDQvE+TA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a4e2d174-be9a-4cf3-adc5-d83223bf2041",
                            TwoFactorEnabled = false,
                            UserName = "jdfitz"
                        },
                        new
                        {
                            Id = "9cb98efe-c05e-4992-9827-bb3f9f0d68ea",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cf14de85-16d2-48a0-b37d-6a879c996cfd",
                            Email = "jbarton@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEF2/fOHPt0+ldzOZ7Tz4EVkX3gGhpuSkxJfDPPy2BTbxjbG+elTr92LZAsN7NUs4Rg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3515cd56-79e2-49e9-be65-ce7211eabba8",
                            TwoFactorEnabled = false,
                            UserName = "jbarton"
                        },
                        new
                        {
                            Id = "e8fd99fa-a22c-412c-b45c-703c85ab4585",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7b7a3c16-65a0-48d1-9d30-b5ce52a6f172",
                            Email = "greg@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEImBMteUtAhpqmukQ7leM19lhq6IUjGLfTxDdjvclUx3PkQEBtL1mtAdOrHbKWtwrQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dc3b353e-78cb-496f-86c4-28a5ff84927c",
                            TwoFactorEnabled = false,
                            UserName = "greg"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HouseRules.Models.ChoreAssignment", b =>
                {
                    b.HasOne("HouseRules.Models.Chore", "Chore")
                        .WithMany("ChoreAssignments")
                        .HasForeignKey("ChoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseRules.Models.UserProfile", "UserProfile")
                        .WithMany("ChoreAssignments")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chore");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("HouseRules.Models.ChoreCompletion", b =>
                {
                    b.HasOne("HouseRules.Models.Chore", "Chore")
                        .WithMany("ChoreCompletions")
                        .HasForeignKey("ChoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseRules.Models.UserProfile", "UserProfile")
                        .WithMany("ChoreCompletions")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chore");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("HouseRules.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HouseRules.Models.Chore", b =>
                {
                    b.Navigation("ChoreAssignments");

                    b.Navigation("ChoreCompletions");
                });

            modelBuilder.Entity("HouseRules.Models.UserProfile", b =>
                {
                    b.Navigation("ChoreAssignments");

                    b.Navigation("ChoreCompletions");
                });
#pragma warning restore 612, 618
        }
    }
}
