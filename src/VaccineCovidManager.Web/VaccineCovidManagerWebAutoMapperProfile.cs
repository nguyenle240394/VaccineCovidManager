using AutoMapper;
using VaccineCovidManager.ChiTietNhaps;
using VaccineCovidManager.ChiTietXuats;
using VaccineCovidManager.DonViYTes;
using VaccineCovidManager.NoiSanXuats;
using VaccineCovidManager.VaccineCovids;

namespace VaccineCovidManager.Web;

public class VaccineCovidManagerWebAutoMapperProfile : Profile
{
    public VaccineCovidManagerWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<Pages.ChiTietNhaps.CreateModalModel.CreateChiTietNhapViewModal, CreateUpdateChiTietNhapDto>();
       
        CreateMap<Pages.VaccineCovids.CreateModalModel.CreateVaccineCovidViewModal, CreateUpdateVaccineDto>();
        CreateMap<VaccineCovidDto, Pages.VaccineCovids.EditModalModel.EditVaccineCovidViewModal>();
        CreateMap<Pages.VaccineCovids.EditModalModel.EditVaccineCovidViewModal, CreateUpdateVaccineDto>();

        CreateMap<Pages.NoiSanXuats.CreateModalModel.CreateNoiSanXuatViewModal, CreateUpdateNoiSanXuatDto>();
        CreateMap<NoiSanXuatDto, Pages.NoiSanXuats.EditModalModel.EditNoiSanXuatViewModal>();
        CreateMap<Pages.NoiSanXuats.EditModalModel.EditNoiSanXuatViewModal, CreateUpdateNoiSanXuatDto>();

        CreateMap<Pages.DonViYTes.CreateModalModel.CreateDonViYTeViewModal, CreateUpdateDonViYTeDto>();
        CreateMap<DonViYTeDto, Pages.DonViYTes.EditModalModel.EditDonViYTeViewModal>();
        CreateMap<Pages.DonViYTes.EditModalModel.EditDonViYTeViewModal, CreateUpdateDonViYTeDto>();

        CreateMap<Pages.ChiTietXuats.CreateModalModel.CreateChiTietXuatViewModal, CreateUpdateChiTietXuatDto>();
    }
}
