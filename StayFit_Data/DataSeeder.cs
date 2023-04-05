using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data;

public class DataSeeder
{
    private readonly Context _context;

    public DataSeeder(Context context)
    {
        _context = context;
    }

    public void Seed()
    {
        _context.Database.EnsureCreated();
        if (_context.Payments.Any())
        {
            return;
        }
        var products = new Product[]
            {
                new()
                {
                    Name = "Basic package",
                    Description = "Access to the gym",
                    Price = 20
                    
                    
                },
                new()
                {
                    Name= "Dynamic package",
                    Description = "Access to the gym and to aerobic classes ",
                    Price = 30
                },
                new()
                {
                    Name = "Complete Package",
                    Description = "Access to gym, aerobic classes,spa and sawna",
                    Price = 40
                }
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();
            
            
            
    }
}