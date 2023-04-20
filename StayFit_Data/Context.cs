using Microsoft.EntityFrameworkCore;
using StayFit.StayFit_Data.Entity;
using Z.EntityFramework.Plus;


namespace StayFit.StayFit_Data;

public class Context:DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Exercice> Exercices { get; set; }
    public DbSet<NewsMessage> NewsMessages { get; set; }
    public DbSet<Payment>Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Routine> Routines { get; set; }
    public DbSet<User> Users { get; set; }
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Routine>()
            .HasMany(e => e.Exercices)
            .WithMany(e => e.Routines);


        modelBuilder.Entity<Routine>()
            .HasMany(e => e.Users)
            .WithMany(e => e.Routines);
            



        modelBuilder.Entity<Exercice>().ToTable("Exercice");
        modelBuilder.Entity<NewsMessage>().ToTable("NewsMessage");
        modelBuilder.Entity<Payment>().ToTable("Payment");
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<Routine>().ToTable("Routine");
        modelBuilder.Entity<User>().ToTable("User");

    }
    
}