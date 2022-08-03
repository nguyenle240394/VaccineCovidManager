using VaccineCovidManager.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace VaccineCovidManager.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VaccineCovidManagerMongoDbModule),
    typeof(VaccineCovidManagerApplicationContractsModule)
    )]
public class VaccineCovidManagerDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
