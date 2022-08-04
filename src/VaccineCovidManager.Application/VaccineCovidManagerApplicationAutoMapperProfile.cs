using AutoMapper;
using VaccineCovidManager.ChiTietNhaps;
using VaccineCovidManager.ChiTietXuats;
using VaccineCovidManager.DonViYTes;
using VaccineCovidManager.NoiSanXuats;
using VaccineCovidManager.VaccineCovids;

namespace VaccineCovidManager;

public class VaccineCovidManagerApplicationAutoMapperProfile : Profile
{
    public VaccineCovidManagerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<CreateUpdateVaccineDto, VaccineCovid>();
        CreateMap<VaccineCovid, VaccineCovidDto>();
        CreateMap<CreateUpdateNoiSanXuatDto, NoiSanXuat>();
        CreateMap<NoiSanXuat, NoiSanXuatDto>();
        CreateMap<CreateUpdateDonViYTeDto, DonViYTe>();
        CreateMap<DonViYTe, DonViYTeDto>();
        CreateMap<CreateUpdateChiTietNhapDto, ChiTietNhap>();
        CreateMap<ChiTietNhap, ChiTietNhapDto>();
        CreateMap<NoiSanXuat, GetNoiSanXuatLookup>();
        CreateMap<VaccineCovid, GetVaccineCovidLookup>();
        CreateMap<CreateUpdateChiTietXuatDto, ChiTietXuat>();
        CreateMap<ChiTietXuat, ChiTietXuatDto>();
    }
}
