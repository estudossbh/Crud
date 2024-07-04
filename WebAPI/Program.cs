using WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .RegisterDataBase(builder)
    .AddSwaggerGen()
    .AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c =>
{
    c.AllowAnyOrigin()
     .AllowAnyHeader()
     .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
