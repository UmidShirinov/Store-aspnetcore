


using Application.App.Commands.UserCommands.RegisterUser;
using Application.App.Queries.UserQueries.LoginUser;
using Core.Services.AuthService;
using Core.Services.UnitOfWork;
using FluentValidation;
using Infrastructure.Contex;
using Infrastructure.Extentions;
using Infrastructure.Services.AuthService;
using Infrastructure.Services.PasswordHashService;
using Infrastructure.Services.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add MediatR for Application Layer
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserQueryHandler).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddJwtAuthentication(builder.Configuration);
// Add AutoMapper
builder.Services.AddAutoMapper(typeof(RegisterUserCommandHandler).Assembly);

// Add FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(RegisterUserCommandHandler).Assembly);
builder.Services.AddScoped<IAuthService, Authservice>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
