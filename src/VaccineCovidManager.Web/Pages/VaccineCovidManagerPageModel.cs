using VaccineCovidManager.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace VaccineCovidManager.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class VaccineCovidManagerPageModel : AbpPageModel
{
    protected VaccineCovidManagerPageModel()
    {
        LocalizationResourceType = typeof(VaccineCovidManagerResource);
    }
}
