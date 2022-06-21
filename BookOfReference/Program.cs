global using BookOfReference.Service.Interfaces;
using BookOfReference;
using BookOfReference.Interfaces;
using BookOfReference.Repositories;
using BookOfReference.Repositories.Interfaces;
using BookOfReference.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddControllers();

builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IDepartamentRepository,DepartamentRepository>();

builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IDepartamentService, DepartamentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
