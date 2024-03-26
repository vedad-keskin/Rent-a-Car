using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using RentACar.DBContext;
using RentACar.Service.Interface;
using RentACar.Service.Methods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//dependency injection
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICarDetailsService, CarDetailsService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<ICarImagesService, CarImagesService>();
builder.Services.AddScoped<ICarRentService, CarRentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IRentDateService, RentDateService>();
builder.Services.AddScoped<IUserDetailsService, UserDetailsService>();
builder.Services.AddScoped<IRecensionsService, RecensionsService>();
builder.Services.AddScoped<INewsFeedService,NewsFeedService>();
builder.Services.AddScoped<IPaymentsService,PaymentsService>();
// Build configuration
IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

// Read connection string
string connectionString = configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<DbSetContext>(options =>
            options.UseSqlServer(connectionString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
