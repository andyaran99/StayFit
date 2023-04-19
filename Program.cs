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
   
    
    
    
    
    builder.Services.AddScoped<ProductService>();
    builder.Services.AddScoped<NewsMessageService>();
    builder.Services.AddScoped<ExerciceService>();
    builder.Services.AddScoped<RoutineService>();
    
    
    builder.Services.AddScoped<DataSeeder>();
    /*
    // Add data repository services
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    
    
    builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
    builder.Services.AddScoped<IRepository<Partner>, PartnerRepository>();
    builder.Services.AddScoped<IRepository<Device>, DeviceRepository>();
    builder.Services.AddScoped<IRepository<Service>, ServiceRepository>();

    // Authentication services
    builder.Services.AddScoped<Authenticator>();
    builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:AccessTokenSecret"])),
            ValidIssuer = builder.Configuration["Authentication:Audience"],
            ValidAudience = builder.Configuration["Authentication:Issuer"],
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ClockSkew = TimeSpan.Zero
        };
    });

    // Add data logic services
    builder.Services.AddScoped<UserService>();
    
    builder.Services.AddScoped<IOrderService, OrderService>();
    builder.Services.AddScoped<IPartnersService, PartnersService>();
    builder.Services.AddScoped<CustomerService>();
    builder.Services.AddScoped<DeviceService>();
    builder.Services.AddScoped<ServiceService>();



    builder.Services.AddScoped<DataSeeder>();


    var app = builder.Build();

    
    */

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

