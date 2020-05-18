using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InstantMessage.DataModel.InstantMessageDB
{
    public partial class ImDbContext : DbContext
    {
        public ImDbContext()
        {
        }

        public ImDbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.;uid=sa;pwd=123456;database=InstantMessageDB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>(entity =>
            {
                entity.ToTable("Members");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ConnectionId)
                    .IsRequired()
                    .HasColumnName("ConnectionID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(100);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.ToTable("Messages");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
