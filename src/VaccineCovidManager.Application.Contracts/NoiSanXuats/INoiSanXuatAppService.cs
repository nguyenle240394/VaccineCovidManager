using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace VaccineCovidManager.NoiSanXuats
{
    public interface INoiSanXuatAppService : IApplicationService
    {
        Task<PagedResultDto<NoiSanXuatDto>> GetListAsync(GetNoiSanXuatInput input);
        Task<NoiSanXuatDto> GetNoiSanXuatAsync(Guid Id);
        Task<NoiSanXuatDto> CreateAsync(CreateUpdateNoiSanXuatDto input);
        Task<NoiSanXuatDto> UpdateAsync(Guid id, CreateUpdateNoiSanXuatDto input);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> CheckTenNoiSanXuatExist(string tenNsx);
    }
}
