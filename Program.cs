using Microsoft.Extensions.Configuration;
using Tcc_MeAdote_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Tcc_MeAdote_API.Repositories.UserRepository;
using Tcc_MeAdote_API.Repositories.UserLoginRepositories;
using Tcc_MeAdote_API.Repositories.UserAdressRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<Context>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("ConnectionDbMeu")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
builder.Services.AddScoped<IUserAdressRepository, UserAdressRepository>();

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
