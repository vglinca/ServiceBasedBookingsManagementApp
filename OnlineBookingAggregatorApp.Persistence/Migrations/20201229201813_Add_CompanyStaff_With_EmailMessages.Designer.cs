﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201229201813_Add_CompanyStaff_With_EmailMessages")]
    partial class Add_CompanyStaff_With_EmailMessages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.UserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.UserToken", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Client.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Client.Warrant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClientCustomName")
                        .HasColumnType("text");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Warrants");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CompanyType")
                        .HasColumnName("CompanyTypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<string>("Iban")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("OfficeSpaceArea")
                        .HasColumnType("double precision");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyType");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.CompanySpecialist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("SpecialistId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SpecialistId");

                    b.ToTable("CompanySpecialists");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.CompanyStaff", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyUsers");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.CompanyStaffService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CompanyStaffId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyStaffId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CompanyStaffServices");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.EmailMessage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("bytea");

                    b.Property<long>("CompanyStaffId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("From")
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyStaffId");

                    b.ToTable("EmailMessages");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<long>("ServiceType")
                        .HasColumnName("ServiceTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("SubType")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("WorkDays")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ServiceType");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.ServiceSpecialist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<long>("SpecialistId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("SpecialistId");

                    b.ToTable("ServiceSpecialists");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Lookup.AuthorizeRoleEntity", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("AuthorizeRoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("AuthorizeRoles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "System Administrator"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Company User"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Plain User"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Limited in actions User"
                        });
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Lookup.CompanyTypeEntity", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("CompanyTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("CompanyTypes");

                    b.HasData(
                        new
                        {
                            Id = 0L,
                            Name = "Juridical Person"
                        },
                        new
                        {
                            Id = 1L,
                            Name = "Physical Person"
                        });
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Lookup.ServiceTypeEntity", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("ServiceTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");

                    b.HasData(
                        new
                        {
                            Id = 0L,
                            Name = "Everyday Service"
                        },
                        new
                        {
                            Id = 1L,
                            Name = "Informational Service"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Medical Service"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Commercial Service"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Hotel Service"
                        });
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.Company", null)
                        .WithMany("Specialists")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.RoleClaim", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.UserClaim", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.UserLogin", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.UserRole", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Auth.UserToken", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Client.Review", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", "Client")
                        .WithMany("Reviews")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.Service", "Service")
                        .WithMany("Reviews")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Client.Warrant", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", "Client")
                        .WithMany("Warrants")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.Service", "Service")
                        .WithMany("Warrants")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.Company", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Lookup.CompanyTypeEntity", null)
                        .WithMany()
                        .HasForeignKey("CompanyType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.CompanySpecialist", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.Company", "Company")
                        .WithMany("CompanySpecialists")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", "Specialist")
                        .WithMany("CompanySpecialists")
                        .HasForeignKey("SpecialistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.CompanyStaff", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.Company", "Company")
                        .WithMany("CompanyUsers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.CompanyStaffService", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.CompanyStaff", "CompanyStaff")
                        .WithMany("CompanyStaffServices")
                        .HasForeignKey("CompanyStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.Service", "Service")
                        .WithMany("CompanyStaffServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.EmailMessage", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.CompanyStaff", null)
                        .WithMany("EmailMessages")
                        .HasForeignKey("CompanyStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.Service", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.Company", "Company")
                        .WithMany("Services")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Lookup.ServiceTypeEntity", null)
                        .WithMany()
                        .HasForeignKey("ServiceType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookingAggregatorApp.Domain.Entities.Company.ServiceSpecialist", b =>
                {
                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Company.Service", "Service")
                        .WithMany("ServiceSpecialists")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookingAggregatorApp.Domain.Entities.Auth.ApplicationUser", "Specialist")
                        .WithMany("ServiceSpecialists")
                        .HasForeignKey("SpecialistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
