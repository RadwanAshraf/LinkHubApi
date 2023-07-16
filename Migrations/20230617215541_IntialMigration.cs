using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LinkHubApi.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePic = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    Font = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    Style = table.Column<int>(type: "int", nullable: false),
                    Mode = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    FontColor = table.Column<string>(type: "VARCHAR(7)", maxLength: 7, nullable: true),
                    Background = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    AvatarID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountSettingsID = table.Column<int>(type: "int", nullable: false),
                    ProfileSettingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_ProfileSettings_ProfileSettingsId",
                        column: x => x.ProfileSettingsId,
                        principalTable: "ProfileSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SocialLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IconUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialLink_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProfileSettings",
                columns: new[] { "Id", "AvatarID", "Background", "Font", "FontColor", "Mode", "ProfilePic", "Style" },
                values: new object[,]
                {
                    { 1, 1, null, "Arial", "#521486", "Dark", null, 0 },
                    { 2, 2, null, "Arial", "#521486", "Blue", null, 0 },
                    { 3, 3, null, "Arial", "#521486", "White", null, 0 },
                    { 4, 4, null, "Arial", "#521486", "Purple ", null, 0 },
                    { 5, 5, null, "Arial", "#521486", "Red", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "About", "AccountSettingsID", "Birthday", "Email", "FName", "Gender", "JobTitle", "LName", "Location", "Password", "Phone", "ProfileSettingsId", "UserName" },
                values: new object[] { 1, null, 0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jdoe@example.com", "John", true, "Software Engineer", "Doe", "New York City", "P@ssw0rd", "555-555-5555", null, "jdoe" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "About", "AccountSettingsID", "Birthday", "Email", "FName", "JobTitle", "LName", "Location", "Password", "Phone", "ProfileSettingsId", "UserName" },
                values: new object[] { 2, null, 0, new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.doe@example.com", "Jane", "Product Manager", "Doe", "San Francisco", "P@ssw0rd", "555-555-5555", null, "jane.doe" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "About", "AccountSettingsID", "Birthday", "Email", "FName", "Gender", "JobTitle", "LName", "Location", "Password", "Phone", "ProfileSettingsId", "UserName" },
                values: new object[] { 3, null, 0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jdoe@example.com", "John", true, "Software Engineer", "Doe", "New York City", "P@ssw0rd", "555-555-5555", null, "jdoe" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "About", "AccountSettingsID", "Birthday", "Email", "FName", "JobTitle", "LName", "Location", "Password", "Phone", "ProfileSettingsId", "UserName" },
                values: new object[] { 4, null, 0, new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "janedoe@example.com", "Jane", "Product Manager", "Doe", "San Francisco", "P@ssw0rd", "555-555-5555", null, "janedoe" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "About", "AccountSettingsID", "Birthday", "Email", "FName", "Gender", "JobTitle", "LName", "Location", "Password", "Phone", "ProfileSettingsId", "UserName" },
                values: new object[] { 5, null, 0, new DateTime(1983, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "markjohnson@example.com", "Mark", true, "Marketing Manager", "Johnson", "Chicago", "P@ssw0rd", "555-555-5555", null, "markjohnson" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "About", "AccountSettingsID", "Birthday", "Email", "FName", "JobTitle", "LName", "Location", "Password", "Phone", "ProfileSettingsId", "UserName" },
                values: new object[] { 6, null, 0, new DateTime(1992, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "emilychen@example.com", "Emily", "Sales Representative", "Chen", "Los Angeles", "P@ssw0rd", "555-555-5555", null, "emilychen" });

            migrationBuilder.InsertData(
                table: "SocialLink",
                columns: new[] { "Id", "IconUrl", "IsActive", "LinkUrl", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "https://www.facebook.com/favicon.ico", true, "https://www.facebook.com/johndoe", 3, 1 },
                    { 2, "https://twitter.com/favicon.ico", true, "https://twitter.com/johndoe", 2, 1 },
                    { 3, "https://www.linkedin.com/favicon.ico", true, "https://www.linkedin.com/in/johndoe", 0, 1 },
                    { 4, "https://www.facebook.com/favicon.ico", true, "https://www.facebook.com/janedoe", 3, 2 },
                    { 5, "https://twitter.com/favicon.ico", false, "https://twitter.com/janedoe", 2, 2 },
                    { 6, "https://www.linkedin.com/favicon.ico", true, "https://www.linkedin.com/in/janedoe", 0, 3 },
                    { 7, "https://www.facebook.com/favicon.ico", true, "https://www.facebook.com/johndoe", 3, 3 },
                    { 8, "https://twitter.com/favicon.ico", true, "https://twitter.com/johndoe", 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialLink_UserId",
                table: "SocialLink",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileSettingsId",
                table: "User",
                column: "ProfileSettingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialLink");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProfileSettings");
        }
    }
}
