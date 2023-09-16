namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Development(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
    }
}