using MemosBackend;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MemosContext>(options =>
{
    options.UseSqlServer("Data Source=localhost;Initial Catalog=Memos;Integrated Security=False;User Id=sa;Password=Your_password123;MultipleActiveResultSets=True");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //using (var scope = app.Services.CreateScope())
    //{
    //    var context = scope.ServiceProvider.GetRequiredService<MemosContext>();
    //    MemosInitializer.Initialize(context);
    //}


}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
