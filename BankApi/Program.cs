using BankApi.Business;
using BankApi.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IBankService, BankManager>();
// Add services to the container.

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
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



using (var scope = app.Services.CreateScope())
{
    var srv = scope.ServiceProvider;
    var context = srv.GetRequiredService<MyContext>();
    context.Database.Migrate();
}

app.Run();
