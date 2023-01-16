﻿// <auto-generated />
using CafeWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeWebApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("CafeWebApi.Data.Breakfast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeDishId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TypeDishId");

                    b.ToTable("Breakfasts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Суп являются основным первым блюдом любого обеденного комплекса. Каждая кухня мира предлагает множество разнообразных рецептов, которые кардинально отличаются. Это позволяет не только насытить организм, но и разнообразить свой рацион, удовлетворив вкусовые предпочтения даже наиболее изысканных гурманов.",
                            Name = "Суп",
                            TypeDishId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Соус (в перевод с французского языка sauce означает «поливку») представляет собой дополнение к блюду/гарниру. С помощью него удается сделать блюдо более привлекательным и повысить его калорийность.",
                            Name = "Соус",
                            TypeDishId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Одним из наиболее любимых видов первых блюд большинства людей считается борщ.",
                            Name = "Борщ",
                            TypeDishId = 3
                        });
                });

            modelBuilder.Entity("CafeWebApi.Data.TypeDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TypesDish");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Мясной"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Сырный"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Зеленый"
                        });
                });

            modelBuilder.Entity("CafeWebApi.Data.Breakfast", b =>
                {
                    b.HasOne("CafeWebApi.Data.TypeDish", "TypeDish")
                        .WithMany()
                        .HasForeignKey("TypeDishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeDish");
                });
#pragma warning restore 612, 618
        }
    }
}
