﻿// <auto-generated />
using BookOfReference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookOfReference.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookOfReference.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("BookOfReference.Models.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<int>("Company_Id")
                        .HasColumnType("integer");

                    b.Property<string>("Departament_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Departament_Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Workers_Count")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Departament");
                });

            modelBuilder.Entity("BookOfReference.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Index")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Salary_Id")
                        .HasColumnType("integer");

                    b.Property<string>("WorkerId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("BookOfReference.Models.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Award_Salary")
                        .HasColumnType("real");

                    b.Property<float>("MonthSalary")
                        .HasColumnType("real");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("BookOfReference.Models.Worker", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("DepartamentId")
                        .HasColumnType("integer");

                    b.Property<int>("Departament_Id")
                        .HasColumnType("integer");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Position_Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("BookOfReference.Models.Departament", b =>
                {
                    b.HasOne("BookOfReference.Models.Company", "Company")
                        .WithMany("Departaments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("BookOfReference.Models.Position", b =>
                {
                    b.HasOne("BookOfReference.Models.Worker", "Worker")
                        .WithMany("Positions")
                        .HasForeignKey("WorkerId");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("BookOfReference.Models.Salary", b =>
                {
                    b.HasOne("BookOfReference.Models.Position", "Position")
                        .WithMany("Salaries")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("BookOfReference.Models.Worker", b =>
                {
                    b.HasOne("BookOfReference.Models.Departament", "Departament")
                        .WithMany("Workers")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("BookOfReference.Models.Company", b =>
                {
                    b.Navigation("Departaments");
                });

            modelBuilder.Entity("BookOfReference.Models.Departament", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("BookOfReference.Models.Position", b =>
                {
                    b.Navigation("Salaries");
                });

            modelBuilder.Entity("BookOfReference.Models.Worker", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}