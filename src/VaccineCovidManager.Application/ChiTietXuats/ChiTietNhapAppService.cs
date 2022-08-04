using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace VaccineCovidManager.ChiTietXuats
{
    public class ChiTietNhapAppService : ApplicationService, IChiTietXuatAppService
    {
        private readonly IChiTietXuatRepository _chiTietXuatRepository;

        public ChiTietNhapAppService(IChiTietXuatRepository chiTietXuatRepository)
        {
            _chiTietXuatRepository = chiTietXuatRepository;
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
            var count = await _chiTietXuatRepository.GetCountAsync();
            return new PagedResultDto<ChiTietXuatDto>(
                    count, 
                    chiTietXuatDto
                );
        }

        public Task<ChiTietXuatDto> UpdateAsync(Guid id, CreateUpdateChiTietXuatDto input)
        {
            throw new NotImplementedException();
        }
    }
}
