﻿// <auto-generated />
using System;
using Kusys.DAL.EfDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kusys.DAL.Migrations
{
    [DbContext(typeof(KusysDbContext))]
    partial class KusysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kusys.Domains.Domains.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "CSI101",
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6690),
                            Name = "Introduction to Computer Science"
                        },
                        new
                        {
                            Id = 2,
                            Code = "CSI102",
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6690),
                            Name = "Algorithms"
                        },
                        new
                        {
                            Id = 3,
                            Code = "MAT101",
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6690),
                            Name = "Calculus"
                        },
                        new
                        {
                            Id = 4,
                            Code = "PHY101",
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6690),
                            Name = "Physics"
                        });
                });

            modelBuilder.Entity("Kusys.Domains.Domains.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1995, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 1,
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770),
                            FirstName = "Fehmi",
                            LastName = "Demir"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1994, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 2,
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770),
                            FirstName = "Atalay",
                            LastName = "Dumenci"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1993, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 3,
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770),
                            FirstName = "Gurbet",
                            LastName = "Sevgi"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1993, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 4,
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770),
                            FirstName = "Ozkan",
                            LastName = "Celen"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1993, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 3,
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770),
                            FirstName = "Yildiray",
                            LastName = "Umut"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1993, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 1,
                            CreatedDate = new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770),
                            FirstName = "Umut",
                            LastName = "Eksilmez"
                        });
                });

            modelBuilder.Entity("Kusys.Domains.Domains.Student", b =>
                {
                    b.HasOne("Kusys.Domains.Domains.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Kusys.Domains.Domains.Course", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
