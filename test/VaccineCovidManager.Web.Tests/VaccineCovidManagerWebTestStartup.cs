using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace VaccineCovidManager;

public class VaccineCovidManagerWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<VaccineCovidManagerWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
