using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VaccineCovidManager.VaccineCovids
{
    public interface IVaccineAppService : IApplicationService
    {
        Task<PagedResultDto<VaccineCovidDto>> GetListAsync(GetVaccineInput input);
        Task<VaccineCovidDto> CreateAsync(CreateUpdateVaccineDto input);
        Task<bool> DeleteAsync(Guid id);
        Task<VaccineCovidDto> UpdateAsync(Guid id, CreateUpdateVaccineDto input);
        Task<VaccineCovidDto> FindVaccineById(Guid id);
    }
}
