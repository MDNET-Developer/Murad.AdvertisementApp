﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Murad.AdvertisementApp.DataAccsess.Context;

namespace Murad.AdvertisementApp.DataAccsess.Migrations
{
    [DbContext(typeof(AdvertisementContext))]
    partial class AdvertisementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AdvertisementAppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertisementAppUserStatusId")
                        .HasColumnType("int");

                    b.Property<int>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("CVPath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MilitaryStatusId")
                        .HasColumnType("int");

                    b.Property<int>("WorkExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementAppUserStatusId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("MilitaryStatusId");

                    b.HasIndex("AdvertisementId", "AppUserId")
                        .IsUnique();

                    b.ToTable("AdvertisementAppUsers");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AdvertisementAppUserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("AdvertisementAppUserStatuses");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Definition = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Definition = "Member"
                        });
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AppUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppRoleId");

                    b.HasIndex("AppUserId", "AppRoleId")
                        .IsUnique();

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.MilitaryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Definitions")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("MilitaryStatuses");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.ProvidedService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("ProvidedServices");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AdvertisementAppUser", b =>
                {
                    b.HasOne("Murad.AdvertisementApp.Entity.AdvertisementAppUserStatus", "AdvertisementAppUserStatus")
                        .WithMany("AdvertisementAppUsers")
                        .HasForeignKey("AdvertisementAppUserStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Murad.AdvertisementApp.Entity.Advertisement", "Advertisement")
                        .WithMany("AdvertisementAppUsers")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Murad.AdvertisementApp.Entity.AppUser", "AppUser")
                        .WithMany("AdvertisementAppUsers")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Murad.AdvertisementApp.Entity.MilitaryStatus", "MilitaryStatus")
                        .WithMany("AdvertisementAppUsers")
                        .HasForeignKey("MilitaryStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");

                    b.Navigation("AdvertisementAppUserStatus");

                    b.Navigation("AppUser");

                    b.Navigation("MilitaryStatus");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AppUser", b =>
                {
                    b.HasOne("Murad.AdvertisementApp.Entity.Gender", "Gender")
                        .WithMany("AppUsers")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AppUserRole", b =>
                {
                    b.HasOne("Murad.AdvertisementApp.Entity.AppRole", "AppRole")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Murad.AdvertisementApp.Entity.AppUser", "AppUser")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.Advertisement", b =>
                {
                    b.Navigation("AdvertisementAppUsers");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AdvertisementAppUserStatus", b =>
                {
                    b.Navigation("AdvertisementAppUsers");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AppRole", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.AppUser", b =>
                {
                    b.Navigation("AdvertisementAppUsers");

                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.Gender", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("Murad.AdvertisementApp.Entity.MilitaryStatus", b =>
                {
                    b.Navigation("AdvertisementAppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
