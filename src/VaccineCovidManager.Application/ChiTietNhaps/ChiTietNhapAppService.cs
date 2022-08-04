using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCovidManager.NoiSanXuats;
using VaccineCovidManager.VaccineCovids;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VaccineCovidManager.ChiTietNhaps
{
    public class ChiTietNhapAppService : ApplicationService, IChiTietNhapAppService
    {
        private readonly IChiTietNhapRepository _chiTietNhapRepository;
        private readonly INoiSanXuatRepository _noiSanXuatRepository;
        private readonly IVaccineCovidRepository _vaccineCovidRepository;

        public ChiTietNhapAppService(IChiTietNhapRepository chiTietNhapRepository,
            INoiSanXuatRepository noiSanXuatRepository,
            IVaccineCovidRepository vaccineCovidRepository)
        {
            _chiTietNhapRepository = chiTietNhapRepository;
            _noiSanXuatRepository = noiSanXuatRepository;
            _vaccineCovidRepository = vaccineCovidRepository;
        }

        public async Task<PagedResultDto<ChiTietNhapDto>> GetListAsync(GetChiTietNhapInput input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(ChiTietNhap.CreatorId);
            }
            var chiTietNhap = await _chiTietNhapRepository.GetListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting,
                    input.Filter
                );
            var chiTietNhapDto = ObjectMapper.Map<List<ChiTietNhap>, List<ChiTietNhapDto>>(chiTietNhap);
            var stt = 1;
            foreach (var item in chiTietNhapDto)
            {
                item.Stt = stt++;
                var namevaccine = await _vaccineCovidRepository.FindAsync(item.VaccineId);
                var noiSX = await _noiSanXuatRepository.FindAsync(item.NoiSxID);
                item.TenVaccine = namevaccine.TenVaccine;
                item.TenNoiSX = noiSX.TenNhaSX;
            }
            var count = await _chiTietNhapRepository.GetCountAsync();
            return new PagedResultDto<ChiTietNhapDto>(
                    count,
                    chiTietNhapDto
                );
        }

        public async Task<ListResultDto<GetNoiSanXuatLookup>> GetNoiSanXuatLookupAsync()
        {
            var noiSX = await _noiSanXuatRepository.GetListAsync();
            var noiSanXuatDtos = ObjectMapper.Map<List<NoiSanXuat>, List<GetNoiSanXuatLookup>>(noiSX);
            return new ListResultDto<GetNoiSanXuatLookup>(
                    noiSanXuatDtos
                );
        }

        public async Task<ListResultDto<GetVaccineCovidLookup>> GetVaccineCovidLookupAsync()
        {
            var vaccnine = await _vaccineCovidRepository.GetListAsync();
            var vaccineDtos = ObjectMapper.Map<List<VaccineCovid>, List<GetVaccineCovidLookup>>(vaccnine);
            return new ListResultDto<GetVaccineCovidLookup>(
                    vaccineDtos
                );
        }

        public async Task<ChiTietNhapDto> CreateAsync(CreateUpdateChiTietNhapDto input)
        {
            var chiTietNhap = ObjectMapper.Map<CreateUpdateChiTietNhapDto, ChiTietNhap>(input);
            await _chiTietNhapRepository.InsertAsync(chiTietNhap);
            return ObjectMapper.Map<ChiTietNhap, ChiTietNhapDto>(chiTietNhap);
        }

        public Task<ChiTietNhapDto> UpdateAsync(Guid id, CreateUpdateChiTietNhapDto input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
