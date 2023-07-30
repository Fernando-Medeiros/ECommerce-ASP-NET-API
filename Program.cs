using ECommerce_ASP_NET_API.Startup;

var builder = WebApplication.CreateBuilder(args);

ServiceProviders.Controller(builder);

ServiceProviders.Swagger(builder);

ServiceProviders.Database(builder);

ServiceProviders.Injectable(builder);

var app = builder.Build();

ServiceProviders.Development(app);

ServiceProviders.Middleware(app);

app.Run();
