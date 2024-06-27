using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAO.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Discriminator = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    points = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ColorCode = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Reference = table.Column<string>(type: "longtext", nullable: false),
                    Method = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    CommandStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commands_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    InitialPrice = table.Column<int>(type: "int", nullable: false),
                    CurrentPrice = table.Column<int>(type: "int", nullable: false),
                    IsUsed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Favoris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoris_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoris_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CommandId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Commands_CommandId",
                        column: x => x.CommandId,
                        principalTable: "Commands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductColorRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColorRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColorRelations_ProductColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "ProductColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColorRelations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageData = table.Column<byte[]>(type: "longblob", nullable: true),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "ADMIN", "ADMIN" },
                    { "2", null, "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IPHONE" },
                    { 2, "MAC" },
                    { 3, "AppleWATCH" }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "ColorCode", "Name" },
                values: new object[,]
                {
                    { 1, "#808080", "Gris sidéral" },
                    { 2, "#C0C0C0", "Argent" },
                    { 3, "#FFD700", "Or" },
                    { 4, "#008000", "Vert" },
                    { 5, "#0000FF", "Bleu" },
                    { 6, "#FFC0CB", "Rose" },
                    { 7, "#800080", "Violet" },
                    { 8, "#FF0000", "Rouge" },
                    { 9, "#000000", "Blanc" },
                    { 10, "#FFFFFF", "Noir" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CurrentPrice", "Description", "InitialPrice", "IsUsed", "Name", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, 1250, "RAM: 2 Go\n*Stockage: 64 Go\n*Appareil photo: 12 MP\n*Écran: 4,7 pouces", 1250, false, "iPhone 8", 10 },
                    { 2, 1, 1625, "RAM: 3 Go\n*Stockage: 64 Go ou 256 Go\n*Appareil photo: Double 12 MP\n*Écran: 5,5 pouces", 1625, false, "iPhone 8 Plus", 10 },
                    { 3, 1, 2000, "RAM: 3 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 5,8 pouces", 2000, false, "iPhone X", 10 },
                    { 4, 1, 1750, "RAM: 3 Go\n*Stockage: 64 Go, 128 Go, ou 256 Go\n*Appareil photo: Simple 12 MP\n*Écran: 6,1 pouces", 1750, false, "iPhone XR", 10 },
                    { 5, 1, 2250, "RAM: 4 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 5,8 pouces", 2250, false, "iPhone XS", 10 },
                    { 6, 1, 2500, "RAM: 4 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,5 pouces", 2500, false, "iPhone XS Max", 10 },
                    { 7, 1, 1875, "RAM: 4 Go\n*Stockage: 64 Go, 128 Go, ou 256 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", 1875, false, "iPhone 11", 10 },
                    { 8, 1, 2500, "RAM: 4 Go ou 6 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 5,8 pouces", 2500, false, "iPhone 11 Pro", 10 },
                    { 9, 1, 2650, "RAM: 4 Go ou 6 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,5 pouces", 2650, false, "iPhone 11 Pro Max", 10 },
                    { 10, 1, 2000, "RAM: 4 Go\n*Stockage: 64 Go, 128 Go, ou 256 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", 2000, false, "iPhone 12", 10 },
                    { 11, 1, 2750, "RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,1 pouces", 2750, false, "iPhone 12 Pro", 10 },
                    { 12, 1, 3000, "RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,7 pouces", 3000, false, "iPhone 12 Pro Max", 10 },
                    { 13, 1, 2125, "RAM: 4 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", 2125, false, "iPhone 13", 10 },
                    { 14, 1, 2875, "RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,1 pouces", 2875, false, "iPhone 13 Pro", 10 },
                    { 15, 1, 3125, "RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,7 pouces", 3125, false, "iPhone 13 Pro Max", 10 },
                    { 16, 2, 2497, "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,3 pouces", 2497, false, "MacBook Air", 10 },
                    { 17, 2, 3247, "Processeur: Chip M1 Pro ou M1 Max\n*RAM: 16 Go, 32 Go, ou 64 Go\n*Stockage: 256 Go, 512 Go, 1 To, 2 To, ou 4 To\n*Écran: 13,3 pouces ou 16 pouces", 3247, false, "MacBook Pro", 10 },
                    { 18, 3, 997, "Processeur: S7\n*Écran: Always-On Retina LTPO OLED\n*Batterie: Jusqu'à 36 heures", 997, false, "Apple Watch Series 7", 10 },
                    { 19, 3, 697, "Processeur: S5\n*Écran: Retina OLED\n*Batterie: Jusqu'à 18 heures", 697, false, "Apple Watch SE", 10 },
                    { 20, 3, 422, "Processeur: S3\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures", 422, false, "Apple Watch Series 3", 10 },
                    { 21, 2, 1497, "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: Intégré de 7 pouces LED", 1497, false, "Mac mini", 10 },
                    { 22, 2, 2747, "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 21,5 pouces ou 27 pouces", 2747, false, "iMac", 10 },
                    { 23, 2, 4997, "Processeur: Chip M1 Ultra ou M1 Max\n*RAM: 32 Go, 64 Go, ou 128 Go\n*Stockage: 512 Go, 1 To, 2 To, 4 To, ou 8 To\n*Écran: Intégré de 5,5 pouces Liquid Retina XDR", 4997, false, "Mac Studio", 10 },
                    { 24, 2, 7497, "Processeur: Chip M1 Pro ou M1 Max\n*RAM: 32 Go, 64 Go, ou 128 Go\n*Stockage: Personnalisable\n*Écran: Intégré de 5,5 pouces Liquid Retina XDR", 7497, false, "Mac Pro", 10 },
                    { 25, 2, 3247, "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,3 pouces", 3247, false, "MacBook Pro 13 pouces", 10 },
                    { 26, 2, 4997, "Processeur: Chip M1 Pro ou M1 Max\n*RAM: 16 Go, 32 Go, ou 64 Go\n*Stockage: 512 Go, 1 To, 2 To, 4 To, ou 8 To\n*Écran: 14,2 pouces", 4997, false, "MacBook Pro 14 pouces", 10 },
                    { 27, 2, 6247, "Processeur: Chip M1 Pro ou M1 Max\n*RAM: 16 Go, 32 Go, ou 64 Go\n*Stockage: 512 Go, 1 To, 2 To, 4 To, ou 8 To\n*Écran: 16,2 pouces", 6247, false, "MacBook Pro 16 pouces", 10 },
                    { 28, 2, 2497, "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,3 pouces", 2497, false, "MacBook Air M1", 10 },
                    { 29, 2, 2997, "Processeur: Chip M2\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,6 pouces", 2997, false, "MacBook Air M2", 10 },
                    { 30, 2, 3747, "Processeur: Chip M2\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,3 pouces", 3747, false, "MacBook Pro 13 pouces M2", 10 },
                    { 31, 3, 997, "Processeur: S6\n*Écran: Always-On Retina LTPO OLED\n*Batterie: Jusqu'à 18 heures", 997, false, "Apple Watch Series 6", 10 },
                    { 32, 3, 822, "Processeur: S5\n*Écran: Always-On Retina OLED\n*Batterie: Jusqu'à 18 heures", 822, false, "Apple Watch Series 5", 10 },
                    { 33, 3, 622, "Processeur: S4\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures", 622, false, "Apple Watch Series 4", 10 },
                    { 34, 3, 747, "Processeur: S3\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures\n*Cellulaire LTE", 747, false, "Apple Watch Series 3 LTE", 10 },
                    { 35, 3, 697, "Processeur: S5\n*Écran: Retina OLED\n*Batterie: Jusqu'à 30 heures", 697, false, "Apple Watch SE (2ème génération)", 10 },
                    { 36, 3, 997, "Processeur: S5\n*Écran: Always-On Retina OLED\n*Batterie: Jusqu'à 18 heures", 997, false, "Apple Watch Nike", 10 },
                    { 37, 3, 2747, "Processeur: S5\n*Écran: Always-On Retina OLED\n*Batterie: Jusqu'à 18 heures", 2747, false, "Apple Watch Hermès", 10 },
                    { 38, 3, 3997, "Processeur: S5\n*Écran: Always-On Retina OLED\n*Batterie: Jusqu'à 18 heures\n*Matériau: Or 18 carats", 3997, false, "Apple Watch Edition", 10 },
                    { 39, 3, 497, "Processeur: S1\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures", 497, false, "Apple Watch SE (1ère génération)", 10 },
                    { 40, 3, 372, "Processeur: S1\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures", 372, false, "Apple Watch Series 1", 10 },
                    { 41, 1, 1997, "Processeur: A15 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", 1997, false, "iPhone 14", 10 },
                    { 42, 1, 2497, "Processeur: A16 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,1 pouces", 2497, false, "iPhone 14 Pro", 10 },
                    { 43, 1, 2747, "Processeur: A16 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,7 pouces", 2747, false, "iPhone 14 Pro Max", 10 },
                    { 44, 1, 2247, "Processeur: A17 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", 2247, false, "iPhone 15", 10 },
                    { 45, 1, 2747, "Processeur: A18 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,1 pouces", 2747, false, "iPhone 15 Pro", 10 },
                    { 46, 1, 2997, "Processeur: A18 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,7 pouces", 2997, false, "iPhone 15 Pro Max", 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductColorRelations",
                columns: new[] { "Id", "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 5, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 },
                    { 6, 3, 2 },
                    { 7, 1, 3 },
                    { 8, 2, 3 },
                    { 9, 6, 3 },
                    { 10, 5, 4 },
                    { 11, 7, 4 },
                    { 12, 8, 4 },
                    { 13, 1, 5 },
                    { 14, 2, 5 },
                    { 15, 3, 5 },
                    { 16, 1, 6 },
                    { 17, 2, 6 },
                    { 18, 3, 6 },
                    { 19, 4, 7 },
                    { 20, 5, 7 },
                    { 21, 8, 7 },
                    { 22, 1, 8 },
                    { 23, 2, 8 },
                    { 24, 3, 8 },
                    { 25, 1, 9 },
                    { 26, 2, 9 },
                    { 27, 3, 9 },
                    { 28, 1, 10 },
                    { 29, 2, 10 },
                    { 30, 8, 10 },
                    { 31, 1, 11 },
                    { 32, 2, 11 },
                    { 33, 3, 11 },
                    { 34, 1, 12 },
                    { 35, 2, 12 },
                    { 36, 3, 12 },
                    { 37, 4, 13 },
                    { 38, 5, 13 },
                    { 39, 8, 13 },
                    { 40, 1, 14 },
                    { 41, 2, 14 },
                    { 42, 3, 14 },
                    { 43, 1, 15 },
                    { 44, 2, 15 },
                    { 45, 3, 15 },
                    { 46, 1, 16 },
                    { 47, 2, 16 },
                    { 48, 5, 16 },
                    { 49, 1, 17 },
                    { 50, 2, 17 },
                    { 51, 5, 17 },
                    { 52, 1, 18 },
                    { 53, 2, 18 },
                    { 54, 6, 18 },
                    { 55, 1, 19 },
                    { 56, 2, 19 },
                    { 57, 6, 19 },
                    { 58, 1, 20 },
                    { 59, 2, 20 },
                    { 60, 5, 20 },
                    { 61, 1, 21 },
                    { 62, 2, 21 },
                    { 63, 5, 21 },
                    { 64, 1, 22 },
                    { 65, 2, 22 },
                    { 66, 5, 22 },
                    { 67, 1, 23 },
                    { 68, 2, 23 },
                    { 69, 5, 23 },
                    { 70, 1, 24 },
                    { 71, 2, 24 },
                    { 72, 5, 24 },
                    { 73, 1, 25 },
                    { 74, 2, 25 },
                    { 75, 6, 25 },
                    { 76, 1, 26 },
                    { 77, 2, 26 },
                    { 78, 6, 26 },
                    { 79, 1, 27 },
                    { 80, 2, 27 },
                    { 81, 6, 27 },
                    { 82, 1, 28 },
                    { 83, 2, 28 },
                    { 84, 6, 28 },
                    { 85, 1, 29 },
                    { 86, 2, 29 },
                    { 87, 5, 29 },
                    { 88, 1, 30 },
                    { 89, 2, 30 },
                    { 90, 5, 30 },
                    { 91, 1, 31 },
                    { 92, 2, 31 },
                    { 93, 5, 31 },
                    { 94, 1, 32 },
                    { 95, 2, 32 },
                    { 96, 5, 32 },
                    { 97, 1, 33 },
                    { 98, 2, 33 },
                    { 99, 5, 33 },
                    { 100, 1, 34 },
                    { 101, 2, 34 },
                    { 102, 6, 34 },
                    { 103, 1, 35 },
                    { 104, 2, 35 },
                    { 105, 6, 35 },
                    { 106, 1, 36 },
                    { 107, 2, 36 },
                    { 108, 6, 36 },
                    { 109, 1, 37 },
                    { 110, 2, 37 },
                    { 111, 6, 37 },
                    { 112, 1, 38 },
                    { 113, 2, 38 },
                    { 114, 6, 38 },
                    { 115, 1, 39 },
                    { 116, 2, 39 },
                    { 117, 6, 39 },
                    { 118, 1, 40 },
                    { 119, 2, 40 },
                    { 120, 6, 40 },
                    { 121, 3, 41 },
                    { 122, 4, 41 },
                    { 123, 7, 41 },
                    { 124, 3, 42 },
                    { 125, 4, 42 },
                    { 126, 7, 42 },
                    { 127, 3, 43 },
                    { 128, 4, 43 },
                    { 129, 7, 43 },
                    { 130, 3, 44 },
                    { 131, 4, 44 },
                    { 132, 7, 44 },
                    { 133, 3, 45 },
                    { 134, 4, 45 },
                    { 135, 7, 45 },
                    { 136, 3, 46 },
                    { 137, 4, 46 },
                    { 138, 7, 46 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageData", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 75, null, "https://www.verizon.com/about/sites/default/files/news-media/1-iPhone8%20Hero%20Image%201280x720.jpg", 1 },
                    { 76, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2Su2dF_uVR6gxMqGTwF5oNqfC-nNbNr1FPA&s", 1 },
                    { 77, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSVS0yWHhpnJwXXD97yeIk3HLxmZ5KmX2dbA&s", 1 },
                    { 78, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxOvmabrpeSSURrxlDWgaPZiYzyOymaotQfg&s", 2 },
                    { 79, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZfi2tJGMRmyidpMge5igBYVyfXP9jKext0g&s", 2 },
                    { 80, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVMn3tliykuwEUu2cG1ySZWR_scQC78AOSoQ&s", 2 },
                    { 81, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQFML6WTAfSUh9_iNMyPTIu4vSPs5MMAxqFLQ&s", 4 },
                    { 82, null, "https://www.zeekonline.co.za/cdn/shop/products/2715_grande.jpg?v=1558796283", 4 },
                    { 83, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1ZU0mSC30v87rsIBETV08b_A7djxvFB9Kxg&s", 4 },
                    { 84, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxMmri614mHixf7y_Ij5TH-B5N41gpmtLVhQ&s", 5 },
                    { 85, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIGic3LMgDqbq78Z4u639yd-dCd3NF6F4UPA&s", 5 },
                    { 86, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRl0B53c4RnYzIdJIibkcsUn6EkiiyerHSusQ&s", 5 },
                    { 87, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS90yDKSTVSy2EAu8p6JWJ9JvnJshxzOFrDeQ&s", 6 },
                    { 88, null, "https://m.media-amazon.com/images/I/51shRjAr+WL._AC_UF894,1000_QL80_.jpg", 6 },
                    { 89, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR0HyZLFDIAnLfDOjgB0OrkXt3GrvC7QcELbQ&s", 7 },
                    { 90, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWCpzH4kFjK7H00sSDc3sQhvMw1Gx2yeL4Qg&s", 7 },
                    { 91, null, "https://spacenet.tn/39176-large_default/iphone-11-pro-64-go-gold.jpg", 8 },
                    { 92, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnySGS0JvfSzEhU8GPPvCd3q6WAxEjthQ7RA&s", 8 },
                    { 93, null, "https://www.apple.com/newsroom/images/product/iphone/standard/Apple_iPhone-11-Pro_Matte-Glass-Back_091019_big.jpg.large.jpg", 8 },
                    { 94, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJCrSkNLXOoHtOzlkuFbbMRW7BfTVq5_BOmA&s", 9 },
                    { 95, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSU-5e4iGig3YjL4R8hdCPiNcRUhsOMizmjYw&s", 9 },
                    { 96, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ70uO5PfBU3FDskFySMN6dxkcw8_h1LkAgAg&s", 9 },
                    { 97, null, "https://cdn.lesnumeriques.com/optim/product/59/59901/34105c50-iphone-12__450_400.jpeg", 10 },
                    { 98, null, "https://ee.co.uk/medias/iphone-12-5g-64gb-purple-desktop-detail-1-WebP-Format-488?context=bWFzdGVyfHJvb3R8ODI3OHxpbWFnZS93ZWJwfHN5cy1tYXN0ZXIvcm9vdC9oYzkvaDFiLzk4ODc1MDM5MDg4OTQvaXBob25lLTEyLTVnLTY0Z2ItcHVycGxlLWRlc2t0b3AtZGV0YWlsLTFfV2ViUC1Gb3JtYXQtNDg4fDVkN2FlNDE5OWQ0MmU4NjE3NmI3NzVmZDk0YzI3ZWUxMTcwMGIwYjBhOTc5NTdlNzE2NmUwN2ZjNjY2OWY5ZDA", 10 },
                    { 99, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdBH-cHAeod-2YbGAQdOz3ATHyNKC6Fhbp7A&s", 10 },
                    { 100, null, "https://www.mega.tn/assets/uploads/img/pr_telephonie_mobile/1615906971_363.jpeg", 11 },
                    { 101, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSYUOFQVbzRNuO7MoXI5_WyYbarF2QE7H15pw&s", 11 },
                    { 102, null, "https://cdn.dxomark.com/wp-content/uploads/medias/post-61584/iphone-12-pro-max-graphite-hero.jpg", 12 },
                    { 103, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxaVRjp9pB5dI2pdANtX80tdg4zLXz05Ewuw&s", 12 },
                    { 104, null, "https://www.apple.com/newsroom/images/product/iphone/geo/Apple_iphone13_colors_geo_09142021_big.jpg.small.jpg", 13 },
                    { 105, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBgzRwxJ7qp9auLsjGvtnxl6EaDpLgc-_Apg&s", 13 },
                    { 106, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1OsFNeZpeISgl0dWMl9Yjubr-MIOvJsNlMA&s", 14 },
                    { 107, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT41oM9lJ9XVYPjrthmaJKF6Kf7A9hUEVWq_Q&s", 14 },
                    { 108, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTy4ttV98BCDt-5pnYfVYQmiR4No2lNbANYxw&s", 15 },
                    { 109, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6lBAgMn_PUKUweDIj8IBTnoznbJmskNCP2A&s", 15 },
                    { 110, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcMjbMBL5v9Afqw1oGFyq5JNE_8oTE5oIjGw&s", 41 },
                    { 111, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRf9cwe59EKYaLh7hltnW9aF_m_1_CMNAIU3w&s", 41 },
                    { 112, null, "https://cdsassets.apple.com/live/SZLF0YNV/images/sp/111846_sp875-sp876-iphone14-pro-promax.png", 42 },
                    { 113, null, "https://mk-media.mytek.tn/media/catalog/product/cache/8be3f98b14227a82112b46963246dfe1/a/1/a13-black4_371_1.jpg", 42 },
                    { 114, null, "https://www.sws-informatique.tn/wp-content/uploads/2023/01/iphone14pro.webp", 43 },
                    { 115, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOEPzXrWKRRHe7komHi6aHsItFbQEGxm07Rw&s", 43 },
                    { 116, null, "https://www.cnet.com/a/img/resize/e21b3371c11612c4e14928a6a237e7b0889745f8/hub/2023/09/12/2d9d37cc-7d99-4f81-8da2-8f3a674f4243/screenshot-2023-09-12-at-10-38-30-am.png?auto=webp&width=1200", 44 },
                    { 117, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStT7XTFitwSMRrlMzyUqTzgC1xImLE0Hd2FA&s", 44 },
                    { 118, null, "https://www.apple.com/v/iphone-15-pro/c/images/specs/hero_iphone_pro_max__bsan8nevcgty_large.jpg", 45 },
                    { 119, null, "https://www.apple.com/newsroom/images/2023/09/apple-unveils-iphone-15-pro-and-iphone-15-pro-max/article/Apple-iPhone-15-Pro-lineup-hero-230912_Full-Bleed-Image.jpg.large.jpg", 45 },
                    { 120, null, "https://www.apple.com/v/iphone-15-pro/c/images/specs/hero_iphone_pro_max__bsan8nevcgty_large.jpg", 46 },
                    { 121, null, "https://imageio.forbes.com/specials-images/imageserve/641397e79f04500b85460b8f/Apple--iPhone-15--iPhone-15-Pro-Max--iPhone-15-Pro--iPhone-15-Pro-design--iPhone-15/0x0.jpg?format=jpg&crop=961,721,x344,y2,safe&width=960", 46 },
                    { 122, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbkJHZhFO6U7pqP4rIeFPwKE9wSmP-G_D_Yg&s", 3 },
                    { 123, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRypnoeae3Q5ACwvSmfGdYtW8etvo_4UbPbPw&s", 3 },
                    { 124, null, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/macbook-air-space-gray-select-201810?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1633027804000", 16 },
                    { 125, null, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp16-spacegray-select-202110?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1632788124000", 17 },
                    { 126, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOs0Ee2UM2pSdlKR-dLp0seRHomx0UnPIj_w&s", 18 },
                    { 127, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTipFhDl9U0Was0zKFHh8vDExcEe87kT-Oi9g&s", 19 },
                    { 128, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUoxDh4p_6NU5f2EHOkv91EM-JCePGZ3QyEg&s", 20 },
                    { 129, null, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mac-mini-hero-202011?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1617472404000", 21 },
                    { 130, null, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/imac-24-blue-selection-hero-202104?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1617472222000", 22 },
                    { 131, null, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mac-studio-hero-202203?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1647052906174", 23 },
                    { 132, null, "https://imageio.forbes.com/specials-images/imageserve/65282b8ed61a31651ccb438e/14-inch-Macbook-Pro/960x0.jpg?height=473&width=711&fit=bounds", 24 },
                    { 133, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwY58M-dvmyhpLVfYDjnpwlrX8rhZymjaGhA&s", 25 },
                    { 134, null, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp16-spacegray-select-202110?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1632788124000", 26 },
                    { 135, null, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp16-spacegray-select-202110?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1632788124000", 27 },
                    { 136, null, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/macbook-air-space-gray-select-201810?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1633027804000", 28 },
                    { 137, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi7xsTCI2iH227YfV2OopTu5qP7ImLJeK0SQ&s", 29 },
                    { 138, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOaDYCVhEiigu-fiOVgSHG1_QobV8IPyabdg&s", 30 },
                    { 139, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTquL0fiDP7lgzrcarir4TQVbfSpxmGSt6AqQ&s", 31 },
                    { 140, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ4s_J5wplcKA8HGzOT0IGFSbsDI5v3BI6LA&s", 32 },
                    { 141, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ4s_J5wplcKA8HGzOT0IGFSbsDI5v3BI6LA&s", 33 },
                    { 142, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ4s_J5wplcKA8HGzOT0IGFSbsDI5v3BI6LA&s", 34 },
                    { 143, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2X-T6MGSDMd7CJF2ViDBs9f0vARbPoe7TlQ&s", 35 },
                    { 144, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2X-T6MGSDMd7CJF2ViDBs9f0vARbPoe7TlQ&s", 36 },
                    { 145, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_RLPxwGu3V2h2Zg_pfl8J9XznIGAiAv6ErA&s", 37 },
                    { 146, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_RLPxwGu3V2h2Zg_pfl8J9XznIGAiAv6ErA&s", 38 },
                    { 147, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2X-T6MGSDMd7CJF2ViDBs9f0vARbPoe7TlQ&s", 39 },
                    { 148, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_RLPxwGu3V2h2Zg_pfl8J9XznIGAiAv6ErA&s", 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commands_UserId",
                table: "Commands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_ProductId",
                table: "Favoris",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_UserId",
                table: "Favoris",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CommandId",
                table: "Orders",
                column: "CommandId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorRelations_ColorId",
                table: "ProductColorRelations",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorRelations_ProductId_ColorId",
                table: "ProductColorRelations",
                columns: new[] { "ProductId", "ColorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favoris");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductColorRelations");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
