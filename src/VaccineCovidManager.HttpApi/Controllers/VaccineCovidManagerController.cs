using VaccineCovidManager.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VaccineCovidManager.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class VaccineCovidManagerController : AbpControllerBase
{
    protected VaccineCovidManagerController()
    {
        LocalizationResource = typeof(VaccineCovidManagerResource);
    }
}
