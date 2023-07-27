var builder = WebApplication.CreateBuilder(args);

#region @Service
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion


#region @Database
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
