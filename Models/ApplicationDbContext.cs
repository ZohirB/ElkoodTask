using Microsoft.EntityFrameworkCore;

namespace ElkoodTask.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<BranchType> BranchTypes { get; set; }
    public DbSet<CompanyInfo> CompanyInfo { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<BranchInfo> BranchInfo { get; set; }
    public DbSet<ProductInfo> ProductInfo { get; set; }
    public DbSet<ProductionOperation> ProductionOperations { get; set; }
    public DbSet<DistributionOperation> DistributionOperations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BranchInfo>()
            .HasMany(a => a.ProductionOperations)
            .WithOne(b => b.BranchInfo)
            .HasForeignKey(b => b.BranchInfoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductInfo>()
            .HasMany(a => a.ProductionOperations)
            .WithOne(b => b.ProductInfo)
            .HasForeignKey(b => b.ProductInfoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BranchInfo>()
            .HasMany(a => a.DistributionOperations)
            .WithOne(b => b.PrimaryBranchInfo)
            .HasForeignKey(b => b.PrimaryBranchInfoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DistributionOperation>()
            .HasOne(d => d.PrimaryBranchInfo)
            .WithMany()
            .HasForeignKey(d => d.PrimaryBranchInfoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DistributionOperation>()
            .HasOne(d => d.SecondaryBranchInfo)
            .WithMany()
            .HasForeignKey(d => d.SecondaryBranchInfoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductInfo>()
            .HasMany(a => a.DistributionOperations)
            .WithOne(b => b.ProductInfo)
            .HasForeignKey(b => b.ProductInfoId)
            .OnDelete(DeleteBehavior.Restrict);

        /*
            there is better way to do data seeding than the way i'm doing it
            but i'm still super extra noobie in asp.net :-|
        */

        modelBuilder.Entity<BranchType>()
            .HasData(
                new BranchType { Id = 1, Name = "Primary" },
                new BranchType { Id = 2, Name = "Secondary" }
            );

        modelBuilder.Entity<CompanyInfo>()
            .HasData(
                new CompanyInfo
                {
                    Id = 1, Name = "Tesla", Location = "Austin, Texas, USA",
                    EstablishmentDate = DateTime.Parse("2003-07-01"), Activity = "Electric Vehicles"
                },
                new CompanyInfo
                {
                    Id = 2, Name = "SpaceX", Location = "Hawthorne, California, USA",
                    EstablishmentDate = DateTime.Parse("2002-03-14"), Activity = "Spacecraft Technology"
                },
                new CompanyInfo
                {
                    Id = 3, Name = "Apple", Location = "Cupertino, California, USA",
                    EstablishmentDate = DateTime.Parse("1976-04-01"), Activity = "Technology Company"
                }
            );

        modelBuilder.Entity<ProductType>()
            .HasData(
                new ProductType { Id = 1, Name = "Mobil" },
                new ProductType { Id = 2, Name = "Laptop" },
                new ProductType { Id = 3, Name = "Car" },
                new ProductType { Id = 4, Name = "Rocket" }
            );

        modelBuilder.Entity<BranchInfo>()
            .HasData(
                new BranchInfo
                {
                    Id = 1, Name = "Gigafactory Nevada", BranchTypeId = 1, CompanyInfoId = 1, Location = "Nevada State"
                },
                new BranchInfo
                {
                    Id = 2, Name = "Texas Store", BranchTypeId = 2, CompanyInfoId = 1, Location = "Texas, California"
                },
                new BranchInfo
                {
                    Id = 3, Name = "Hawthorne Headquarters", BranchTypeId = 1, CompanyInfoId = 2,
                    Location = "California State"
                },
                new BranchInfo { Id = 4, Name = "NASA Store", BranchTypeId = 2, CompanyInfoId = 2, Location = "USA" },
                new BranchInfo
                    { Id = 5, Name = "Washington", BranchTypeId = 1, CompanyInfoId = 3, Location = "Washington State" },
                new BranchInfo
                    { Id = 6, Name = "New York", BranchTypeId = 1, CompanyInfoId = 3, Location = "New York State" },
                new BranchInfo
                {
                    Id = 7, Name = "Nanjing East store", BranchTypeId = 2, CompanyInfoId = 3,
                    Location = "Shanghai, China"
                }
            );

        modelBuilder.Entity<ProductInfo>()
            .HasData(
                new ProductInfo { Id = 1, Name = "iphone 15", ProductTypeId = 1 },
                new ProductInfo { Id = 2, Name = "Macbook Air", ProductTypeId = 2 },
                new ProductInfo { Id = 3, Name = "Falcon 9", ProductTypeId = 4 },
                new ProductInfo { Id = 4, Name = "Model S", ProductTypeId = 3 },
                new ProductInfo { Id = 5, Name = "iphone 16", ProductTypeId = 1 }
            );
        modelBuilder.Entity<ProductionOperation>()
            .HasData(
                new ProductionOperation
                {
                    Id = 1, BranchInfoId = 1, ProductInfoId = 4, Quantity = 1000, RemainingQuantity = 1000,
                    Date = DateTime.Parse("2012-06-22")
                },
                new ProductionOperation
                {
                    Id = 2, BranchInfoId = 3, ProductInfoId = 3, Quantity = 40, RemainingQuantity = 40,
                    Date = DateTime.Parse("2010-12-01")
                },
                new ProductionOperation
                {
                    Id = 3, BranchInfoId = 5, ProductInfoId = 1, Quantity = 50000, RemainingQuantity = 50000,
                    Date = DateTime.Parse("2024-10-01")
                },
                new ProductionOperation
                {
                    Id = 4, BranchInfoId = 6, ProductInfoId = 1, Quantity = 15000, RemainingQuantity = 15000,
                    Date = DateTime.Parse("2024-11-01")
                },
                new ProductionOperation
                {
                    Id = 5, BranchInfoId = 6, ProductInfoId = 5, Quantity = 25000, RemainingQuantity = 25000,
                    Date = DateTime.Parse("2025-10-01")
                },
                new ProductionOperation
                {
                    Id = 6, BranchInfoId = 5, ProductInfoId = 2, Quantity = 10000, RemainingQuantity = 10000,
                    Date = DateTime.Parse("2020-01-01")
                },
                new ProductionOperation
                {
                    Id = 7, BranchInfoId = 5, ProductInfoId = 1, Quantity = 15000, RemainingQuantity = 15000,
                    Date = DateTime.Parse("2025-01-01")
                }
            );
    }
}