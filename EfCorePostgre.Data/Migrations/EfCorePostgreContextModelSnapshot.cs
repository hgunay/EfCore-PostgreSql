﻿// <auto-generated />
using System;
using EfCorePostgre.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EfCorePostgre.Data.Migrations
{
    [DbContext(typeof(EfCorePostgreContext))]
    partial class EfCorePostgreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EfCorePostgre.Data.Domain.Public.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnName("created_dateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnName("created_userId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<int>("PermissionTypeId")
                        .HasColumnName("permission_typeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnName("updated_dateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnName("updated_userId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("permission","public");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDateTime = new DateTime(2020, 8, 13, 21, 52, 9, 910, DateTimeKind.Utc).AddTicks(2878),
                            CreatedUserId = 0L,
                            Description = "Permission 1 Açıklaması",
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Permission 1",
                            PermissionTypeId = 1
                        });
                });

            modelBuilder.Entity("EfCorePostgre.Data.Domain.Public.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnName("created_dateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnName("created_userId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnName("updated_dateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnName("updated_userId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("role","public");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDateTime = new DateTime(2020, 8, 13, 21, 52, 9, 909, DateTimeKind.Utc).AddTicks(3731),
                            CreatedUserId = 0L,
                            Description = "Role 1 Açıklaması",
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Role 1"
                        });
                });

            modelBuilder.Entity("EfCorePostgre.Data.Domain.Public.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsPasswordChangeFirstLogin")
                        .HasColumnName("is_passwordChangeFirstLogin")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("password_salt")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("user","public");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "admin@test.com",
                            FirstName = "Admin",
                            IsActive = true,
                            IsDeleted = false,
                            IsPasswordChangeFirstLogin = true,
                            LastName = "Admin",
                            Password = "Admin123",
                            PasswordSalt = "Admin123"
                        });
                });

            modelBuilder.Entity("EfCorePostgre.Data.Domain.Public.UserPermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnName("created_dateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnName("created_userId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<long>("PermissionId")
                        .HasColumnName("permission_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnName("updated_dateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnName("updated_userId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("user_permission","public");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDateTime = new DateTime(2020, 8, 13, 21, 52, 9, 910, DateTimeKind.Utc).AddTicks(6777),
                            CreatedUserId = 0L,
                            IsActive = true,
                            IsDeleted = false,
                            PermissionId = 1L,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("EfCorePostgre.Data.Domain.Public.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnName("created_dateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnName("created_userId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnName("updated_dateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnName("updated_userId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("user_role","public");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDateTime = new DateTime(2020, 8, 13, 21, 52, 9, 910, DateTimeKind.Utc).AddTicks(5894),
                            CreatedUserId = 0L,
                            IsActive = true,
                            IsDeleted = false,
                            RoleId = 1L,
                            UserId = 1L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
