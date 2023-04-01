using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using XMLApp.Mapper;
using XMLApp.NewFolder;
using XMLApp.Repository;
using XMLApp.Services;
using XMLApp.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
           });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("2022-01-01")
    }));

// Configure dependency injection
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Configure MongoDb settings
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
       serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

// Configure auto mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

app.Logger.LogInformation("jea");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
