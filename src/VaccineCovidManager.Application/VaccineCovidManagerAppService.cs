using System;
using System.Collections.Generic;
using System.Text;
using VaccineCovidManager.Localization;
using Volo.Abp.Application.Services;

namespace VaccineCovidManager;

/* Inherit your application services from this class.
 */
public abstract class VaccineCovidManagerAppService : ApplicationService
{
    protected VaccineCovidManagerAppService()
    {
        LocalizationResource = typeof(VaccineCovidManagerResource);
    }
}
