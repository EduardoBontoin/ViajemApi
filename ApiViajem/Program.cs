using ApiViajem.Data;
using ApiViajem.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin());
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "MinhaPolitica",
//        policy =>
//        {
//            policy.WithOrigins("https://localhost.com.br:443", "http://localhost.com.br:6000").AllowAnyHeader().AllowAnyMethod();
//        }
//        );
//});

builder.Services.AddDbContext<ViagemContext>(opts =>
opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<GptService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
//app.UseCors("MinhaPolitica");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
