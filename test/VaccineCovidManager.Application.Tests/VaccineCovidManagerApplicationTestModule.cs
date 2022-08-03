using Volo.Abp.Modularity;

namespace VaccineCovidManager;

[DependsOn(
    typeof(VaccineCovidManagerApplicationModule),
    typeof(VaccineCovidManagerDomainTestModule)
    )]
public class VaccineCovidManagerApplicationTestModule : AbpModule
{

}
