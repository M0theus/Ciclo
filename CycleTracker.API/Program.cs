using System.Text;
using AutoMapper;
using CycleTracker.Application.Contracts.Services;
using CycleTracker.Application.Dto.V1.User;
using CycleTracker.Application.Notifications;
using CycleTracker.Application.Services;
using CycleTracker.Domain.Contracts.Repositories;
using CycleTracker.Domain.Entity;
using CycleTracker.Infra.Context;
using CycleTracker.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Mapper

// Add Dto AutoMapper
var autoMapperConfig = new MapperConfiguration(cfg =>
{
    var autoMapperConfig = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<User, UsuarioDto>();
        cfg.CreateMap<UsuarioDto, User>();

        cfg.CreateMap<User, CadastrarUsuarioDto>();
        cfg.CreateMap<CadastrarUsuarioDto, User>()
            .ForMember(dest => dest.Ciclo, opt => opt.Ignore());

        cfg.CreateMap<UsuarioDto, AlterarUsuarioDto>();
        cfg.CreateMap<AlterarUsuarioDto, UsuarioDto>();
    });

});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

// Add Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INotificator, Notificator>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Add Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region MySql

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
});

#endregion

/*#region Jwt

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }) 
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion
*/
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