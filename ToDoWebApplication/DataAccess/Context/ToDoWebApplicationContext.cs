using ToDoWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToDoWebApplication.DataAccess.Context
{
    public partial class ToDoWebApplicationContext : DbContext
    {
        public ToDoWebApplicationContext()
        {
        }

        public ToDoWebApplicationContext(DbContextOptions<ToDoWebApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Task> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();

                entity.Property(e => e.Date).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.IsDone);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Task_Category");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
