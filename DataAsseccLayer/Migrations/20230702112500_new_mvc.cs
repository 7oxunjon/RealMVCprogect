using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAsseccLayer.Migrations
{
    /// <inheritdoc />
    public partial class new_mvc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AboutDetals1 = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AboutDetals2 = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AboutImeg1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AboutImeg2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abouts", x => x.AboutId);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdminName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AdminPassword = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AdminRole = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CotegoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CotegoryName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CotegoryDescription = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CotegoryStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CotegoryId);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserMail = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Contect_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YuboruvchiMail = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Qabul_qiluvchiMail = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    MessageContent = table.Column<string>(type: "text", nullable: false),
                    MessageDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "writers",
                columns: table => new
                {
                    WriterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WriterName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WriterSurname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WriterImaged = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    WriterAbout = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WriterEmail = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    WriterTitle = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WriterStatus = table.Column<bool>(type: "boolean", nullable: false),
                    WriterPaswword = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_writers", x => x.WriterId);
                });

            migrationBuilder.CreateTable(
                name: "headings",
                columns: table => new
                {
                    HeadingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeadingName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HeadingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Headingstatus = table.Column<bool>(type: "boolean", nullable: false),
                    CotegoryId = table.Column<int>(type: "integer", nullable: false),
                    WriterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_headings", x => x.HeadingId);
                    table.ForeignKey(
                        name: "FK_headings_categories_CotegoryId",
                        column: x => x.CotegoryId,
                        principalTable: "categories",
                        principalColumn: "CotegoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_headings_writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contents",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContentValue = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ContentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContentStatus = table.Column<bool>(type: "boolean", nullable: false),
                    HeadingId = table.Column<int>(type: "integer", nullable: false),
                    WriterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contents", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_contents_headings_HeadingId",
                        column: x => x.HeadingId,
                        principalTable: "headings",
                        principalColumn: "HeadingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contents_writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contents_HeadingId",
                table: "contents",
                column: "HeadingId");

            migrationBuilder.CreateIndex(
                name: "IX_contents_WriterId",
                table: "contents",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_headings_CotegoryId",
                table: "headings",
                column: "CotegoryId");

            migrationBuilder.CreateIndex(
                name: "IX_headings_WriterId",
                table: "headings",
                column: "WriterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abouts");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "contents");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "headings");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "writers");
        }
    }
}
