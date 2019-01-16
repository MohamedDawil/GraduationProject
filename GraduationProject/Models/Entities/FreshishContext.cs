using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GraduationProject.Models.Entities
{
    public partial class FreshishContext : DbContext
    {
        public FreshishContext()
        {
        }

        public FreshishContext(DbContextOptions<FreshishContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FreshishDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("chat", "fresh");

                entity.Property(e => e.GiverId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.ReadById).HasMaxLength(450);

                entity.Property(e => e.ReceiverId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.SentById).HasMaxLength(450);

                entity.HasOne(d => d.Giver)
                    .WithMany(p => p.ChatGiver)
                    .HasForeignKey(d => d.GiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__chat__GiverId__49C3F6B7");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__chat__ProductId__5CD6CB2B");

                entity.HasOne(d => d.ReadBy)
                    .WithMany(p => p.ChatReadBy)
                    .HasForeignKey(d => d.ReadById)
                    .HasConstraintName("FK__chat__ReadById__6E01572D");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.ChatReceiver)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__chat__ReceiverId__4AB81AF0");

                entity.HasOne(d => d.SentBy)
                    .WithMany(p => p.ChatSentBy)
                    .HasForeignKey(d => d.SentById)
                    .HasConstraintName("FK__chat__SentById__5BE2A6F2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "fresh");

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.GiverId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Picture).IsRequired();

                entity.Property(e => e.ReceiverId).HasMaxLength(450);

                entity.Property(e => e.Street).IsRequired();

                entity.Property(e => e.ZipCode).IsRequired();

                entity.HasOne(d => d.Giver)
                    .WithMany(p => p.ProductGiver)
                    .HasForeignKey(d => d.GiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__GiverId__36B12243");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.ProductReceiver)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK__product__Receive__37A5467C");
            });
        }
    }
}
