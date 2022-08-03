using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace VaccineCovidManager.Web;

[Dependency(ReplaceServices = true)]
public class VaccineCovidManagerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "VaccineCovidManager";
}
