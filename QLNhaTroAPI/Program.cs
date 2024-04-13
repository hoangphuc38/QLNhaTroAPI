using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLNhaTroAPI.Data;
using QLNhaTroAPI.Models;
using QLNhaTroAPI.Repositories;
using QLNhaTroAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INguoiRepo, NguoiRepo>();
builder.Services.AddScoped<IPhongRepo, PhongRepo>();
builder.Services.AddScoped<IBangGiaRepo, BangGiaRepo>();
builder.Services.AddScoped<IHoaDonPhongRepo, HoaDonPhongRepo>();
builder.Services.AddScoped<ITongKetRepo, TongKetRepo>();
builder.Services.AddScoped<ITaiKhoanRepo, TaiKhoanRepo>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin() // Add your production origins as needed
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
