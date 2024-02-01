using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Shop_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class BookShoopDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteBook",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBook", x => x.FavoriteId);
                });

            migrationBuilder.CreateTable(
                name: "TypeBook",
                columns: table => new
                {
                    TypeBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    bookType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBook", x => x.TypeBookId);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Usertype = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationDayAvaible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.CheckConstraint("CH_Quantity", "Quantity >=1 ");
                    table.ForeignKey(
                        name: "FK_Book_TypeBook_TypeBookId",
                        column: x => x.TypeBookId,
                        principalTable: "TypeBook",
                        principalColumn: "TypeBookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false, defaultValue: 18),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specilization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.CheckConstraint("CH_User_Age", "Age>= 18");
                    table.CheckConstraint("CH_User_Email", "EMAIL LIKE '%@___%.COM'");
                    table.CheckConstraint("CH_User_Phone", "Phone LIKE '9627________'");
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subsecription",
                columns: table => new
                {
                    SubsecriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubsecriptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubsecriptionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubsecriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationDay = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "02/01/2024 14:43:22"),
                    DownloadBookAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false, defaultValue: 30f),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsecription", x => x.SubsecriptionId);
                    table.CheckConstraint("CH_DownloadBookAmount", "DownloadBookAmount >=1");
                    table.ForeignKey(
                        name: "FK_Subsecription_User_AdminId",
                        column: x => x.AdminId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsecription_User_ClientId",
                        column: x => x.ClientId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsecription_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSubsecription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubsecriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerialNumberSubsecription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubsecriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubsecription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubsecription_Subsecription_SubsecriptionId",
                        column: x => x.SubsecriptionId,
                        principalTable: "Subsecription",
                        principalColumn: "SubsecriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubsecription_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Quantity",
                table: "Book",
                column: "Quantity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_TypeBookId",
                table: "Book",
                column: "TypeBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsecription_AdminId",
                table: "Subsecription",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsecription_ClientId",
                table: "Subsecription",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsecription_EmployeeId",
                table: "Subsecription",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Phone",
                table: "User",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                table: "User",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubsecription_SubsecriptionId",
                table: "UserSubsecription",
                column: "SubsecriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubsecription_UserId",
                table: "UserSubsecription",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "FavoriteBook");

            migrationBuilder.DropTable(
                name: "UserSubsecription");

            migrationBuilder.DropTable(
                name: "TypeBook");

            migrationBuilder.DropTable(
                name: "Subsecription");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
