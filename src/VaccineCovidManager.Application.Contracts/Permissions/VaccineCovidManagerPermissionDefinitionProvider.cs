using VaccineCovidManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace VaccineCovidManager.Permissions;

public class VaccineCovidManagerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VaccineCovidManagerPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(VaccineCovidManagerPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VaccineCovidManagerResource>(name);
    }
}
