using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Catalyst.Domain.Entities;

namespace Catalyst.Web.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20161010055930_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Catalyst.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("PostalCode");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Catalyst.Domain.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Catalyst.Domain.Entities.Interests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Interest");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Catalyst.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<int>("Age");

                    b.Property<string>("FirstName");

                    b.Property<int?>("IconId");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("IconId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Catalyst.Domain.Entities.Interests", b =>
                {
                    b.HasOne("Catalyst.Domain.Entities.Person")
                        .WithMany("Interests")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Catalyst.Domain.Entities.Person", b =>
                {
                    b.HasOne("Catalyst.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Catalyst.Domain.Entities.Image", "Icon")
                        .WithMany()
                        .HasForeignKey("IconId");
                });
        }
    }
}
