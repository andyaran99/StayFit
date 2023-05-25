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
             
             new()
             {
                 DateTime = 15,
                 Name="Pull ups on bar",
                 Description = "Pull-ups are a functional bodyweight exercise that is great for building upper-body strength, however, they are commonly known as one of those hard-to-master exercises that can be tricky for beginners.Despite common misconceptions, it’s possible for anyone — even those without strong arm and back muscles — to conquer a pull-up. You just need to know where and how to start, learn the correct form, and put in the time and effort. ",
                 Routines = new List<Routine>(),
             },
             
             new()
             {
                 DateTime = 10,
                 Name = "Chest Press",
                 Description = "The chest press strength training exercise works the pectoral muscles of the chest. You can use a variety of equipment, including dumbbells, barbells, a Smith machine, suspension trainer, or even resistance bands, to perform a chest press.A qualified trainer is recommended to guide you through appropriate execution of a chess press, especially if you plan to workout in a home gym. The chest press can be part of an upper body strength workout or muscle building workout.",
                 Routines = new List<Routine>()
             },
             
             new()
             {
                 DateTime = 10,
                 Name = "Tricep Pushdowns",
                 Description = "The tricep pushdown is one of the best exercises for tricep development. While the versatile upper-body workout is usually done on a cable machine (a fixture at most gyms), you can also perform a version of the move at home or on the go using a resistance band.",
                 Routines = new List<Routine>()
             }

        };
        
        var routine = new Routine[]
        {
            new()
            {
                Name = "Upperbody exercices - veterans",
                BodyType = BodyType.Mesomorph.ToString(),
                RoutineType = RoutineType.Strenght.ToString(),
                DateTime = 60,
                Exercices = new List<Exercice>()
            },
            
            new()
            {
                Name = "Upperbody exercices - beginners",
                BodyType = BodyType.Mesomorph.ToString(),
                RoutineType = RoutineType.Strenght.ToString(),
                DateTime = 45,
                Exercices = new List<Exercice>()
            },
            
            new()
            {
                Name = "Arms beginners",
                BodyType = BodyType.Mesomorph.ToString(),
                RoutineType = RoutineType.Strenght.ToString(),
                DateTime = 30,
                Exercices = new List<Exercice>()
            }
        };

        

        
      
        
        _context.Routines.AddRange(routine);
        _context.Exercices.AddRange(exercice);
        _context.NewsMessages.AddRange(newMessage);
        _context.Products.AddRange(products);
        
        
        exercice[0].Routines.Add(routine[0]);
        exercice[0].Routines.Add(routine[1]);
        exercice[1].Routines.Add(routine[0]);
        exercice[2].Routines.Add(routine[2]);
        exercice[3].Routines.Add(routine[2]);
        routine[0].Exercices.Add(exercice[0]);
        routine[0].Exercices.Add(exercice[1]);
        routine[1].Exercices.Add(exercice[0]);
        routine[2].Exercices.Add(exercice[2]);
        routine[2].Exercices.Add(exercice[3]);
        
        _context.SaveChanges();
            
            
            
    }
}