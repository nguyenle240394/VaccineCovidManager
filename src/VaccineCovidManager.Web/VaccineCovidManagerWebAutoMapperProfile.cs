using AutoMapper;
using VaccineCovidManager.ChiTietNhaps;

namespace VaccineCovidManager.Web;

public class VaccineCovidManagerWebAutoMapperProfile : Profile
{
    public VaccineCovidManagerWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<Pages.ChiTietNhaps.CreateModalModel.CreateChiTietNhapViewModal, CreateUpdateChiTietNhapDto>();
    }
}
