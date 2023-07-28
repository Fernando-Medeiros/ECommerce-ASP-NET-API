using Microsoft.EntityFrameworkCore;
using ECommerce_ASP_NET_API.Context;

var builder = WebApplication.CreateBuilder(args);

#region @Service
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion


#region @Database
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var host = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseMySql(
        connectionString: host,
        serverVersion: ServerVersion.AutoDetect(host));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion


#region @Injectable
#endregion


var app = builder.Build();


#region @Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
#endregion


app.Run();
