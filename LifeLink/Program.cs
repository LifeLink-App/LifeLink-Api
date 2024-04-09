using System.Text;
using LifeLink;
using LifeLink.Persistence;
using LifeLink.Repositories.EvacPersons;
using LifeLink.Repositories.Users;
using LifeLink.Services.EvacPersons;
using LifeLink.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

{    
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = Security.Issuer,
            ValidAudience = Security.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Security.SecureKey)
            ),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,           
        };
    });
    builder.Services.AddAuthorization();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();

    // services
    builder.Services.AddScoped<IEvacPersonService, EvacPersonService>();
    builder.Services.AddScoped<IUserService, UserService>();
    
    // repositories
    builder.Services.AddScoped<IEvacPersonRepository, EvacPersonRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    builder.Services.AddDbContext<LifeLinkDbContext>(options => 
    {
        options.UseNpgsql(Connection.ConnectionString());
    });
}

var app = builder.Build();

//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}