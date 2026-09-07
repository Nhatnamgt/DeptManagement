using DeptManagement.Repository.Models;
using DeptManagement.Repository.UnitOfWork;
using DeptManagement.Service.Interface;
using DeptManagement.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<QuanLiNapRut, QuanLiNapRutService>();
builder.Services.AddScoped<QuanLiKhoanNo, QuanLiKhoanNoService>();
builder.Services.AddScoped<ChiTietKhoanVays, ChiTietKhoanVayService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

//// Keep databases created from the original schema compatible with the note
//// fields used by the current API and Razor Pages. The statements are
//// idempotent, so they are also safe for already-updated databases.
//await using (var scope = app.Services.CreateAsyncScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    await db.Database.ExecuteSqlRawAsync("""
//        ALTER TABLE IF EXISTS quanlynaprut ADD COLUMN IF NOT EXISTS ghichu TEXT;
//        ALTER TABLE IF EXISTS chitietkhoanvay ADD COLUMN IF NOT EXISTS ghichu TEXT;
//        """);
//}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseCors("AllowFrontend");

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseAuthorization();

app.MapControllers();

app.Run();
