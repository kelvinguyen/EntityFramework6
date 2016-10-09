using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GitHub.WebApplication.Entity.DataContext;

namespace GitHub.WebApplication.Migrations
{
    [DbContext(typeof(PersonContext))]
    partial class PersonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GitHub.WebApplication.Entity.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int?>("PersonId");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<int>("Zipcode");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("GitHub.WebApplication.Entity.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("GitHub.WebApplication.Entity.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InterestContent");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("GitHub.WebApplication.Entity.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<int>("ImageId");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("GitHub.WebApplication.Entity.Models.Address", b =>
                {
                    b.HasOne("GitHub.WebApplication.Entity.Models.Person", "Person")
                        .WithMany("AddressList")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("GitHub.WebApplication.Entity.Models.Interest", b =>
                {
                    b.HasOne("GitHub.WebApplication.Entity.Models.Person", "Person")
                        .WithMany("InterestList")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("GitHub.WebApplication.Entity.Models.Person", b =>
                {
                    b.HasOne("GitHub.WebApplication.Entity.Models.Image", "Image")
                        .WithOne("Person")
                        .HasForeignKey("GitHub.WebApplication.Entity.Models.Person", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
