﻿// <auto-generated />
using System;
using BlazorDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorDemo.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230123062846_Initial-Commit")]
    partial class InitialCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("BlazorDemo.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("author")
                        .HasColumnType("TEXT");

                    b.Property<string>("tag")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.Property<string>("updated_by")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            author = "越川慎司",
                            tag = "IT",
                            title = "AI分析でわかった トップ5％社員",
                            updatedby = "Yamada",
                            updateddate = new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 1002,
                            author = "小川 雄太郎 ",
                            tag = "IT",
                            title = "つくりながら学ぶ！PyTorchによる発展ディープラーニング",
                            updatedby = "Yamada",
                            updateddate = new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
