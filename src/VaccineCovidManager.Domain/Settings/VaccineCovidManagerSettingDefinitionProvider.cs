using Volo.Abp.Settings;

namespace VaccineCovidManager.Settings;

public class VaccineCovidManagerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(VaccineCovidManagerSettings.MySetting1));
    }
}
