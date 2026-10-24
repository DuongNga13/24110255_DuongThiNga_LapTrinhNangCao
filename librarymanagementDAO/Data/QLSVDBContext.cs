using Microsoft.EntityFrameworkCore;
using librarymanagementDAO.Entities;

namespace LibraryManagemtDAO
{
    public class QLSVDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }

        public QLSVDBContext()
        {
        }

        public QLSVDBContext(DbContextOptions<QLSVDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string sqlServerConnection = @"Server=(localdb)\MSSQLLocalDB;Database=LibraryManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(sqlServerConnection);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.CategoryId).HasMaxLength(20);
                entity.Property(c => c.Description).HasMaxLength(255).IsRequired();
            });

            // Cấu hình Book (1 Category - Nhiều Book)
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");
                entity.HasKey(b => b.BookId);
                entity.Property(b => b.BookId).HasMaxLength(20);
                entity.Property(b => b.Title).HasMaxLength(200).IsRequired();
                entity.Property(b => b.Publisher).HasMaxLength(150);
                entity.Property(b => b.Author).HasMaxLength(100);
                entity.Property(b => b.Price).HasPrecision(18, 2);

                entity.HasOne(b => b.Category)
                      .WithMany(c => c.Books)
                      .HasForeignKey(b => b.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Cấu hình BookCopy (1 Book - Nhiều BookCopy)
            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.ToTable("BookCopies");
                entity.HasKey(bc => bc.BookCopyId);
                entity.Property(bc => bc.BookCopyId).HasMaxLength(20);
                entity.Property(bc => bc.Status).HasMaxLength(50);
                entity.Property(bc => bc.Condition).HasMaxLength(50);

                entity.HasOne(bc => bc.Book)
                      .WithMany(b => b.BookCopies)
                      .HasForeignKey(bc => bc.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
