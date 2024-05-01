using AutoMapper;
using MerchantsAPI.DbContexts;
using MerchantsAPI.DTOs;
using MerchantsAPI.Entities;
using MerchantsAPI_p2.EndpointHandlers;
using MerchantsAPI_p2.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MerchantDbContext>(
    o => o.UseSqlite(builder.Configuration["ConnectionStrings:MerchantDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add cache
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.RegisterMerchantsEndpoints();

app.Run();
