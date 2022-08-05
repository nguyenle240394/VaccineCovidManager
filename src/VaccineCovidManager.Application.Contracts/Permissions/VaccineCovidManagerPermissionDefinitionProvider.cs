using VaccineCovidManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace VaccineCovidManager.Permissions;

public class VaccineCovidManagerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //Define your own permissions here. Example:
        //myGroup.AddPermission(VaccineCovidManagerPermissions.MyPermission1, L("Permission:MyPermission1"));
        var vaccineCovidGroup = context.AddGroup(VaccineCovidManagerPermissions.GroupName, L("Permission:VaccineCovidManager"));

        var vaccineCovidPermission = vaccineCovidGroup.AddPermission(VaccineCovidManagerPermissions.VaccineCovids.Default, L("Permission:VaccineCovids"));
        vaccineCovidPermission.AddChild(VaccineCovidManagerPermissions.VaccineCovids.Create, L("Permission:VaccineCovids.Create"));
        vaccineCovidPermission.AddChild(VaccineCovidManagerPermissions.VaccineCovids.Edit, L("Permission:VaccineCovids.Edit"));
        vaccineCovidPermission.AddChild(VaccineCovidManagerPermissions.VaccineCovids.Delete, L("Permission:VaccineCovids.Delete"));

        var noiSanXuatPermission = vaccineCovidGroup.AddPermission(VaccineCovidManagerPermissions.NoiSanXuats.Default, L("Permission:NoiSanXuats"));
        noiSanXuatPermission.AddChild(VaccineCovidManagerPermissions.NoiSanXuats.Create, L("Permission:NoiSanXuats.Create"));
        noiSanXuatPermission.AddChild(VaccineCovidManagerPermissions.NoiSanXuats.Edit, L("Permission:NoiSanXuats.Edit"));
        noiSanXuatPermission.AddChild(VaccineCovidManagerPermissions.NoiSanXuats.Delete, L("Permission:NoiSanXuats.Delete"));

        var donViYTePermission = vaccineCovidGroup.AddPermission(VaccineCovidManagerPermissions.DonViYTes.Default, L("Permission:DonViYTes"));
        donViYTePermission.AddChild(VaccineCovidManagerPermissions.DonViYTes.Create, L("Permission:DonViYTes.Create"));
        donViYTePermission.AddChild(VaccineCovidManagerPermissions.DonViYTes.Edit, L("Permission:DonViYTes.Edit"));
        donViYTePermission.AddChild(VaccineCovidManagerPermissions.DonViYTes.Delete, L("Permission:DonViYTes.Delete"));

        var chiTietNhapPermission = vaccineCovidGroup.AddPermission(VaccineCovidManagerPermissions.ChiTietNhaps.Default, L("Permission:ChiTietNhaps"));
        chiTietNhapPermission.AddChild(VaccineCovidManagerPermissions.ChiTietNhaps.Create, L("Permission:ChiTietNhaps.Create"));
        chiTietNhapPermission.AddChild(VaccineCovidManagerPermissions.ChiTietNhaps.Edit, L("Permission:ChiTietNhaps.Edit"));
        chiTietNhapPermission.AddChild(VaccineCovidManagerPermissions.ChiTietNhaps.Delete, L("Permission:ChiTietNhaps.Delete"));

        var chiTietXuatPermission = vaccineCovidGroup.AddPermission(VaccineCovidManagerPermissions.ChiTietXuats.Default, L("Permission:ChiTietXuats"));
        chiTietXuatPermission.AddChild(VaccineCovidManagerPermissions.ChiTietXuats.Create, L("Permission:ChiTietXuats.Create"));
        chiTietXuatPermission.AddChild(VaccineCovidManagerPermissions.ChiTietXuats.Edit, L("Permission:ChiTietXuats.Edit"));
        chiTietXuatPermission.AddChild(VaccineCovidManagerPermissions.ChiTietXuats.Delete, L("Permission:ChiTietXuats.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VaccineCovidManagerResource>(name);
    }
}
