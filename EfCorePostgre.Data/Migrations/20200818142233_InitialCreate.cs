using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EfCorePostgre.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "permission",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_userId = table.Column<long>(nullable: false),
                    created_dateTime = table.Column<DateTime>(nullable: false),
                    updated_userId = table.Column<long>(nullable: true),
                    updated_dateTime = table.Column<DateTime>(nullable: true),
                    permission_typeId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_userId = table.Column<long>(nullable: false),
                    created_dateTime = table.Column<DateTime>(nullable: false),
                    updated_userId = table.Column<long>(nullable: true),
                    updated_dateTime = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    password = table.Column<string>(maxLength: 255, nullable: false),
                    password_salt = table.Column<string>(maxLength: 255, nullable: false),
                    is_passwordChangeFirstLogin = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_permission",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_userId = table.Column<long>(nullable: false),
                    created_dateTime = table.Column<DateTime>(nullable: false),
                    updated_userId = table.Column<long>(nullable: true),
                    updated_dateTime = table.Column<DateTime>(nullable: true),
                    user_id = table.Column<long>(nullable: false),
                    permission_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_permission_permission_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "public",
                        principalTable: "permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_permission_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    created_userId = table.Column<long>(nullable: false),
                    created_dateTime = table.Column<DateTime>(nullable: false),
                    updated_userId = table.Column<long>(nullable: true),
                    updated_dateTime = table.Column<DateTime>(nullable: true),
                    user_id = table.Column<long>(nullable: false),
                    role_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_role_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "permission",
                columns: new[] { "id", "created_dateTime", "created_userId", "description", "is_active", "is_deleted", "name", "permission_typeId", "updated_dateTime", "updated_userId" },
                values: new object[] { 1L, new DateTime(2020, 8, 18, 14, 22, 33, 244, DateTimeKind.Utc).AddTicks(3969), 0L, "Permission 1 Açıklaması", true, false, "Permission 1", 1, null, null });

            migrationBuilder.InsertData(
                schema: "public",
                table: "role",
                columns: new[] { "id", "created_dateTime", "created_userId", "description", "is_active", "is_deleted", "name", "updated_dateTime", "updated_userId" },
                values: new object[] { 1L, new DateTime(2020, 8, 18, 14, 22, 33, 242, DateTimeKind.Utc).AddTicks(9950), 0L, "Role 1 Açıklaması", true, false, "Role 1", null, null });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user",
                columns: new[] { "id", "email", "first_name", "is_active", "is_deleted", "is_passwordChangeFirstLogin", "last_name", "password", "password_salt" },
                values: new object[] { 1L, "admin@test.com", "Admin", true, false, true, "Admin", "KpkyZuPFMt/IZXatYgtN8scz+XU=", "0jPr9cdRgNguTizz9tGpU2rRbRfE3oXw0/HrsqZbXAXGq2lrsAUb1IqzJn5iHpbqoD9CW92jBimYFS8SJ6wStw==" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user_permission",
                columns: new[] { "id", "created_dateTime", "created_userId", "is_active", "is_deleted", "permission_id", "updated_dateTime", "updated_userId", "user_id" },
                values: new object[] { 1L, new DateTime(2020, 8, 18, 14, 22, 33, 249, DateTimeKind.Utc).AddTicks(5360), 0L, true, false, 1L, null, null, 1L });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user_role",
                columns: new[] { "id", "created_dateTime", "created_userId", "is_active", "is_deleted", "role_id", "updated_dateTime", "updated_userId", "user_id" },
                values: new object[] { 1L, new DateTime(2020, 8, 18, 14, 22, 33, 249, DateTimeKind.Utc).AddTicks(3950), 0L, true, false, 1L, null, null, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_user_permission_permission_id",
                schema: "public",
                table: "user_permission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_permission_user_id",
                schema: "public",
                table: "user_permission",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_role_id",
                schema: "public",
                table: "user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_user_id",
                schema: "public",
                table: "user_role",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_permission",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_role",
                schema: "public");

            migrationBuilder.DropTable(
                name: "permission",
                schema: "public");

            migrationBuilder.DropTable(
                name: "role",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user",
                schema: "public");
        }
    }
}
