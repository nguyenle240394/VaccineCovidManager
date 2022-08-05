using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace VaccineCovidManager.ChiTietXuats
{
    public interface IChiTietXuatRepository : IRepository<ChiTietXuat, Guid>
    {
        Task<List<ChiTietXuat>> GetlistAsync(
                int skipCount,
                int maxResultCount,
                string sorting,
                string filter
            );   
    }
}
