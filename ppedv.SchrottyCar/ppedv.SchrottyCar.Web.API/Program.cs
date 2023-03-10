using ppedv.SchrottyCar.Data.EfCore;
using ppedv.SchrottyCar.Model.Contracts;

var builder = WebApplication.CreateBuilder(args);

var conString = "Server=(localdb)\\mssqllocaldb;Database=SchrottyDb_Tests;Trusted_Connection=true;";
// Add services to the container.
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>(x => new EfUnitOfWork(conString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
