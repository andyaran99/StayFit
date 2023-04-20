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
        if (_context.Exercices.Any())
        {
            return;
        }
        if (_context.Routines.Any())
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
                Description = "We are planning to hold a special fitness class for the sport day. "+"\n"+
                              "The intrested menbers can come to the jim at 16:00 at third floor ",
            },
            new()
            {
                Title = "Changes to gym",
                Description = "Whe are happy to announce that we added some new equippenemt for our members",
                
            }
        };
        var exercice = new Exercice[]
        {
             new()
            {
                DateTime = 15,
                Name = "Push ups",
                Description =
                    "The push-up (sometimes called a press-up in British English) is a common calisthenics exercise beginning from the prone position.  By raising and lowering the body using the arms, push-ups exercise the pectoral muscles, triceps, and anterior deltoids, with ancillary benefits to the rest of the deltoids, serratus anterior, coracobrachialis and the midsection as a whole.[1] Push-ups are a basic exercise used in civilian athletic training or physical education and commonly in military physical training. They are also a common form of punishment used in the military, school sport, and some martial arts disciplines.",
                Routines = new List<Routine>()

            },

        };
        
        var routine = new Routine[]
        {
            new()
            {
                Name = "Strength 1",
                BodyType = BodyType.Mesomorph,
                RoutineType = RoutineType.Strenght,
                DateTime = 60,
                Exercices = new List<Exercice>()
            },
        };


        
      
        
        _context.Routines.AddRange(routine);
        _context.Exercices.AddRange(exercice);
        _context.NewsMessages.AddRange(newMessage);
        _context.Products.AddRange(products);
        
        exercice[0].Routines.Add(routine[0]);
        routine[0].Exercices.Add(exercice[0]);
        _context.SaveChanges();
            
            
            
    }
}