using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.Extensions.Logging;

namespace DevIO.Api.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLogginConfiguration(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "322218a1e83243e9b42f98b871727e8e";
                o.LogId = new Guid("a186f372-d655-4ca1-87b9-1e821d1523d0");
            });

            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "322218a1e83243e9b42f98b871727e8e";
                    o.LogId = new Guid("a186f372-d655-4ca1-87b9-1e821d1523d0");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });

            return services;
        }

        public static IApplicationBuilder UseLogginConfiguuration(this IApplicationBuilder app)
        {

            app.UseElmahIo();

            return app;
        }
    }
}
