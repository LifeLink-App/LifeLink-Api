using System.Text;
using LifeLink.Persistence;
using LifeLink.Repositories.EvacPersons;
using LifeLink.Repositories.Parameters;
using LifeLink.Repositories.Users;
using LifeLink.Services.EvacPersons;
using LifeLink.Services.Parameters;
using LifeLink.Services.Users;
using LifeLink.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

{    
    builder.Services.AddAuthentication(x => {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new ArgumentException("JWT Key is not configured in the application."))
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
    builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
    builder.Services.AddControllers();

    // services
    builder.Services.AddScoped<IParameterService, ParameterService>();
    builder.Services.AddScoped<IEvacPersonService, EvacPersonService>();
    builder.Services.AddScoped<IUserService, UserService>();
    
    // repositories
    builder.Services.AddScoped<IParameterRepository, ParameterRepository>();
    builder.Services.AddScoped<IEvacPersonRepository, EvacPersonRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    builder.Services.AddDbContext<LifeLinkDbContext>(options => 
    {
        options.UseNpgsql($"Host={builder.Configuration["PostgreSQL:Host"]};Port={builder.Configuration["PostgreSQL:Port"]};Username={builder.Configuration["PostgreSQL:Username"]};Password={builder.Configuration["PostgreSQL:Password"]};Database={builder.Configuration["PostgreSQL:Database"]};");
    });
}

var app = builder.Build();

{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<LifeLinkDbContext>();
    // Call data seeding method
    DatabaseSeeder.SeedData(dbContext);    
}

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