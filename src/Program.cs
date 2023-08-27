using ECommerce.Startup;

var builder = WebApplication.CreateBuilder(args);

ServiceProviders.Environment(builder);

ServiceProviders.SmtpClient(builder);

ServiceProviders.AddAuthenticationMiddleware(builder);

ServiceProviders.AddAuthorizationMiddleware(builder);

ServiceProviders.Controller(builder);

ServiceProviders.Swagger(builder);

ServiceProviders.Database(builder);

ServiceProviders.Injectable(builder);

var app = builder.Build();

ServiceProviders.UseAuthenticationMiddleware(app);

ServiceProviders.UseAuthorizationMiddleware(app);

ServiceProviders.Development(app);

ServiceProviders.Pipeline(app);

app.Run();
