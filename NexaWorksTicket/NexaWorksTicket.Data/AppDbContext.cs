using Microsoft.EntityFrameworkCore;

namespace NexaWorksTicket.Data
{
    public partial class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NexaWorksTicket;User=;Password=;TrustServerCertificate=True",

        public virtual DbSet<Os> Os { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductsVersion> ProductsVersions { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NexaWorksTicket", x => x.UseNetTopologySuite());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Os>(entity =>
            {
                entity.HasKey(e => e.OsId);

                entity.Property(e => e.OsName).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.HasOne(d => d.Version).WithMany(p => p.Products)
                    .HasForeignKey(d => d.VersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ProductsVersion");
            });

            modelBuilder.Entity<ProductsVersion>(entity =>
            {
                entity.HasKey(e => e.VersionId);

                entity.ToTable("ProductsVersion");

                entity.Property(e => e.VersionId).ValueGeneratedOnAdd();
                entity.Property(e => e.Version).HasMaxLength(10);

                entity.HasOne(d => d.Os).WithMany(p => p.ProductsVersions)
                    .HasForeignKey(d => d.OsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsVersion_Os");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).ValueGeneratedOnAdd();
                entity.Property(e => e.FixingDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.FixingStatus).HasDefaultValue(FixingStatus.Open);

                entity.HasOne(d => d.Product).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Products");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
