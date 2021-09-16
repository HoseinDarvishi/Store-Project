using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceHost.Migrations.Blog
{
    public partial class AddingArticleCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ShowOrder = table.Column<int>(type: "int", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    KeyWords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CanonicalAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");
        }
    }
}
