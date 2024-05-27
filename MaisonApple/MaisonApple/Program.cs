// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using System.Text;
using BL;
using BL.Interfaces;
using BL.Managers;
using BL.Mapper;
using DAL;
using DAO;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MaisonAppleContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));






builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddTransient<IProductManager, ProductManager>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddTransient<IProductImageManager, ProductImageManager>();
builder.Services.AddTransient<IAuthentificationManager, AuthentificationManager>();
builder.Services.AddTransient<ICommandManager, CommandManager>();
builder.Services.AddTransient<INotificationManager, NotificationManager>();


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.Configure<JWTConfiguration>(builder.Configuration.GetSection("JWTConfiguration"));
builder.Services.AddTransient(provider =>
{
    var config = new JWTConfiguration();
    config.Initialize(provider.GetRequiredService<IOptions<JWTConfiguration>>());
    return config;
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddIdentity<User, IdentityRole>()
          .AddEntityFrameworkStores<MaisonAppleContext>();
string secretKey = builder.Configuration["JWTConfiguration:SecritKey"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //[authore ]:found toke or not
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //account/loginresonse unauthorize
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    if (secretKey != null)
    {
        // Utiliser la clé secrète pour configurer les paramètres de validation du token
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWTConfiguration:ValidIss"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWTConfiguration:ValidAud"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    }
    else
    {
        // Gérer le cas où la clé secrète est null
        // Par exemple, lever une exception ou afficher un message d'erreur
        throw new InvalidOperationException("La clé secrète JWT n'est pas définie dans la configuration.");
    }
});
/////////////////////////////////
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation    
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Maison Apple",
        Description = "Maison Apple"
    });
    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    }
                    },
                    new string[] {}
                    }
                    });
});
var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();
