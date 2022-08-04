using AutoMapper;
using VaccineCovidManager.ChiTietNhaps;
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
    }
}
