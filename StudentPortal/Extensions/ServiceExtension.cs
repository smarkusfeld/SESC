namespace StudentPortal.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDISessionServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSession();
            services.AddMvc();
            //set up in memory session provider
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".StudentPortal.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                //use cookies to store session data 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            return services;
        }
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            


            return services;
        }
    }
}
