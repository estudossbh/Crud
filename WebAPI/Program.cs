using WebAPI.Configurations;
using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .RegisterDataBase(builder)
    .AddSwaggerGen()
    .AddCors()
    .AddControllers();

builder.Services
    .AddEndpointsApiExplorer();

builder.Services.AddScoped<TodoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyOrigin()
     .AllowAnyHeader()
     .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
