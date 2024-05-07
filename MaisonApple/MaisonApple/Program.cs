// ---------------------------------------------------------------
// Copyright (c). All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------
using BL.Interfaces;
using BL.Managers;
using BL.Mapper;
using DAL;
using DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<MaisonAppleContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly("MaisonApple")));

builder.Services.AddAuthorization();

//builder.Services.AddIdentityApiEndpoints<IdentityUser>(opt =>
//{
//    opt.Password.RequiredLength = 8;
//    opt.User.RequireUniqueEmail = true;
//    opt.Password.RequireNonAlphanumeric = false;
//    opt.SignIn.RequireConfirmedEmail = true;
//})
//    .AddDefaultUI()
//    .AddEntityFrameworkStores<MaisonAppleContext>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddTransient<IProductManager, ProductManager>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddTransient<IProductImageManager, ProductImageManager>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
//app.MapIdentityApi<IdentityUser>(); 

app.UseHttpsRedirection();

app.MapControllers();

//app.Use(async (context, next) => { Console.WriteLine(string.Join("\n", app.Urls)); await next.Invoke(); });

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapRazorPages();  // Assurez-vous d'inclure vos autres mappings ici comme endpoints.MapControllers();
//    app.Use(async (context, next) =>
//    {
//        var endpointDataSource = app.Services.GetRequiredService<Microsoft.AspNetCore.Routing.EndpointDataSource>();
//        foreach (var endpoint in endpointDataSource.Endpoints)
//        {
//            var routeEndpoint = endpoint as RouteEndpoint;
//            if (routeEndpoint != null)
//            {
//                Console.WriteLine($"{routeEndpoint.RoutePattern.RawText} {routeEndpoint.Metadata.GetMetadata<Microsoft.AspNetCore.Http.HttpMethodMetadata>()?.HttpMethods.FirstOrDefault()}");
//            }
//        }
//        await next();
//    });
//});

app.Run();
