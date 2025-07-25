using GerenciadorTarefas.Application.Handler;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infrastructure;
using GerenciadorTarefas.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<CriarTarefaHandler>();
builder.Services.AddScoped<EditarTarefaHandler>();
builder.Services.AddScoped<ListarTarefaHandler>();
builder.Services.AddScoped<RemoverTarefaHandler>();
builder.Services.AddScoped<AlterarStatusTarefaHandler>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));




var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
