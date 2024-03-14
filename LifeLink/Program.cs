using LifeLink;
using LifeLink.Persistence;
using LifeLink.Repositories.EvacPersons;
using LifeLink.Services.EvacPersons;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{    
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();

    builder.Services.AddScoped<IEvacPersonService, EvacPersonService>();

    builder.Services.AddScoped<IEvacPersonRepository, EvacPersonRepository>();

    builder.Services.AddDbContext<LifeLinkDbContext>(options => 
    {
        options.UseNpgsql(Connection.ConnectionString());
    });
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
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