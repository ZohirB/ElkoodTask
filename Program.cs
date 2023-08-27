using ElkoodTask;
using ElkoodTask.Repositories.BranchInfoRepository;
using ElkoodTask.Repositories.BranchTypeRepository;
using ElkoodTask.Repositories.CompanyInfoRepository;
using ElkoodTask.Repositories.DistributionOperationRepository;
using ElkoodTask.Repositories.ProductionOperationRepository;
using ElkoodTask.Repositories.ProductProducedRepository;
using ElkoodTask.Repositories.ProductsInfoRepository;
using ElkoodTask.Repositories.ProductTypeRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectiosString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddTransient<DataSeeder>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectiosString)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddTransient<IBranchTypesService, BranchTypesService>();
builder.Services.AddTransient<IBranchesInfoService, BranchesInfoService>();
builder.Services.AddTransient<IProductTypesService, ProductTypesService>();
builder.Services.AddTransient<IProductProducedService, ProductProducedService>();
builder.Services.AddTransient<ICompaniesInfoService, CompaniesInfoService>();
builder.Services.AddTransient<IDistributionOperationService, DistributionOperationService>();
builder.Services.AddTransient<IProductionOperationService, ProductionOperationsService>();
builder.Services.AddTransient<IProductsInfoService, ProductsInfoService>();


builder.Services.AddMediatR(typeof(Startup));
builder.Services.AddCors();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Elkood - Backend Task",
        Description = "Mini software system With API",
        //TermsOfService = new Uri("https://www.google.com"),
        Contact = new OpenApiContact
        {
            Name = "Zohir Boshi",
            Email = "zohirboshi@gmail.com"
            //Url = new Uri("https://www.google.com")
        },
        License = new OpenApiLicense
        {
            Name = "My license"
            //Url = new Uri("https://www.google.com")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();
app.Run();


namespace ElkoodTask
{
    public class Startup
    {
    }
}

//GG Last Commit 