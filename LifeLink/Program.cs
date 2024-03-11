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
        options.UseNpgsql("Host=192.168.1.20;Database=LifeLink.db;Username=LifeLink_TestUser;Password=ghu-wvq6xcm3KCX-ued");
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