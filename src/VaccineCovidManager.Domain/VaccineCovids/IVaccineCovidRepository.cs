using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace VaccineCovidManager.VaccineCovids
{
    public interface IVaccineCovidRepository : IRepository<VaccineCovid, Guid>
    {
        Task<List<VaccineCovid>> GetListAsync(
                int skipCount,
                int maxResultCount,
                string sorting,
                string filter
            );
    }
}
