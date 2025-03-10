using Microsoft.EntityFrameworkCore;
using NexaWorksTicket.Models.Bdd;

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

        public virtual DbSet<ProductVersionOs> ProductVersionOs { get; set; }

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
            });

            modelBuilder.Entity<ProductVersionOs>(entity =>
            {
                entity.HasKey(e => e.IdProductVersionOs).HasName("PK_ProductVersionOs");

                entity.Property(e => e.IdProductVersionOs).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdOsNavigation).WithMany(p => p.ProductVersionOs)
                    .HasForeignKey(d => d.IdOs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductVersionOs_Os");

                entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductVersionOs)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductVersionOs_Products");

                entity.HasOne(d => d.IdVersionNavigation).WithMany(p => p.ProductVersionOs)
                    .HasForeignKey(d => d.IdVersion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductVersionOs_ProductsVersion");
            });

            modelBuilder.Entity<ProductsVersion>(entity =>
            {
                entity.HasKey(e => e.VersionId);

                entity.ToTable("ProductsVersion");

                entity.Property(e => e.Version).HasMaxLength(10);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ProductVersionOs).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ProductVersionOsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_ProductVersionOs");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
