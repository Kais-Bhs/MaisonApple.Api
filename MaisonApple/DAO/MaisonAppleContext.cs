// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using DAO.Configurations;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class MaisonAppleContext : IdentityDbContext
    {
        public MaisonAppleContext(DbContextOptions<MaisonAppleContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductColorRelation> ProductColorRelations { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<string>>()
      .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());
            new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
            new ProductImageEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductImage>());
            new ProductColorEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductColor>());
            new ProductColorRelationEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductColorRelation>());

            new CommandEntityTypeConfiguration().Configure(modelBuilder.Entity<Command>());
            new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());
            new NotificationEntityTypeConfguration().Configure(modelBuilder.Entity<Notification>());

            modelBuilder.Entity<Category>().HasData(
          new Category { Id = 1, Name = "IPHONE" },
          new Category { Id = 2, Name = "MAC" },
          new Category { Id = 3, Name = "AppleWATCH" }
      );

            // Seed data for Products table
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 11", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 1, InitialPrice = 1200, CurrentPrice = 1200 },
                new Product { Id = 2, Name = "iPhone 12", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 1, InitialPrice = 1500, CurrentPrice = 1500 },
                new Product { Id = 3, Name = "iPhone 13", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 1, InitialPrice = 1800, CurrentPrice = 1800 },
                new Product { Id = 4, Name = "iPhone 13 Pro Max", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 1, InitialPrice = 2200, CurrentPrice = 2200 },
                new Product { Id = 5, Name = "iPhone 15", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 1, InitialPrice = 2800, CurrentPrice = 2800 },
                new Product { Id = 6, Name = "Mac Pro 2022", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 2, InitialPrice = 3000, CurrentPrice = 3000 },
                new Product { Id = 7, Name = "Mac Pro 2021", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 2, InitialPrice = 2500, CurrentPrice = 2500 },
                new Product { Id = 8, Name = "Mac Pro 2020", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 2, InitialPrice = 2000, CurrentPrice = 2000 },
                new Product { Id = 9, Name = "Apple Watch Series 7", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 3, InitialPrice = 400, CurrentPrice = 400 },
                new Product { Id = 10, Name = "Apple Watch SE", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 3, InitialPrice = 300, CurrentPrice = 300 },
                new Product { Id = 11, Name = "Apple Watch Series 3", Description = "Écran:\r\n\r\nSuper Retina XDR OLED\r\n6,1 pouces (diagonale)\r\nRésolution de 2532 x 1170 pixels (460 ppp)\r\nHDR\r\nTrue Tone\r\nGamme de couleurs étendue (P3)\r\nHaptic Touch\r\nContraste de 2 000 000:1 (standard)\r\nLuminosité maximale de 800 nits (standard) ; 1200 nits (HDR)\r\nRevêtement oléophobe résistant aux traces de doigts\r\nAppareil photo:\r\n\r\nDouble appareil photo arrière :\r\nGrand angle 12 Mpx : 26 mm, ouverture ƒ/1.5, stabilisation optique de l'image par déplacement du capteur, 100 % Focus Pixels\r\nUltra grand angle 12 Mpx : 13 mm, ouverture ƒ/2.4, champ de vision de 120°\r\nZoom optique arrière 2x ; zoom numérique jusqu'à 5x\r\nCaméra frontale TrueDepth 12 Mpx\r\nMode Cinématique pour la vidéo en 4K Dolby Vision jusqu'à 30 ips\r\nEnregistrement vidéo HDR 4K Dolby Vision jusqu'à 60 ips\r\nPerformances:\r\n\r\nPuce A15 Bionic\r\nBatterie:\r\n\r\nJusqu'à 19 heures de lecture vidéo\r\nJusqu'à 16 heures de lecture audio\r\nStockage:\r\n\r\n128 Go, 256 Go ou 512 Go\r\nAutres:\r\n\r\niOS 16\r\n5G\r\nWi-Fi 6 (802.11ax)\r\nBluetooth 5.3\r\nFace ID\r\nLightning\r\nCertifié IP68", StockQuantity = 10, CategoryId = 3, InitialPrice = 200, CurrentPrice = 200 }
            );

            // Seed data for IdentityRole table
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "ADMIN", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "USER", NormalizedName = "USER" }
            );
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage { Id = 1, ProductId = 1, ImageUrl = "https://media.ldlc.com/r1600/ld/products/00/05/92/68/LD0005926880_1.jpg" },
                 new ProductImage { Id = 2, ProductId = 2, ImageUrl = "https://m.media-amazon.com/images/I/510WkOj8FLL._AC_UF894,1000_QL80_.jpg" },
                  new ProductImage { Id = 3, ProductId = 3, ImageUrl = "https://mk-media.mytek.tn/media/catalog/product/cache/8be3f98b14227a82112b46963246dfe1/i/p/iph-13-128-sl_2.jpg" },
                   new ProductImage { Id = 4, ProductId = 4, ImageUrl = "https://www.apple.com/newsroom/images/product/iphone/geo/Apple_iPhone-13-Pro_iPhone-13-Pro-Max_GEO_09142021_inline.jpg.large.jpg" },
                    new ProductImage { Id = 5, ProductId = 5, ImageUrl = "https://www.apple.com/newsroom/images/product/iphone/geo/Apple_iPhone-13-Pro_iPhone-13-Pro-Max_GEO_09142021_inline.jpg.large.jpg" },
                     new ProductImage { Id = 6, ProductId = 6, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZokHFYzzt5CenynhMyHQdkcHbz-015EIStA&s" },
                      new ProductImage { Id = 7, ProductId = 7, ImageUrl = "https://www.cnet.com/a/img/resize/483f6629791616f58f3a205df4d52e40b8cba429/hub/2024/03/06/725a8e72-aa72-439a-9357-af161b30f3c9/apple-macbook-air-m3-2024-14.jpg?auto=webp&fit=crop&height=1200&width=1200" },
                       new ProductImage { Id = 8, ProductId = 8, ImageUrl = "https://media.wired.com/photos/643d7e61cdba28f045ac3f59/master/pass/macbook_sec_GettyImages-1368668740.jpg" },
                        new ProductImage { Id = 9, ProductId = 9, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1Vd_ryVhLC8nBtyZbgQ03y2_BFIrW1zcfFg&s" },
                        new ProductImage { Id = 10, ProductId = 10, ImageUrl = "https://www.apple.com/newsroom/images/product/watch/standard/Apple_watch-series7_hero_09142021_big.jpg.slideshow-medium_2x.jpg" },
                        new ProductImage { Id = 11, ProductId = 11, ImageUrl = "https://www.apple.com/newsroom/images/2023/09/apple-unveils-apple-watch-ultra-2/tile/Apple-Watch-Ultra-2-hero-230912.jpg.og.jpg?202405161951" }
                );

            modelBuilder.Entity<ProductColor>().HasData(
       new ProductColor { Id = 1, Name = "Red", ColorCode = "#FF0000" },
       new ProductColor { Id = 2, Name = "Blue", ColorCode = "#007AFF" },
       new ProductColor { Id = 3, Name = "Green", ColorCode = "#34C759" },
       new ProductColor { Id = 4, Name = "Black", ColorCode = "#000000" },
       new ProductColor { Id = 5, Name = "Yellow", ColorCode = "#FFCC00" },
       new ProductColor { Id = 6, Name = "Gold", ColorCode = "#FFD700" },
       new ProductColor { Id = 7, Name = "Purple", ColorCode = "#AF52DE" },
       new ProductColor { Id = 8, Name = "Grey", ColorCode = "#8E8E93" }
   );


            modelBuilder.Entity<ProductColorRelation>().HasData(
                new ProductColorRelation { Id = 1, ProductId = 1, ColorId = 1 },
                new ProductColorRelation { Id = 2, ProductId = 1, ColorId = 2 },
                new ProductColorRelation { Id = 3, ProductId = 1, ColorId = 3 },
                new ProductColorRelation { Id = 4, ProductId = 2, ColorId = 1 },
                new ProductColorRelation { Id = 5, ProductId = 2, ColorId = 2 },
                new ProductColorRelation { Id = 6, ProductId = 3, ColorId = 1 },
                new ProductColorRelation { Id = 7, ProductId = 3, ColorId = 3 },
                new ProductColorRelation { Id = 8, ProductId = 4, ColorId = 2 },
                new ProductColorRelation { Id = 9, ProductId = 4, ColorId = 4 },
                new ProductColorRelation { Id = 10, ProductId = 5, ColorId = 1 },
                new ProductColorRelation { Id = 11, ProductId = 5, ColorId = 5 },
                new ProductColorRelation { Id = 12, ProductId = 6, ColorId = 1 },
                new ProductColorRelation { Id = 13, ProductId = 6, ColorId = 3 },
                new ProductColorRelation { Id = 14, ProductId = 7, ColorId = 2 },
                new ProductColorRelation { Id = 15, ProductId = 7, ColorId = 4 },
                new ProductColorRelation { Id = 16, ProductId = 8, ColorId = 1 },
                new ProductColorRelation { Id = 17, ProductId = 8, ColorId = 5 },
                new ProductColorRelation { Id = 18, ProductId = 9, ColorId = 2 },
                new ProductColorRelation { Id = 19, ProductId = 9, ColorId = 3 },
                new ProductColorRelation { Id = 20, ProductId = 10, ColorId = 1 },
                new ProductColorRelation { Id = 21, ProductId = 10, ColorId = 4 },
                new ProductColorRelation { Id = 22, ProductId = 11, ColorId = 2 },
                new ProductColorRelation { Id = 23, ProductId = 11, ColorId = 5 }
            );

        }
    }
}
