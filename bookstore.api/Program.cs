using bookstore.Domain.Settings;
using bookstore.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


#region AppSettings

var appSetting = builder.Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();
builder.Services.AddSingleton(appSetting);

#endregion


#region DbContext

builder.Services.AddDbContext<BookStoreContext>(options =>
{
    options.UseSqlServer(appSetting.SqlServerConnection);
});

#endregion

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
