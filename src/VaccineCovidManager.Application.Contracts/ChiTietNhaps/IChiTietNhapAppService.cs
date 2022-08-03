using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace VaccineCovidManager.ChiTietNhaps
{
    public interface IChiTietNhapAppService : IApplicationService
    {
        Task<ChiTietNhapDto> CreateAsync(CreateUpdateChiTietNhapDto input);
        Task<ChiTietNhapDto> UpdateAsync(Guid id, CreateUpdateChiTietNhapDto input);
        Task<bool> DeleteAsync(Guid id);
    }
}
