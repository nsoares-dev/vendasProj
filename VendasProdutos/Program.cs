﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendasProdutos.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VendasProdutosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VendasProdutosContext") ?? throw new InvalidOperationException("Connection string 'VendasProdutosContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// serviços de authentication
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<VendasProdutosContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
