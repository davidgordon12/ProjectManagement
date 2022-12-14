﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagementApp.DataAccess;

#nullable disable

namespace ProjectManagementApp.Migrations
{
    [DbContext(typeof(ProjectManagementDbContext))]
    partial class ProjectManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjectManagement.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmployeeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            EmployeeNumber = "17-3456-DF",
                            FirstName = "Bart",
                            LastName = "Simpson",
                            ProjectId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            EmployeeNumber = "99-7768-AB",
                            FirstName = "Lisa",
                            LastName = "Simpson",
                            ProjectId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            EmployeeNumber = "87-4559-FG",
                            FirstName = "Maggie",
                            LastName = "Simpson",
                            ProjectId = 2
                        },
                        new
                        {
                            EmployeeId = 4,
                            EmployeeNumber = "11-4092-LM",
                            FirstName = "Marge",
                            LastName = "Simpson",
                            ProjectId = 2
                        },
                        new
                        {
                            EmployeeId = 5,
                            EmployeeNumber = "57-5930-ZC",
                            FirstName = "Homer",
                            LastName = "Simpson",
                            ProjectId = 2
                        });
                });

            modelBuilder.Entity("ProjectManagement.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            DateCreated = new DateTime(2022, 11, 27, 21, 24, 57, 55, DateTimeKind.Local).AddTicks(3731),
                            Name = "West parking lot expansion"
                        },
                        new
                        {
                            ProjectId = 2,
                            DateCreated = new DateTime(2022, 11, 27, 21, 24, 57, 55, DateTimeKind.Local).AddTicks(3788),
                            Name = "Cafeteria upgrade"
                        });
                });

            modelBuilder.Entity("ProjectManagement.Entities.ProjectTask", b =>
                {
                    b.Property<int>("ProjectTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectTaskId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("TaskStatus")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("ProjectTaskId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTasks");

                    b.HasData(
                        new
                        {
                            ProjectTaskId = 1,
                            Description = "Excavate ground",
                            DueDate = new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 1,
                            TaskStatus = "InProgress"
                        },
                        new
                        {
                            ProjectTaskId = 2,
                            Description = "Paving",
                            DueDate = new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 1,
                            TaskStatus = "InProgress"
                        },
                        new
                        {
                            ProjectTaskId = 3,
                            Description = "Install new flooring",
                            DueDate = new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 2,
                            TaskStatus = "InProgress"
                        },
                        new
                        {
                            ProjectTaskId = 4,
                            Description = "Paint",
                            DueDate = new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 2,
                            TaskStatus = "InProgress"
                        },
                        new
                        {
                            ProjectTaskId = 5,
                            Description = "Install new tabels and chairs",
                            DueDate = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 2,
                            TaskStatus = "InProgress"
                        },
                        new
                        {
                            ProjectTaskId = 6,
                            Description = "Survey surroundings",
                            DueDate = new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 1,
                            TaskStatus = "Completed"
                        },
                        new
                        {
                            ProjectTaskId = 7,
                            Description = "Level ground",
                            DueDate = new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 1,
                            TaskStatus = "Completed"
                        },
                        new
                        {
                            ProjectTaskId = 8,
                            Description = "Redo drop ceiling",
                            DueDate = new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 2,
                            TaskStatus = "Completed"
                        },
                        new
                        {
                            ProjectTaskId = 9,
                            Description = "Replace lighting with LED bulbs",
                            DueDate = new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 2,
                            TaskStatus = "Completed"
                        });
                });

            modelBuilder.Entity("ProjectManagementApp.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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
                    b.HasOne("ProjectManagementApp.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProjectManagementApp.Entities.User", null)
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

                    b.HasOne("ProjectManagementApp.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProjectManagementApp.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectManagement.Entities.Employee", b =>
                {
                    b.HasOne("ProjectManagement.Entities.Project", "Project")
                        .WithMany("Employees")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectManagement.Entities.ProjectTask", b =>
                {
                    b.HasOne("ProjectManagement.Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectManagement.Entities.Project", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
