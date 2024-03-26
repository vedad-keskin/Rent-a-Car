using Microsoft.EntityFrameworkCore;
using GMS.Helpers.Services;
using GMS.Helpers.Auth;
using RentACar.Service.Interface;
using RentACar.Service.Methods;
using RentACar.DBContext;
using RentACar.Service;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("db1")));

//builder.Services.AddDbContext<LogDbContext>(options =>
//    options.UseSqlServer(config.GetConnectionString("dblog")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.OperationFilter<AutorizacijaSwaggerHeader>());
builder.Services.AddTransient<MyAuthService>();
builder.Services.AddTransient<MyActionLogService>();
builder.Services.AddTransient<MyEmailSenderService>();
builder.Services.AddHttpContextAccessor();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment()) ---> da se swagger otvara nakon deploya 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(
    options => options
        .SetIsOriginAllowed(x => _ = true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
); //This needs to set everything allowed


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
