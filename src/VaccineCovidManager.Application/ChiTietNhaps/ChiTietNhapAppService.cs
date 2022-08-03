using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace VaccineCovidManager.ChiTietNhaps
{
    public class ChiTietNhapAppService : ApplicationService, IChiTietNhapAppService
    {
        private readonly IChiTietNhapRepository _chiTietNhapRepository;

        public ChiTietNhapAppService(IChiTietNhapRepository chiTietNhapRepository)
        {
            _chiTietNhapRepository = chiTietNhapRepository;
        }
        public async Task<ChiTietNhapDto> CreateAsync(CreateUpdateChiTietNhapDto input)
        {
            var chiTietNhap = ObjectMapper.Map<CreateUpdateChiTietNhapDto, ChiTietNhap>(input);
            await _chiTietNhapRepository.InsertAsync(chiTietNhap);
            return ObjectMapper.Map<ChiTietNhap, ChiTietNhapDto>(chiTietNhap);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ChiTietNhapDto> UpdateAsync(Guid id, CreateUpdateChiTietNhapDto input)
        {
            throw new NotImplementedException();
        }
    }
}
