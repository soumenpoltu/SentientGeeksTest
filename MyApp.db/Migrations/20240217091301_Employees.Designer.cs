﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApp.db.MydbContext;

#nullable disable

namespace MyApp.db.Migrations
{
    [DbContext(typeof(AppdbContext))]
    [Migration("20240217091301_Employees")]
    partial class Employees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyApp.Entity.EntityLogin", b =>
                {
                    b.Property<int>("USER_KEY")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("USER_KEY"), 1L, 1);

                    b.Property<DateTime>("EDIT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("EDIT_USER_KEY")
                        .HasColumnType("int");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ENT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("ENT_USER_KEY")
                        .HasColumnType("int");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PASSWORD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("TAG_ACTIVE")
                        .HasColumnType("tinyint");

                    b.Property<byte>("TAG_DELETE")
                        .HasColumnType("tinyint");

                    b.Property<string>("USER_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USER_ROLE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("USER_KEY");

                    b.ToTable("AuthorizeUsers");
                });

            modelBuilder.Entity("MyApp.Entity.models.EntityEmployee", b =>
                {
                    b.Property<int>("MAST_EMPLOYEE_KEY")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MAST_EMPLOYEE_KEY"), 1L, 1);

                    b.Property<string>("ADDRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EDIT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("EDIT_USER_KEY")
                        .HasColumnType("int");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ENT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("ENT_USER_KEY")
                        .HasColumnType("int");

                    b.Property<string>("FULLNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PHONE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("TAG_ACTIVE")
                        .HasColumnType("tinyint");

                    b.Property<byte>("TAG_DELETE")
                        .HasColumnType("tinyint");

                    b.HasKey("MAST_EMPLOYEE_KEY");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}