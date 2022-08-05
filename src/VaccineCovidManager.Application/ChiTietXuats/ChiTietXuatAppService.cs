using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCovidManager.DonViYTes;
using VaccineCovidManager.VaccineCovids;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace VaccineCovidManager.ChiTietXuats
{
    public class ChiTietXuatAppService : ApplicationService, IChiTietXuatAppService
    {
        private readonly IChiTietXuatRepository _chiTietXuatRepository;
        private readonly IDonViYTeRepository _donViYTeRepository;
        private readonly IVaccineCovidRepository _vaccineCovidRepository;

        public ChiTietXuatAppService(IChiTietXuatRepository chiTietXuatRepository,
            IDonViYTeRepository donViYTeRepository,
            IVaccineCovidRepository vaccineCovidRepository)
        {
            _chiTietXuatRepository = chiTietXuatRepository;
            _donViYTeRepository = donViYTeRepository;
            _vaccineCovidRepository = vaccineCovidRepository;
        }
        public async Task<ChiTietXuatDto> CreateAsync(CreateUpdateChiTietXuatDto input)
        {
            var chiTietXuat = ObjectMapper.Map<CreateUpdateChiTietXuatDto, ChiTietXuat>(input);
            await _chiTietXuatRepository.InsertAsync(chiTietXuat);
            return ObjectMapper.Map<ChiTietXuat, ChiTietXuatDto>(chiTietXuat);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<GetDonViYTeLookup>> GetDonViYTeLookup()
        {
            var donViYTes = await _donViYTeRepository.GetListAsync();
            var conViYTeLookups = ObjectMapper.Map<List<DonViYTe>, List<GetDonViYTeLookup>>(donViYTes);
            return new ListResultDto<GetDonViYTeLookup>(
                    conViYTeLookups
                );
        }

        public async Task<PagedResultDto<ChiTietXuatDto>> GetListAsync(GetChiTietXuatInput input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(ChiTietXuat.CreationTime);
            }
            var chiTietXuat = await _chiTietXuatRepository.GetlistAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting,
                    input.Filter
                );

            var chiTietXuatDto = ObjectMapper.Map<List<ChiTietXuat>, List<ChiTietXuatDto>>(chiTietXuat);
            foreach (var item in chiTietXuatDto)
            {
                var vacineId = await _vaccineCovidRepository.FindAsync(item.VaccineID);
                var donViYTeId = await _donViYTeRepository.FindAsync(item.DonViID);
                item.TenVaccine = vacineId.TenVaccine;
                item.DonViYTe = donViYTeId.TenDonViYTe;
            }

            var count = await _chiTietXuatRepository.GetCountAsync();
            return new PagedResultDto<ChiTietXuatDto>(
                    count, 
                    chiTietXuatDto
                );
        }

        public async Task<ListResultDto<GetVaccineLookup>> GetVaccineLookup()
        {
            var vaccines = await _vaccineCovidRepository.GetListAsync();
            var vaccineLookups = ObjectMapper.Map<List<VaccineCovid>, List<GetVaccineLookup>>(vaccines);
            return new ListResultDto<GetVaccineLookup>(vaccineLookups);
        }

        public Task<ChiTietXuatDto> UpdateAsync(Guid id, CreateUpdateChiTietXuatDto input)
        {
            throw new NotImplementedException();
        }
    }
}
