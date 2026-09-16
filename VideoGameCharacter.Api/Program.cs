using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameCharacter.Api.Data;
using VideoGameCharacter.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//SqLite
builder.Services.AddDbContext<AppDbContext>(context =>
    context.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//Service
builder.Services.AddScoped<IPersonagemService, PersonagemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();