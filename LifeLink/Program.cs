using LifeLink;
using LifeLink.Persistence;
using LifeLink.Repositories.EvacPersons;
using LifeLink.Repositories.Users;
using LifeLink.Services.EvacPersons;
using LifeLink.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{    
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
    app.MapControllers();
    app.Run();
}