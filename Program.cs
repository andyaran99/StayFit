using System.Text.Json.Serialization;
using StayFit.StayFit_Data;
using StayFit.StayFit_Data.Repositories;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using StayFit.StayFit_Data.Repositories.Repositories;
using StayFit.StayFit_Data.Services.PasswordHasher;


namespace StayFit
{
    public class Program
    {
        public static void Main(string[] args)
    {
        var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

        var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: myAllowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins("http://localhost:3000",
                        "https://icy-mushroom-0411fdf0f.1.azurestaticapps.net")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
    

    builder.Services.AddControllers()
        .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add database service
    builder.Services.AddDbContext<Context>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

    
    
    builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
    builder.Services.AddScoped<IRepository<NewsMessage>, NewsMessageRepository>();
    builder.Services.AddScoped<IRepository<Exercice>, ExerciceRepository>();
    builder.Services.AddScoped<IRepository<Routine>, RoutineRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
   
    
    
    
    
    builder.Services.AddScoped<ProductService>();
    builder.Services.AddScoped<NewsMessageService>();
    builder.Services.AddScoped<ExerciceService>();
    builder.Services.AddScoped<RoutineService>();
    builder.Services.AddScoped<UserService>();
    
    
    builder.Services.AddScoped<DataSeeder>();
    
    
    builder.Services
        .AddIdentityCore<IdentityUser>(options => {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddEntityFrameworkStores<Context>();
    
    // Configure the HTTP request pipeline.
    
    
    
    var app = builder.Build();
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var initialiser = services.GetRequiredService<DataSeeder>();
    initialiser.Seed();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    

    app.UseCors(myAllowSpecificOrigins);

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    }
    }
    
        
}

