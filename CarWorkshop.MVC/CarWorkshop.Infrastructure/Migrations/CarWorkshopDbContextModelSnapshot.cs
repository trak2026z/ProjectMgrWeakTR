using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using CarWorkshop.Infrastructure.Persistence;

#nullable disable

namespace CarWorkshop.Infrastructure.Migrations
{
    [DbContext(typeof(CarWorkshopDbContext))]
    partial class CarWorkshopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Npgsql:ValueGenerationStrategy", 
                               Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CarWorkshop.Domain.Entities.CarWorkshop", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Description")
                    .HasColumnType("text");

                b.Property<DateTime>("CreatedAt")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("ContactDetails_PhoneNumber")
                    .HasColumnType("text");

                b.Property<string>("ContactDetails_Street")
                    .HasColumnType("text");

                b.Property<string>("ContactDetails_City")
                    .HasColumnType("text");

                b.Property<string>("ContactDetails_PostalCode")
                    .HasColumnType("text");

                b.Property<string>("EncodedName")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("CarWorkshops");
            });
        }
    }
}
