using ECommerceInfrastructure.Configuration.Setup;

var builder = WebApplication.CreateBuilder(args)
    .Environment()
    .SmtpClient()
    .AuthenticationMiddleware()
    .AuthorizationMiddleware()
    .Controller()
    .Swagger()
    .Database()
    .Injectable();

var app = builder.Build()
    .Development()
    .Pipeline();

app.Run();