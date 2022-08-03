using VaccineCovidManager.MongoDB;
using Volo.Abp.Modularity;

namespace VaccineCovidManager;

[DependsOn(
    typeof(VaccineCovidManagerMongoDbTestModule)
    )]
public class VaccineCovidManagerDomainTestModule : AbpModule
{

}
