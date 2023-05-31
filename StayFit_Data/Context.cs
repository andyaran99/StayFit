using Microsoft.EntityFrameworkCore;
using StayFit.StayFit_Data.Entity;
using Z.EntityFramework.Plus;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace StayFit.StayFit_Data;

public class Context:IdentityUserContext<IdentityUser>
{
    public Context(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Exercice> Exercices { get; set; }
    public DbSet<NewsMessage> NewsMessages { get; set; }
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
            



        modelBuilder.Entity<Exercice>().ToTable("Exercices");
        modelBuilder.Entity<NewsMessage>().ToTable("NewsMessages");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Routine>().ToTable("Routines");
        

    }
    
}