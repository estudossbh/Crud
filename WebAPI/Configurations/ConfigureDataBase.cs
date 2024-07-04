namespace WebAPI.Configurations
{
    public static class ConfigureDataBase
    {
        public static IServiceCollection RegisterDataBase(this IServiceCollection services, WebApplicationBuilder builder)
        {
            return services.Configure<DbSettings>(builder.Configuration.GetSection("DataBase"));
        }
    }
}
