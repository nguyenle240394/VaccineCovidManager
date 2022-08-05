namespace VaccineCovidManager.Permissions;

public static class VaccineCovidManagerPermissions
{
    public const string GroupName = "VaccineCovidManager";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    
    public static class VaccineCovids
    {
        public const string Default = GroupName + ".VaccineCovids";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class NoiSanXuats
    {
        public const string Default = GroupName + ".NoiSanXuats";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class DonViYTes
    {
        public const string Default = GroupName + ".DonViYTes";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class ChiTietNhaps
    {
        public const string Default = GroupName + ".ChiTietNhaps";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class ChiTietXuats
    {
        public const string Default = GroupName + ".ChiTietXuats";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
