using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace energy_backend;

public partial class EnergyContext : DbContext
{
    public EnergyContext()
    {
    }

    public EnergyContext(DbContextOptions<EnergyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EnergyDrink> EnergyDrinks { get; set; }

    public virtual DbSet<EnergyDrinkPhoto> EnergyDrinkPhotos { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostPhoto> PostPhotos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-9RTLIH5;Initial Catalog=energy;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnergyDrink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("primary_key_id");

            entity.ToTable("energy_drinks");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.CoffeineCount).HasColumnName("coffeine_count");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Flavor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("flavor");
            entity.Property(e => e.Ingridients)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ingridients");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NutritionInfo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("nutrition_info");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.SugarCount).HasColumnName("sugar_count");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<EnergyDrinkPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__energy_d__3213E83FA09697EA");

            entity.ToTable("energy_drink_photos");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.EnergyDrinkId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("energy_drink_id");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("photo_url");

            entity.HasOne(d => d.EnergyDrink).WithMany(p => p.EnergyDrinkPhotos)
                .HasForeignKey(d => d.EnergyDrinkId)
                .HasConstraintName("FK__energy_dr__photo__5AEE82B9");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__posts__3213E83FD21E1FCE");

            entity.ToTable("posts");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__posts__updated_a__5EBF139D");
        });

        modelBuilder.Entity<PostPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post_pho__3213E83F71B0399B");

            entity.ToTable("post_photo");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("photo_url");
            entity.Property(e => e.PostId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("post_id");

            entity.HasOne(d => d.Post).WithMany(p => p.PostPhotos)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post_phot__photo__619B8048");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F30F1663A");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("photo_url");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
