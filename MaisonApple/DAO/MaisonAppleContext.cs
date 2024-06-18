// ---------------------------------------------------------------
// Copyright (c) Kais Ben Hadj Hassen + Mohamed Riadh Sohnoun. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System.Security.Cryptography.X509Certificates;
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
        public int i = 1;
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductColorRelation> ProductColorRelations { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Favoris> Favoris { get; set; }
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
            new FavorisEntityTypeConfiguration().Configure(modelBuilder.Entity<Favoris>());

            modelBuilder.Entity<Category>().HasData(
          new Category { Id = 1, Name = "IPHONE" },
          new Category { Id = 2, Name = "MAC" },
          new Category { Id = 3, Name = "AppleWATCH" }
      );

            // Seed data for Products table
           

                modelBuilder.Entity<Product>().HasData(
                        new Product { Id = 1, Name = "iPhone 8", Description = "RAM: 2 Go\n*Stockage: 64 Go\n*Appareil photo: 12 MP\n*Écran: 4,7 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 1250, CurrentPrice = 1250 },
    new Product { Id = 2, Name = "iPhone 8 Plus", Description = "RAM: 3 Go\n*Stockage: 64 Go ou 256 Go\n*Appareil photo: Double 12 MP\n*Écran: 5,5 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 1625, CurrentPrice = 1625 },
    new Product { Id = 3, Name = "iPhone X", Description = "RAM: 3 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 5,8 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2000, CurrentPrice = 2000 },
    new Product { Id = 4, Name = "iPhone XR", Description = "RAM: 3 Go\n*Stockage: 64 Go, 128 Go, ou 256 Go\n*Appareil photo: Simple 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 1750, CurrentPrice = 1750 },
    new Product { Id = 5, Name = "iPhone XS", Description = "RAM: 4 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 5,8 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2250, CurrentPrice = 2250 },
    new Product { Id = 6, Name = "iPhone XS Max", Description = "RAM: 4 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,5 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2500, CurrentPrice = 2500 },
    new Product { Id = 7, Name = "iPhone 11", Description = "RAM: 4 Go\n*Stockage: 64 Go, 128 Go, ou 256 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 1875, CurrentPrice = 1875 },
    new Product { Id = 8, Name = "iPhone 11 Pro", Description = "RAM: 4 Go ou 6 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 5,8 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2500, CurrentPrice = 2500 },
    new Product { Id = 9, Name = "iPhone 11 Pro Max", Description = "RAM: 4 Go ou 6 Go\n*Stockage: 64 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,5 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2650, CurrentPrice = 2650 },
    new Product { Id = 10, Name = "iPhone 12", Description = "RAM: 4 Go\n*Stockage: 64 Go, 128 Go, ou 256 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2000, CurrentPrice = 2000 },
    new Product { Id = 11, Name = "iPhone 12 Pro", Description = "RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2750, CurrentPrice = 2750 },
    new Product { Id = 12, Name = "iPhone 12 Pro Max", Description = "RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,7 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 3000, CurrentPrice = 3000 },
    new Product { Id = 13, Name = "iPhone 13", Description = "RAM: 4 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2125, CurrentPrice = 2125 },
    new Product { Id = 14, Name = "iPhone 13 Pro", Description = "RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2875, CurrentPrice = 2875 },
    new Product { Id = 15, Name = "iPhone 13 Pro Max", Description = "RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,7 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 3125, CurrentPrice = 3125 },
    new Product { Id = 16, Name = "MacBook Air", Description = "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,3 pouces", StockQuantity = 10, CategoryId = 2, InitialPrice = 2497, CurrentPrice = 2497 },
    new Product { Id = 17, Name = "MacBook Pro", Description = "Processeur: Chip M1 Pro ou M1 Max\n*RAM: 16 Go, 32 Go, ou 64 Go\n*Stockage: 256 Go, 512 Go, 1 To, 2 To, ou 4 To\n*Écran: 13,3 pouces ou 16 pouces", StockQuantity = 10, CategoryId = 2, InitialPrice = 3247, CurrentPrice = 3247 },
    new Product { Id = 18, Name = "Apple Watch Series 7", Description = "Processeur: S7\n*Écran: Always-On Retina LTPO OLED\n*Batterie: Jusqu'à 36 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 997, CurrentPrice = 997 },
    new Product { Id = 19, Name = "Apple Watch SE", Description = "Processeur: S5\n*Écran: Retina OLED\n*Batterie: Jusqu'à 18 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 697, CurrentPrice = 697 },
    new Product { Id = 20, Name = "Apple Watch Series 3", Description = "Processeur: S3\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 422, CurrentPrice = 422 },
       new Product { Id = 21, Name = "Mac mini", Description = "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: Intégré de 7 pouces LED", StockQuantity = 10, CategoryId = 2, InitialPrice = 1497, CurrentPrice = 1497 },
    new Product { Id = 22, Name = "iMac", Description = "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 21,5 pouces ou 27 pouces", StockQuantity = 10, CategoryId = 2, InitialPrice = 2747, CurrentPrice = 2747 },
    new Product { Id = 23, Name = "Mac Studio", Description = "Processeur: Chip M1 Ultra ou M1 Max\n*RAM: 32 Go, 64 Go, ou 128 Go\n*Stockage: 512 Go, 1 To, 2 To, 4 To, ou 8 To\n*Écran: Intégré de 5,5 pouces Liquid Retina XDR", StockQuantity = 10, CategoryId = 2, InitialPrice = 4997, CurrentPrice = 4997 },
    new Product { Id = 24, Name = "Mac Pro", Description = "Processeur: Chip M1 Pro ou M1 Max\n*RAM: 32 Go, 64 Go, ou 128 Go\n*Stockage: Personnalisable\n*Écran: Intégré de 5,5 pouces Liquid Retina XDR", StockQuantity = 10, CategoryId = 2, InitialPrice = 7497, CurrentPrice = 7497 },
    new Product { Id = 25, Name = "MacBook Pro 13 pouces", Description = "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,3 pouces", StockQuantity = 10, CategoryId = 2, InitialPrice = 3247, CurrentPrice = 3247 },
    new Product { Id = 26, Name = "MacBook Pro 14 pouces", Description = "Processeur: Chip M1 Pro ou M1 Max\n*RAM: 16 Go, 32 Go, ou 64 Go\n*Stockage: 512 Go, 1 To, 2 To, 4 To, ou 8 To\n*Écran: 14,2 pouces", StockQuantity = 10, CategoryId = 2, InitialPrice = 4997, CurrentPrice = 4997 },
    new Product { Id = 27, Name = "MacBook Pro 16 pouces", Description = "Processeur: Chip M1 Pro ou M1 Max\n*RAM: 16 Go, 32 Go, ou 64 Go\n*Stockage: 512 Go, 1 To, 2 To, 4 To, ou 8 To\n*Écran: 16,2 pouces", StockQuantity = 10, CategoryId = 2, InitialPrice = 6247, CurrentPrice = 6247 },
    new Product { Id = 28, Name = "MacBook Air M1", Description = "Processeur: Chip M1\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,3 pouces", StockQuantity = 10, CategoryId = 2, InitialPrice = 2497, CurrentPrice = 2497 },
    new Product { Id = 29, Name = "MacBook Air M2", Description = "Processeur: Chip M2\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,6 pouces", StockQuantity = 10, CategoryId = 2, InitialPrice = 2997, CurrentPrice = 2997 },
    new Product { Id = 30, Name = "MacBook Pro 13 pouces M2", Description = "Processeur: Chip M2\n*RAM: 8 Go ou 16 Go\n*Stockage: 256 Go, 512 Go, ou 1 To\n*Écran: 13,3 pouces", StockQuantity = 10, CategoryId = 2, InitialPrice = 3747, CurrentPrice = 3747 },
        new Product { Id = 31, Name = "Apple Watch Series 6", Description = "Processeur: S6\n*Écran: Always-On Retina LTPO OLED\n*Batterie: Jusqu'à 18 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 997, CurrentPrice = 997 },
    new Product { Id = 32, Name = "Apple Watch Series 5", Description = "Processeur: S5\n*Écran: Always-On Retina OLED\n*Batterie: Jusqu'à 18 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 822, CurrentPrice = 822 },
    new Product { Id = 33, Name = "Apple Watch Series 4", Description = "Processeur: S4\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 622, CurrentPrice = 622 },
    new Product { Id = 34, Name = "Apple Watch Series 3 LTE", Description = "Processeur: S3\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures\n*Cellulaire LTE", StockQuantity = 10, CategoryId = 3, InitialPrice = 747, CurrentPrice = 747 },
    new Product { Id = 35, Name = "Apple Watch SE (2ème génération)", Description = "Processeur: S5\n*Écran: Retina OLED\n*Batterie: Jusqu'à 30 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 697, CurrentPrice = 697 },
    new Product { Id = 36, Name = "Apple Watch Nike", Description = "Processeur: S5\n*Écran: Always-On Retina OLED\n*Batterie: Jusqu'à 18 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 997, CurrentPrice = 997 },
    new Product { Id = 37, Name = "Apple Watch Hermès", Description = "Processeur: S5\n*Écran: Always-On Retina OLED\n*Batterie: Jusqu'à 18 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 2747, CurrentPrice = 2747 },
    new Product { Id = 38, Name = "Apple Watch Edition", Description = "Processeur: S5\n*Écran: Always-On Retina OLED\n*Batterie: Jusqu'à 18 heures\n*Matériau: Or 18 carats", StockQuantity = 10, CategoryId = 3, InitialPrice = 3997, CurrentPrice = 3997 },
    new Product { Id = 39, Name = "Apple Watch SE (1ère génération)", Description = "Processeur: S1\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 497, CurrentPrice = 497 },
    new Product { Id = 40, Name = "Apple Watch Series 1", Description = "Processeur: S1\n*Écran: IPS LCD\n*Batterie: Jusqu'à 18 heures", StockQuantity = 10, CategoryId = 3, InitialPrice = 372, CurrentPrice = 372 },
        new Product { Id = 41, Name = "iPhone 14", Description = "Processeur: A15 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 1997, CurrentPrice = 1997 },
    new Product { Id = 42, Name = "iPhone 14 Pro", Description = "Processeur: A16 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2497, CurrentPrice = 2497 },
    new Product { Id = 43, Name = "iPhone 14 Pro Max", Description = "Processeur: A16 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,7 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2747, CurrentPrice = 2747 },
    new Product { Id = 44, Name = "iPhone 15", Description = "Processeur: A17 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Double 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2247, CurrentPrice = 2247 },
    new Product { Id = 45, Name = "iPhone 15 Pro", Description = "Processeur: A18 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,1 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2747, CurrentPrice = 2747 },
    new Product { Id = 46, Name = "iPhone 15 Pro Max", Description = "Processeur: A18 Bionic\n*RAM: 6 Go\n*Stockage: 128 Go, 256 Go, ou 512 Go\n*Appareil photo: Triple 12 MP\n*Écran: 6,7 pouces", StockQuantity = 10, CategoryId = 1, InitialPrice = 2997, CurrentPrice = 2997 }


                    );


            // Seed data for IdentityRole table
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "ADMIN", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "USER", NormalizedName = "USER" }
            );
           
            modelBuilder.Entity<ProductImage>().HasData(
                  new ProductImage { Id = i++ ,ProductId = 1, ImageUrl = "https://www.verizon.com/about/sites/default/files/news-media/1-iPhone8%20Hero%20Image%201280x720.jpg" },
    new ProductImage { Id = i++ ,ProductId = 1, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2Su2dF_uVR6gxMqGTwF5oNqfC-nNbNr1FPA&s" },
    new ProductImage { Id = i++ ,ProductId = 1, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSVS0yWHhpnJwXXD97yeIk3HLxmZ5KmX2dbA&s" },

    // iPhone 8 Plus
    new ProductImage { Id = i++ ,ProductId = 2, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxOvmabrpeSSURrxlDWgaPZiYzyOymaotQfg&s" },
    new ProductImage { Id = i++ ,ProductId = 2, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZfi2tJGMRmyidpMge5igBYVyfXP9jKext0g&s" },
    new ProductImage { Id = i++ ,ProductId = 2, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVMn3tliykuwEUu2cG1ySZWR_scQC78AOSoQ&s" },
       
    new ProductImage { Id = i++ ,ProductId = 4, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQFML6WTAfSUh9_iNMyPTIu4vSPs5MMAxqFLQ&s" },
    new ProductImage { Id = i++ ,ProductId = 4, ImageUrl = "https://www.zeekonline.co.za/cdn/shop/products/2715_grande.jpg?v=1558796283" },
    new ProductImage { Id = i++ ,ProductId = 4, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1ZU0mSC30v87rsIBETV08b_A7djxvFB9Kxg&s" },

    new ProductImage { Id = i++ ,ProductId = 5, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxMmri614mHixf7y_Ij5TH-B5N41gpmtLVhQ&s" },
    new ProductImage { Id = i++ ,ProductId = 5, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIGic3LMgDqbq78Z4u639yd-dCd3NF6F4UPA&s" },
    new ProductImage { Id = i++ ,ProductId = 5, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRl0B53c4RnYzIdJIibkcsUn6EkiiyerHSusQ&s" },


    new ProductImage { Id = i++ ,ProductId = 6, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS90yDKSTVSy2EAu8p6JWJ9JvnJshxzOFrDeQ&s" },
    new ProductImage { Id = i++ ,ProductId = 6, ImageUrl = "https://m.media-amazon.com/images/I/51shRjAr+WL._AC_UF894,1000_QL80_.jpg" },
      new ProductImage { Id = i++ ,ProductId = 7, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR0HyZLFDIAnLfDOjgB0OrkXt3GrvC7QcELbQ&s" },
    new ProductImage { Id = i++ ,ProductId = 7, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWCpzH4kFjK7H00sSDc3sQhvMw1Gx2yeL4Qg&s" },

      new ProductImage { Id = i++ ,ProductId = 8, ImageUrl = "https://spacenet.tn/39176-large_default/iphone-11-pro-64-go-gold.jpg" },
      new ProductImage { Id = i++ ,ProductId = 8, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnySGS0JvfSzEhU8GPPvCd3q6WAxEjthQ7RA&s" },
    new ProductImage { Id = i++ ,ProductId = 8, ImageUrl = "https://www.apple.com/newsroom/images/product/iphone/standard/Apple_iPhone-11-Pro_Matte-Glass-Back_091019_big.jpg.large.jpg" },

     new ProductImage { Id = i++ ,ProductId = 9, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJCrSkNLXOoHtOzlkuFbbMRW7BfTVq5_BOmA&s" },
      new ProductImage { Id = i++ ,ProductId = 9, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSU-5e4iGig3YjL4R8hdCPiNcRUhsOMizmjYw&s" },
    new ProductImage { Id = i++ ,ProductId = 9, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ70uO5PfBU3FDskFySMN6dxkcw8_h1LkAgAg&s" },

      new ProductImage { Id = i++ ,ProductId = 10, ImageUrl = "https://cdn.lesnumeriques.com/optim/product/59/59901/34105c50-iphone-12__450_400.jpeg" },
      new ProductImage { Id = i++ ,ProductId = 10, ImageUrl = "https://ee.co.uk/medias/iphone-12-5g-64gb-purple-desktop-detail-1-WebP-Format-488?context=bWFzdGVyfHJvb3R8ODI3OHxpbWFnZS93ZWJwfHN5cy1tYXN0ZXIvcm9vdC9oYzkvaDFiLzk4ODc1MDM5MDg4OTQvaXBob25lLTEyLTVnLTY0Z2ItcHVycGxlLWRlc2t0b3AtZGV0YWlsLTFfV2ViUC1Gb3JtYXQtNDg4fDVkN2FlNDE5OWQ0MmU4NjE3NmI3NzVmZDk0YzI3ZWUxMTcwMGIwYjBhOTc5NTdlNzE2NmUwN2ZjNjY2OWY5ZDA" },
    new ProductImage { Id = i++ ,ProductId = 10, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdBH-cHAeod-2YbGAQdOz3ATHyNKC6Fhbp7A&s" },
 new ProductImage { Id = i++ ,ProductId = 11, ImageUrl = "https://www.mega.tn/assets/uploads/img/pr_telephonie_mobile/1615906971_363.jpeg" },
 new ProductImage { Id = i++ ,ProductId = 11, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSYUOFQVbzRNuO7MoXI5_WyYbarF2QE7H15pw&s" },



  new ProductImage { Id = i++ ,ProductId = 12, ImageUrl = "https://cdn.dxomark.com/wp-content/uploads/medias/post-61584/iphone-12-pro-max-graphite-hero.jpg" },
 new ProductImage { Id = i++ ,ProductId = 12, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxaVRjp9pB5dI2pdANtX80tdg4zLXz05Ewuw&s" },

   new ProductImage { Id = i++ ,ProductId = 13, ImageUrl = "https://www.apple.com/newsroom/images/product/iphone/geo/Apple_iphone13_colors_geo_09142021_big.jpg.small.jpg" },
 new ProductImage { Id = i++ ,ProductId = 13, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBgzRwxJ7qp9auLsjGvtnxl6EaDpLgc-_Apg&s" },

  new ProductImage { Id = i++ ,ProductId = 14, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1OsFNeZpeISgl0dWMl9Yjubr-MIOvJsNlMA&s" },
 new ProductImage { Id = i++ ,ProductId = 14, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT41oM9lJ9XVYPjrthmaJKF6Kf7A9hUEVWq_Q&s" },

  new ProductImage { Id = i++ ,ProductId = 15, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTy4ttV98BCDt-5pnYfVYQmiR4No2lNbANYxw&s" },
 new ProductImage { Id = i++ ,ProductId = 15, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6lBAgMn_PUKUweDIj8IBTnoznbJmskNCP2A&s" },

   new ProductImage { Id = i++ ,ProductId = 41, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcMjbMBL5v9Afqw1oGFyq5JNE_8oTE5oIjGw&s" },
 new ProductImage { Id = i++ ,ProductId = 41, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRf9cwe59EKYaLh7hltnW9aF_m_1_CMNAIU3w&s" },

   new ProductImage { Id = i++ ,ProductId = 42, ImageUrl = "https://cdsassets.apple.com/live/SZLF0YNV/images/sp/111846_sp875-sp876-iphone14-pro-promax.png" },
 new ProductImage { Id = i++ ,ProductId = 42, ImageUrl = "https://mk-media.mytek.tn/media/catalog/product/cache/8be3f98b14227a82112b46963246dfe1/a/1/a13-black4_371_1.jpg" },

   new ProductImage { Id = i++ ,ProductId = 43, ImageUrl = "https://www.sws-informatique.tn/wp-content/uploads/2023/01/iphone14pro.webp" },
 new ProductImage { Id = i++ ,ProductId = 43, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOEPzXrWKRRHe7komHi6aHsItFbQEGxm07Rw&s" },

    new ProductImage { Id = i++ ,ProductId = 44, ImageUrl = "https://www.cnet.com/a/img/resize/e21b3371c11612c4e14928a6a237e7b0889745f8/hub/2023/09/12/2d9d37cc-7d99-4f81-8da2-8f3a674f4243/screenshot-2023-09-12-at-10-38-30-am.png?auto=webp&width=1200" },
 new ProductImage { Id = i++ ,ProductId = 44, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStT7XTFitwSMRrlMzyUqTzgC1xImLE0Hd2FA&s" },

    new ProductImage { Id = i++ ,ProductId = 45, ImageUrl = "https://www.apple.com/v/iphone-15-pro/c/images/specs/hero_iphone_pro_max__bsan8nevcgty_large.jpg" },
 new ProductImage { Id = i++ ,ProductId = 45, ImageUrl = "https://www.apple.com/newsroom/images/2023/09/apple-unveils-iphone-15-pro-and-iphone-15-pro-max/article/Apple-iPhone-15-Pro-lineup-hero-230912_Full-Bleed-Image.jpg.large.jpg" },

    new ProductImage { Id = i++ ,ProductId = 46, ImageUrl = "https://www.apple.com/v/iphone-15-pro/c/images/specs/hero_iphone_pro_max__bsan8nevcgty_large.jpg" },
 new ProductImage { Id = i++ ,ProductId = 46, ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/641397e79f04500b85460b8f/Apple--iPhone-15--iPhone-15-Pro-Max--iPhone-15-Pro--iPhone-15-Pro-design--iPhone-15/0x0.jpg?format=jpg&crop=961,721,x344,y2,safe&width=960" },

    new ProductImage { Id = i++ ,ProductId = 3, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbkJHZhFO6U7pqP4rIeFPwKE9wSmP-G_D_Yg&s" },
 new ProductImage { Id = i++ ,ProductId = 3, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRypnoeae3Q5ACwvSmfGdYtW8etvo_4UbPbPw&s" },

new ProductImage { Id = i++ ,ProductId = 16, ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/macbook-air-space-gray-select-201810?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1633027804000" },
new ProductImage { Id = i++ ,ProductId = 17, ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp16-spacegray-select-202110?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1632788124000" },
new ProductImage { Id = i++ ,ProductId = 18, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOs0Ee2UM2pSdlKR-dLp0seRHomx0UnPIj_w&s" },
new ProductImage { Id = i++ ,ProductId = 19, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTipFhDl9U0Was0zKFHh8vDExcEe87kT-Oi9g&s" },
new ProductImage { Id = i++ ,ProductId = 20, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUoxDh4p_6NU5f2EHOkv91EM-JCePGZ3QyEg&s" },
new ProductImage { Id = i++ ,ProductId = 21, ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mac-mini-hero-202011?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1617472404000" },
new ProductImage { Id = i++ ,ProductId = 22, ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/imac-24-blue-selection-hero-202104?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1617472222000" },
new ProductImage { Id = i++ ,ProductId = 23, ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mac-studio-hero-202203?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1647052906174" },
new ProductImage { Id = i++ ,ProductId = 24, ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/65282b8ed61a31651ccb438e/14-inch-Macbook-Pro/960x0.jpg?height=473&width=711&fit=bounds" },
new ProductImage { Id = i++ ,ProductId = 25, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwY58M-dvmyhpLVfYDjnpwlrX8rhZymjaGhA&s" },
new ProductImage { Id = i++ ,ProductId = 26, ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp16-spacegray-select-202110?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1632788124000" },
new ProductImage { Id = i++ ,ProductId = 27, ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp16-spacegray-select-202110?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1632788124000" },
new ProductImage { Id = i++ ,ProductId = 28, ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/macbook-air-space-gray-select-201810?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1633027804000" },
new ProductImage { Id = i++ ,ProductId = 29, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi7xsTCI2iH227YfV2OopTu5qP7ImLJeK0SQ&s" },
new ProductImage { Id = i++ ,ProductId = 30, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOaDYCVhEiigu-fiOVgSHG1_QobV8IPyabdg&s" },

new ProductImage { Id = i++, ProductId = 31, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTquL0fiDP7lgzrcarir4TQVbfSpxmGSt6AqQ&s" },
new ProductImage { Id = i++, ProductId = 32, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ4s_J5wplcKA8HGzOT0IGFSbsDI5v3BI6LA&s" },
new ProductImage { Id = i++, ProductId = 33, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ4s_J5wplcKA8HGzOT0IGFSbsDI5v3BI6LA&s" },
new ProductImage { Id = i++, ProductId = 34, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ4s_J5wplcKA8HGzOT0IGFSbsDI5v3BI6LA&s" },
new ProductImage { Id = i++, ProductId = 35, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2X-T6MGSDMd7CJF2ViDBs9f0vARbPoe7TlQ&s" },
new ProductImage { Id = i++, ProductId = 36, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2X-T6MGSDMd7CJF2ViDBs9f0vARbPoe7TlQ&s" },
new ProductImage { Id = i++, ProductId = 37, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_RLPxwGu3V2h2Zg_pfl8J9XznIGAiAv6ErA&s" },
new ProductImage { Id = i++, ProductId = 38, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_RLPxwGu3V2h2Zg_pfl8J9XznIGAiAv6ErA&s" },
new ProductImage { Id = i++, ProductId = 39, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2X-T6MGSDMd7CJF2ViDBs9f0vARbPoe7TlQ&s" },
new ProductImage { Id = i++, ProductId = 40, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_RLPxwGu3V2h2Zg_pfl8J9XznIGAiAv6ErA&s" }


    );
            modelBuilder.Entity<ProductColor>().HasData(
    new ProductColor { Id = 1, Name = "Gris sidéral", ColorCode = "#808080" },
new ProductColor { Id = 2, Name = "Argent", ColorCode = "#C0C0C0" },
new ProductColor { Id = 3, Name = "Or", ColorCode = "#FFD700" },
new ProductColor { Id = 4, Name = "Vert", ColorCode = "#008000" },
new ProductColor { Id = 5, Name = "Bleu", ColorCode = "#0000FF" },
new ProductColor { Id = 6, Name = "Rose", ColorCode = "#FFC0CB" },
new ProductColor { Id = 7, Name = "Violet", ColorCode = "#800080" },
new ProductColor { Id = 8, Name = "Rouge", ColorCode = "#FF0000" },
new ProductColor { Id = 9, Name = "Blanc", ColorCode = "#000000" },
new ProductColor { Id = 10, Name = "Noir", ColorCode = "#FFFFFF" }
   );


            modelBuilder.Entity<ProductColorRelation>().HasData(
     // iPhone 8
     new ProductColorRelation { Id = 1, ProductId = 1, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 2, ProductId = 1, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 3, ProductId = 1, ColorId = 5 }, // Bleu

     // iPhone 8 Plus
     new ProductColorRelation { Id = 4, ProductId = 2, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 5, ProductId = 2, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 6, ProductId = 2, ColorId = 3 }, // Or

     // iPhone X
     new ProductColorRelation { Id = 7, ProductId = 3, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 8, ProductId = 3, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 9, ProductId = 3, ColorId = 6 }, // Rose

     // iPhone XR
     new ProductColorRelation { Id = 10, ProductId = 4, ColorId = 5 }, // Bleu
     new ProductColorRelation { Id = 11, ProductId = 4, ColorId = 7 }, // Violet
     new ProductColorRelation { Id = 12, ProductId = 4, ColorId = 8 }, // Rouge

     // iPhone XS
     new ProductColorRelation { Id = 13, ProductId = 5, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 14, ProductId = 5, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 15, ProductId = 5, ColorId = 3 }, // Or

     // iPhone XS Max
     new ProductColorRelation { Id = 16, ProductId = 6, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 17, ProductId = 6, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 18, ProductId = 6, ColorId = 3 }, // Or

     // iPhone 11
     new ProductColorRelation { Id = 19, ProductId = 7, ColorId = 4 }, // Vert
     new ProductColorRelation { Id = 20, ProductId = 7, ColorId = 5 }, // Bleu
     new ProductColorRelation { Id = 21, ProductId = 7, ColorId = 8 }, // Rouge

     // iPhone 11 Pro
     new ProductColorRelation { Id = 22, ProductId = 8, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 23, ProductId = 8, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 24, ProductId = 8, ColorId = 3 }, // Or

     // iPhone 11 Pro Max
     new ProductColorRelation { Id = 25, ProductId = 9, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 26, ProductId = 9, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 27, ProductId = 9, ColorId = 3 }, // Or

     // iPhone 12
     new ProductColorRelation { Id = 28, ProductId = 10, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 29, ProductId = 10, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 30, ProductId = 10, ColorId = 8 }, // Rouge

     // iPhone 12 Pro
     new ProductColorRelation { Id = 31, ProductId = 11, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 32, ProductId = 11, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 33, ProductId = 11, ColorId = 3 }, // Or

     // iPhone 12 Pro Max
     new ProductColorRelation { Id = 34, ProductId = 12, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 35, ProductId = 12, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 36, ProductId = 12, ColorId = 3 }, // Or

     // iPhone 13
     new ProductColorRelation { Id = 37, ProductId = 13, ColorId = 4 }, // Vert
     new ProductColorRelation { Id = 38, ProductId = 13, ColorId = 5 }, // Bleu
     new ProductColorRelation { Id = 39, ProductId = 13, ColorId = 8 }, // Rouge

     // iPhone 13 Pro
     new ProductColorRelation { Id = 40, ProductId = 14, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 41, ProductId = 14, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 42, ProductId = 14, ColorId = 3 }, // Or

     // iPhone 13 Pro Max
     new ProductColorRelation { Id = 43, ProductId = 15, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 44, ProductId = 15, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 45, ProductId = 15, ColorId = 3 }, // Or

     // MacBook Air
     new ProductColorRelation { Id = 46, ProductId = 16, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 47, ProductId = 16, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 48, ProductId = 16, ColorId = 5 }, // Bleu

     // MacBook Pro
     new ProductColorRelation { Id = 49, ProductId = 17, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 50, ProductId = 17, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 51, ProductId = 17, ColorId = 5 }, // Bleu

     // Apple Watch Series 7
     new ProductColorRelation { Id = 52, ProductId = 18, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 53, ProductId = 18, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 54, ProductId = 18, ColorId = 6 }, // Rose

     // Apple Watch SE
     new ProductColorRelation { Id = 55, ProductId = 19, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 56, ProductId = 19, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 57, ProductId = 19, ColorId = 6 }, // Rose

     // Apple Watch Series 3
     new ProductColorRelation { Id = 58, ProductId = 20, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 59, ProductId = 20, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 60, ProductId = 20, ColorId = 5 }, // Bleu

     // Mac mini
     new ProductColorRelation { Id = 61, ProductId = 21, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 62, ProductId = 21, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 63, ProductId = 21, ColorId = 5 }, // Bleu

     // iMac
     new ProductColorRelation { Id = 64, ProductId = 22, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 65, ProductId = 22, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 66, ProductId = 22, ColorId = 5 }, // Bleu

     // Mac Studio
     new ProductColorRelation { Id = 67, ProductId = 23, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 68, ProductId = 23, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 69, ProductId = 23, ColorId = 5 }, // Bleu

     // Mac Pro
     new ProductColorRelation { Id = 70, ProductId = 24, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 71, ProductId = 24, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 72, ProductId = 24, ColorId = 5 }, // Bleu

     // iPad Pro
     new ProductColorRelation { Id = 73, ProductId = 25, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 74, ProductId = 25, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 75, ProductId = 25, ColorId = 6 }, // Rose

     // iPad Air
     new ProductColorRelation { Id = 76, ProductId = 26, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 77, ProductId = 26, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 78, ProductId = 26, ColorId = 6 }, // Rose

     // iPad
     new ProductColorRelation { Id = 79, ProductId = 27, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 80, ProductId = 27, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 81, ProductId = 27, ColorId = 6 }, // Rose

     // iPad mini
     new ProductColorRelation { Id = 82, ProductId = 28, ColorId = 1 }, // Gris sidéral
     new ProductColorRelation { Id = 83, ProductId = 28, ColorId = 2 }, // Argent
     new ProductColorRelation { Id = 84, ProductId = 28, ColorId = 6 },
// MacBook Pro 14 pouces
new ProductColorRelation { Id = 85, ProductId = 29, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 86, ProductId = 29, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 87, ProductId = 29, ColorId = 5 }, // Bleu

// MacBook Pro 16 pouces
new ProductColorRelation { Id = 88, ProductId = 30, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 89, ProductId = 30, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 90, ProductId = 30, ColorId = 5 }, // Bleu

// MacBook Air M1
new ProductColorRelation { Id = 91, ProductId = 31, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 92, ProductId = 31, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 93, ProductId = 31, ColorId = 5 }, // Bleu

// MacBook Air M2
new ProductColorRelation { Id = 94, ProductId = 32, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 95, ProductId = 32, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 96, ProductId = 32, ColorId = 5 }, // Bleu

// MacBook Pro 13 pouces M2
new ProductColorRelation { Id = 97, ProductId = 33, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 98, ProductId = 33, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 99, ProductId = 33, ColorId = 5 }, // Bleu

// Apple Watch Series 6
new ProductColorRelation { Id = 100, ProductId = 34, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 101, ProductId = 34, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 102, ProductId = 34, ColorId = 6 }, // Rose

// Apple Watch Series 5
new ProductColorRelation { Id = 103, ProductId = 35, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 104, ProductId = 35, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 105, ProductId = 35, ColorId = 6 }, // Rose

// Apple Watch Series 4
new ProductColorRelation { Id = 106, ProductId = 36, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 107, ProductId = 36, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 108, ProductId = 36, ColorId = 6 }, // Rose

// Apple Watch Series 3 LTE
new ProductColorRelation { Id = 109, ProductId = 37, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 110, ProductId = 37, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 111, ProductId = 37, ColorId = 6 }, // Rose

// Apple Watch SE (2ème génération)
new ProductColorRelation { Id = 112, ProductId = 38, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 113, ProductId = 38, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 114, ProductId = 38, ColorId = 6 }, // Rose

// Apple Watch Nike
new ProductColorRelation { Id = 115, ProductId = 39, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 116, ProductId = 39, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 117, ProductId = 39, ColorId = 6 }, // Rose

// Apple Watch Hermès
new ProductColorRelation { Id = 118, ProductId = 40, ColorId = 1 }, // Gris sidéral
new ProductColorRelation { Id = 119, ProductId = 40, ColorId = 2 }, // Argent
new ProductColorRelation { Id = 120, ProductId = 40, ColorId = 6 },
// Apple Watch Edition
new ProductColorRelation { Id = 121, ProductId = 41, ColorId = 3 }, // Or
new ProductColorRelation { Id = 122, ProductId = 41, ColorId = 4 }, // Vert
new ProductColorRelation { Id = 123, ProductId = 41, ColorId = 7 }, // Violet

// Apple Watch SE (1ère génération)
new ProductColorRelation { Id = 124, ProductId = 42, ColorId = 3 }, // Or
new ProductColorRelation { Id = 125, ProductId = 42, ColorId = 4 }, // Vert
new ProductColorRelation { Id = 126, ProductId = 42, ColorId = 7 }, // Violet

// Apple Watch Series 1
new ProductColorRelation { Id = 127, ProductId = 43, ColorId = 3 }, // Or
new ProductColorRelation { Id = 128, ProductId = 43, ColorId = 4 }, // Vert
new ProductColorRelation { Id = 129, ProductId = 43, ColorId = 7 }, // Violet

// iPhone 14
new ProductColorRelation { Id = 130, ProductId = 44, ColorId = 3 }, // Or
new ProductColorRelation { Id = 131, ProductId = 44, ColorId = 4 }, // Vert
new ProductColorRelation { Id = 132, ProductId = 44, ColorId = 7 }, // Violet

// iPhone 14 Pro
new ProductColorRelation { Id = 133, ProductId = 45, ColorId = 3 }, // Or
new ProductColorRelation { Id = 134, ProductId = 45, ColorId = 4 }, // Vert
new ProductColorRelation { Id = 135, ProductId = 45, ColorId = 7 }, // Violet

// iPhone 14 Pro Max
new ProductColorRelation { Id = 136, ProductId = 46, ColorId = 3 }, // Or
new ProductColorRelation { Id = 137, ProductId = 46, ColorId = 4 }, // Vert
new ProductColorRelation { Id = 138, ProductId = 46, ColorId = 7 }  // Violet
// Rose

// Apple Watch Edition
// Rose
);


        }
    }
}
