﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using minimalapientityFramework;

#nullable disable

namespace minimal_api_entityFramework.Migrations
{
    [DbContext(typeof(TasksContext))]
    partial class TasksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("minimalapientityFramework.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.HasKey("CategoryId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("5b2e793a-1027-40a6-83b7-54a2a92f96d7"),
                            Name = "Pending activities",
                            Peso = 20
                        },
                        new
                        {
                            CategoryId = new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9602"),
                            Name = "Personal activities",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("minimalapientityFramework.Models.Taskk", b =>
                {
                    b.Property<Guid>("TaskkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("TaskPriority")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("TaskkId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TaskkId = new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9610"),
                            CategoryId = new Guid("5b2e793a-1027-40a6-83b7-54a2a92f96d7"),
                            CreatedDate = new DateTime(2022, 8, 27, 23, 32, 36, 97, DateTimeKind.Local).AddTicks(8990),
                            TaskPriority = 1,
                            Title = "DO payments"
                        },
                        new
                        {
                            TaskkId = new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9611"),
                            CategoryId = new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9602"),
                            CreatedDate = new DateTime(2022, 8, 27, 23, 32, 36, 97, DateTimeKind.Local).AddTicks(9010),
                            TaskPriority = 0,
                            Title = "end movie"
                        });
                });

            modelBuilder.Entity("minimalapientityFramework.Models.Taskk", b =>
                {
                    b.HasOne("minimalapientityFramework.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("minimalapientityFramework.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
