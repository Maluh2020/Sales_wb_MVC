﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales_web_MVC.Data;

namespace Sales_web_MVC.Migrations
{
    [DbContext(typeof(Sales_web_MVCContext))]
    [Migration("20210115043757_OtherEntities")]
    partial class OtherEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sales_web_MVC.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Sales_web_MVC.Models.SalesRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("SellersId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("SellersId");

                    b.ToTable("SalesRecord");
                });

            modelBuilder.Entity("Sales_web_MVC.Models.Sellers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BaseSalary");

                    b.Property<DateTime>("BirthDate");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("Sales_web_MVC.Models.SalesRecord", b =>
                {
                    b.HasOne("Sales_web_MVC.Models.Sellers", "Sellers")
                        .WithMany("Sales")
                        .HasForeignKey("SellersId");
                });

            modelBuilder.Entity("Sales_web_MVC.Models.Sellers", b =>
                {
                    b.HasOne("Sales_web_MVC.Models.Department", "Department")
                        .WithMany("Sellers")
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
