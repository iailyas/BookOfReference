
using Domain.RepositryInterfaces;
using Domain.Service;
using Domain.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddControllers();

builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IDepartamentRepository, DepartamentRepository>();
builder.Services.AddTransient<IPositionRepository, PositionRepository>();
builder.Services.AddTransient<ISalaryRepository, SalaryRepository>();
builder.Services.AddTransient<IWorkerRepository, WorkerRepository>();


builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IDepartamentService, DepartamentService>();
builder.Services.AddTransient<IPositionService, PositionService>();
builder.Services.AddTransient<ISalaryService, SalaryService>();
builder.Services.AddTransient<IWorkerService, WorkerService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthentication();
    app.UseAuthorization();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
