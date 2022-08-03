using AutoMapper;
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
    }
}
