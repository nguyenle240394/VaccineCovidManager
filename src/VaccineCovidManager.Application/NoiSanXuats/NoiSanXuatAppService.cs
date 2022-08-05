using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace VaccineCovidManager.NoiSanXuats
{
    public class NoiSanXuatAppService : ApplicationService, INoiSanXuatAppService
    {
        private readonly INoiSanXuatRepository _noiSanXuatRepository;

        public NoiSanXuatAppService(INoiSanXuatRepository noiSanXuatRepository)
        {
            _noiSanXuatRepository = noiSanXuatRepository;
        }

        public async Task<PagedResultDto<NoiSanXuatDto>> GetListAsync(GetNoiSanXuatInput input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(NoiSanXuat.CreationTime);
            }
            var noiSX = await _noiSanXuatRepository.GetListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting,
                    input.Filter
                );
            var noisanxuatDto = ObjectMapper.Map<List<NoiSanXuat>, List<NoiSanXuatDto>>(noiSX);
            var count = await _noiSanXuatRepository.GetCountAsync();
            var stt = 1;
            foreach(var item in noisanxuatDto)
            {
                item.Stt = stt;
                stt++;
            }
            return new PagedResultDto<NoiSanXuatDto>(
                    count,
                    noisanxuatDto
                );
        }

        public async Task<NoiSanXuatDto> GetNoiSanXuatAsync(Guid Id)
        {
            var noisanxuat = await _noiSanXuatRepository.FindAsync(Id);
            return ObjectMapper.Map<NoiSanXuat, NoiSanXuatDto>(noisanxuat);
        }

        public async Task<NoiSanXuatDto> CreateAsync(CreateUpdateNoiSanXuatDto input)
        {
            var noiSanXuat = ObjectMapper.Map<CreateUpdateNoiSanXuatDto, NoiSanXuat>(input);
            await _noiSanXuatRepository.InsertAsync(noiSanXuat);
            return ObjectMapper.Map<NoiSanXuat, NoiSanXuatDto>(noiSanXuat);
        }

        public async Task<NoiSanXuatDto> UpdateAsync(Guid id, CreateUpdateNoiSanXuatDto input)
        {
            var noiSX = await _noiSanXuatRepository.FindAsync(id);
            noiSX.TenNhaSX = input.TenNhaSX;
            noiSX.Diachi = input.Diachi;
            noiSX.Email = input.Email;
            noiSX.SDT = input.SDT;
            await _noiSanXuatRepository.UpdateAsync(noiSX);
            return ObjectMapper.Map<NoiSanXuat, NoiSanXuatDto>(noiSX);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var noiSX = await _noiSanXuatRepository.FindAsync(id);
            if (noiSX != null)
            {
                await _noiSanXuatRepository.DeleteAsync(noiSX);
                return true;
            }
            return false;
        }
    }
}
