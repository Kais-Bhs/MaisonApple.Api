﻿using Microsoft.EntityFrameworkCore.Migrations;
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
                    { 1, "#FF0000", "Red" },
                    { 2, "#007AFF", "Blue" },
                    { 3, "#34C759", "Green" },
                    { 4, "#000000", "Black" },
                    { 5, "#FFCC00", "Yellow" },
                    { 6, "#FFD700", "Gold" },
                    { 7, "#AF52DE", "Purple" },
                    { 8, "#8E8E93", "Grey" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CurrentPrice", "Description", "InitialPrice", "IsUsed", "Name", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, 1200, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 1200, false, "iPhone 11", 10 },
                    { 2, 1, 1500, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 1500, false, "iPhone 12", 10 },
                    { 3, 1, 1800, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 1800, false, "iPhone 13", 10 },
                    { 4, 1, 2200, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 2200, false, "iPhone 13 Pro Max", 10 },
                    { 5, 1, 2800, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 2800, false, "iPhone 15", 10 },
                    { 6, 2, 3000, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 3000, false, "Mac Pro 2022", 10 },
                    { 7, 2, 2500, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 2500, false, "Mac Pro 2021", 10 },
                    { 8, 2, 2000, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 2000, false, "Mac Pro 2020", 10 },
                    { 9, 3, 400, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 400, false, "Apple Watch Series 7", 10 },
                    { 10, 3, 300, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 300, false, "Apple Watch SE", 10 },
                    { 11, 3, 200, "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", 200, false, "Apple Watch Series 3", 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductColorRelations",
                columns: new[] { "Id", "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 },
                    { 6, 1, 3 },
                    { 7, 3, 3 },
                    { 8, 2, 4 },
                    { 9, 4, 4 },
                    { 10, 1, 5 },
                    { 11, 5, 5 },
                    { 12, 1, 6 },
                    { 13, 3, 6 },
                    { 14, 2, 7 },
                    { 15, 4, 7 },
                    { 16, 1, 8 },
                    { 17, 5, 8 },
                    { 18, 2, 9 },
                    { 19, 3, 9 },
                    { 20, 1, 10 },
                    { 21, 4, 10 },
                    { 22, 2, 11 },
                    { 23, 5, 11 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageData", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, null, "https://media.ldlc.com/r1600/ld/products/00/05/92/68/LD0005926880_1.jpg", 1 },
                    { 2, null, "https://m.media-amazon.com/images/I/510WkOj8FLL._AC_UF894,1000_QL80_.jpg", 2 },
                    { 3, null, "https://mk-media.mytek.tn/media/catalog/product/cache/8be3f98b14227a82112b46963246dfe1/i/p/iph-13-128-sl_2.jpg", 3 },
                    { 4, null, "https://www.apple.com/newsroom/images/product/iphone/geo/Apple_iPhone-13-Pro_iPhone-13-Pro-Max_GEO_09142021_inline.jpg.large.jpg", 4 },
                    { 5, null, "https://www.apple.com/newsroom/images/product/iphone/geo/Apple_iPhone-13-Pro_iPhone-13-Pro-Max_GEO_09142021_inline.jpg.large.jpg", 5 },
                    { 6, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZokHFYzzt5CenynhMyHQdkcHbz-015EIStA&s", 6 },
                    { 7, null, "https://www.cnet.com/a/img/resize/483f6629791616f58f3a205df4d52e40b8cba429/hub/2024/03/06/725a8e72-aa72-439a-9357-af161b30f3c9/apple-macbook-air-m3-2024-14.jpg?auto=webp&fit=crop&height=1200&width=1200", 7 },
                    { 8, null, "https://media.wired.com/photos/643d7e61cdba28f045ac3f59/master/pass/macbook_sec_GettyImages-1368668740.jpg", 8 },
                    { 9, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1Vd_ryVhLC8nBtyZbgQ03y2_BFIrW1zcfFg&s", 9 },
                    { 10, null, "https://www.apple.com/newsroom/images/product/watch/standard/Apple_watch-series7_hero_09142021_big.jpg.slideshow-medium_2x.jpg", 10 },
                    { 11, null, "https://www.apple.com/newsroom/images/2023/09/apple-unveils-apple-watch-ultra-2/tile/Apple-Watch-Ultra-2-hero-230912.jpg.og.jpg?202405161951", 11 }
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
