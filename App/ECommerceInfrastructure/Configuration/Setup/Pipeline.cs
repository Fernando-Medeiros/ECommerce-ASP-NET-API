namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Pipeline(WebApplication app)
    {
        app.UseAuthentication();

        app.UseAuthorization();

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.MapControllers();
    }
}
