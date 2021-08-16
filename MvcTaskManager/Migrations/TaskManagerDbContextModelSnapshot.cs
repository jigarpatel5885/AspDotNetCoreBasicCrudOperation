﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcTaskManager.Models;

namespace MvcTaskManager.Migrations
{
    [DbContext(typeof(TaskManagerDbContext))]
    partial class TaskManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcTaskManager.Models.Project", b =>
                {
                    b.Property<int>("ProjectID");

                    b.Property<DateTime>("DateOfStart");

                    b.Property<string>("ProjectName");

                    b.Property<int>("TeamSize");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}