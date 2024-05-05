using AutoMapper;
using MerchantsAPI.DbContexts;
using MerchantsAPI.DTOs;
using MerchantsAPI.Entities;
using MerchantsAPI_p2.EndpointHandlers;
using MerchantsAPI_p2.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MerchantDbContext>(
    o => o.UseSqlite(builder.Configuration["ConnectionStrings:MerchantDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add cache
builder.Services.AddMemoryCache();

// Add a service to return error explaination
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    // Catch all exceptions
    /*
    app.UseExceptionHandler(configureApplicationBuilder =>
       {
           configureApplicationBuilder.Run(
           async context =>
           {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("An unexpected problem happened");
            });
       });
    */

    // Catch all exception with details explain from AddProblemDetails
    app.UseExceptionHandler();
}
app.UseHttpsRedirection();

app.RegisterMerchantsEndpoints();

app.Run();
