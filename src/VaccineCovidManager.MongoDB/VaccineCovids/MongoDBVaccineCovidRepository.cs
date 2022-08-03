using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCovidManager.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace VaccineCovidManager.VaccineCovids
{
    public class MongoDBVaccineCovidRepository : MongoDbRepository<VaccineCovidManagerMongoDbContext, VaccineCovid, Guid>, IVaccineCovidRepository
    {
        public MongoDBVaccineCovidRepository(IMongoDbContextProvider<VaccineCovidManagerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<VaccineCovid>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .ToListAsync();
        }
    }
}
