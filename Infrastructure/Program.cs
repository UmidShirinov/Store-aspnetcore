using Core.Entities;
using Core.Repositories.Repository;
using Core.Repositories.UserRepository;
using Core.Services.AuthService;
using Core.Services.UnitOfWork;
using Infrastructure.Contex;
using Infrastructure.Services.AuthService;
using Infrastructure.Services.PasswordHashService;
using Infrastructure.Services.UnitOfWork;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);



	builder.Services.AddDbContext<ApplicationDbContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Generic Repository-ler üçün qeyd etme
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<IRepository<OrderItem>, Repository<OrderItem>>();
builder.Services.AddScoped<IRepository<Basket>, Repository<Basket>>();
builder.Services.AddScoped<IRepository<BasketItem>, Repository<BasketItem>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
//builder.Services.AddScoped<IAuthService, Authservice>();


var app = builder.Build();
