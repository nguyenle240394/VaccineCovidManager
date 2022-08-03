using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VaccineCovidManager.VaccineCovids
{
    public class VaccineAppService : ApplicationService, IVaccineAppService
    {
        private readonly IVaccineCovidRepository _vaccineRepository;

        public VaccineAppService(IVaccineCovidRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }
        public async Task<VaccineCovidDto> CreateAsync(CreateUpdateVaccineDto input)
        {
            var vaccine = ObjectMapper.Map<CreateUpdateVaccineDto, VaccineCovid>(input);
            await _vaccineRepository.InsertAsync(vaccine);
            return ObjectMapper.Map<VaccineCovid, VaccineCovidDto>(vaccine);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<VaccineCovidDto>> GetListAsync(GetVaccineInput input)
        {
            throw new NotImplementedException();
        }

        public Task<VaccineCovidDto> UpdateAsync(Guid id, CreateUpdateVaccineDto input)
        {
            throw new NotImplementedException();
        }
    }
}
