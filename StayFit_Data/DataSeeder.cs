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

         var products = new Product[]
            {
                new()
                {
                    Title = "Smart Air",
                    Description = "Unlike conventional air conditioners, our Smart ACs allow you to maintain your home temperature using a smartphone.",
                    
                },
                new()
                {
                    Title= "Smart Fridge",
                    Description = "Our smart fridge is more than a fridge. Keep your family organized, prep meals, entertain in the kitchen, control your smart devices, and more."
                },
                new()
                {
                    Title = "Smart Oven",
                    Description = "Our Smart Oven offers incredible versatility and precision, giving you greater control of your toasting, roasting, air frying and more."
                }
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();
            
            
            
    }
}