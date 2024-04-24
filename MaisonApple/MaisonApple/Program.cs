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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MaisonAppleContext>(options =>
        options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddTransient<IProductManager, ProductManager>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddTransient<IProductImageManager, ProductImageManager>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();




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
