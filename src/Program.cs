using ECommerce.Setup;

#region builder application

var builder = WebApplication.CreateBuilder(args);

Setup.Environment(builder);

Setup.SmtpClient(builder);

Setup.AuthenticationMiddleware(builder);

Setup.AuthorizationMiddleware(builder);

Setup.Controller(builder);

Setup.Swagger(builder);

Setup.Database(builder);

Setup.Injectable(builder);

#endregion

#region  web application

var app = builder.Build();

Setup.Development(app);

Setup.Pipeline(app);

app.Run();

#endregion