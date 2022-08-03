using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace VaccineCovidManager.NoiSanXuats
{
    public interface INoiSanXuatRepository : IRepository<NoiSanXuat, Guid>
    {
        Task<List<NoiSanXuat>> GetListAsync(
                int skipCount,
                int maxResultCount,
                string sorting,
                string filter
            );
    }
}
