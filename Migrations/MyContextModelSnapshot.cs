using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Models;

namespace netcoreef.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Models.ExtendField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CreateTime");

                    b.Property<string>("Field")
                        .HasMaxLength(30);

                    b.Property<string>("Key")
                        .HasMaxLength(50);

                    b.Property<string>("Model")
                        .HasMaxLength(20);

                    b.Property<string>("Value")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.ToTable("ExtendField");
                });

            modelBuilder.Entity("Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Key")
                        .HasMaxLength(100);

                    b.Property<string>("Value")
                        .HasMaxLength(512);

                    b.HasKey("Id");

                    b.ToTable("Setting");
                });
        }
    }
}
