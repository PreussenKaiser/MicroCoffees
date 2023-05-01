﻿// <auto-generated />
using System;
using MicroCoffees.Coffees.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicroCoffees.Coffees.Infrastructure.Migrations
{
    [DbContext(typeof(CoffeeContext))]
    partial class CoffeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate.Coffee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Roast")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Coffees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("04f5e8e1-da22-4757-9627-dcba35f20ee9"),
                            Cost = 7.99m,
                            ImageUrl = "https://th.bing.com/th/id/OIP.CloEEL0cB_QDXljC3abB5gHaE8?pid=ImgDet&rs=1",
                            Name = "Generic Coffee",
                            Quantity = 1,
                            Roast = 0
                        },
                        new
                        {
                            Id = new Guid("dedd14bb-e9b0-478f-829d-aa5d3ad872f2"),
                            Cost = 12.99m,
                            ImageUrl = "https://th.bing.com/th/id/OIP.0ADp4_DH5Lew45ZJCnJe7QHaFg?pid=ImgDet&rs=1",
                            Name = "The Breakpoint",
                            Quantity = 3,
                            Roast = 2
                        },
                        new
                        {
                            Id = new Guid("a404a34a-80f3-4c6c-8c88-9cd575a233e0"),
                            Cost = 9.99m,
                            ImageUrl = "https://th.bing.com/th/id/R.7c4b342409966068c7bb98219985480d?rik=S2kiujZKPRxB0g&riu=http%3a%2f%2f1.bp.blogspot.com%2f-1r-vd0CSMHw%2fThYLo7LSlFI%2fAAAAAAAAEXc%2fqNnSu3O6ofg%2fs1600%2fcoffee9.JPG&ehk=8SFWv%2fVEwHRDPMNZVRKhuQSSsTRK3U0%2fRHlPr5rLEys%3d&risl=&pid=ImgRaw&r=0",
                            Name = "Monad Monster",
                            Quantity = 2,
                            Roast = 1
                        },
                        new
                        {
                            Id = new Guid("55f8d8f3-517f-4c60-9eb8-d2626bdf9d65"),
                            Cost = 0.99m,
                            ImageUrl = "https://thumbs.dreamstime.com/b/fire-hot-coffee-white-cup-33390113.jpg",
                            Name = "Null Reference Exception",
                            Quantity = 6,
                            Roast = 2
                        },
                        new
                        {
                            Id = new Guid("6cd81e45-8ab2-46ac-9581-015c3b3edbed"),
                            Cost = 14.99m,
                            ImageUrl = "https://thumbs.dreamstime.com/z/coffee-ornate-china-cup-8144721.jpg",
                            Name = "The Oriental Object",
                            Quantity = 1,
                            Roast = 1
                        },
                        new
                        {
                            Id = new Guid("24826eab-bb54-4a8a-987f-a91fbbd807e4"),
                            Cost = 19.99m,
                            ImageUrl = "https://th.bing.com/th/id/OIF.sixOhvNquXnii2EqLJhfZw?pid=ImgDet&rs=1",
                            Name = "Function, Oriented",
                            Quantity = 2,
                            Roast = 0
                        },
                        new
                        {
                            Id = new Guid("952485a9-8597-4812-88c5-732cb8947eef"),
                            Cost = 4.99m,
                            ImageUrl = "https://c2.staticflickr.com/8/7087/7213400040_8a548668d6_b.jpg",
                            Name = "Integer Overflow",
                            Quantity = 5,
                            Roast = 0
                        },
                        new
                        {
                            Id = new Guid("ad5cc35a-cd71-4b34-8e29-0a87f9356dd4"),
                            Cost = 31.99m,
                            ImageUrl = "",
                            Name = "Line 32",
                            Quantity = 3,
                            Roast = 0
                        },
                        new
                        {
                            Id = new Guid("2fded802-eae5-4227-9cb0-09ce0b47315c"),
                            Cost = 2.99m,
                            ImageUrl = "",
                            Name = "AbstractCoffeeFactorySingleton",
                            Quantity = 2,
                            Roast = 1
                        },
                        new
                        {
                            Id = new Guid("5ca784a3-04a0-4f71-b451-e7a736b457d4"),
                            Cost = 99.99m,
                            ImageUrl = "",
                            Name = "Imposter Syndrome",
                            Quantity = 1,
                            Roast = 2
                        },
                        new
                        {
                            Id = new Guid("618f71cd-a4e4-4c02-9014-0e5cb38bee06"),
                            Cost = 9.99m,
                            ImageUrl = "",
                            Name = "10x Coffee",
                            Quantity = 1,
                            Roast = 0
                        },
                        new
                        {
                            Id = new Guid("1d333d93-7628-4732-813d-adcab72aac69"),
                            Cost = 7.99m,
                            ImageUrl = "",
                            Name = "Eight Bitter",
                            Quantity = 8,
                            Roast = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
