using Application.App.Commands.UserCommands.RegisterUser;
using Application.App.Queries.UserQueries.LoginUser;
using Core.Services.AuthService;
using Core.Services.UnitOfWork;
using FluentValidation;
using Infrastructure.Services.AuthService;
using Infrastructure.Services.PasswordHashService;
using Infrastructure.Services.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly));

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IPasswordService, PasswordService>();
//builder.Services.AddScoped<IAuthService, Authservice>();

var app = builder.Build();



app.Run();
