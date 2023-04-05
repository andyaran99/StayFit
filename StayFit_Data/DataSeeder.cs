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
        
        if (_context.Products.Any())
        {
            return;
        }
        
        if (_context.NewsMessages.Any())
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
        
        var newMessage = new NewsMessage[]
        {
            new()
            {
                Title = "Aerobic Hour",
                Description = "the aerobic class will be held at the second floor at 14:00",
                
                    
                    
            },
            new()
            {
                Title= "Special fitness hour",
                Description = "We are planning to hold a special fitness class for the sport day. The intrested menbers can " +
                              "come to the jim at 16:00 at third floor ",
            },
            new()
            {
                Title = "Changes to gym",
                Description = "Whe are happy to announce that we added some new equippenemt for our members",
                
            }
        };
            _context.NewsMessages.AddRange(newMessage);
            _context.Products.AddRange(products);
            _context.SaveChanges();
            
            
            
    }
}