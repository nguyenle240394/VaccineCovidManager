using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCovidManager.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace VaccineCovidManager.NoiSanXuats
{
    public class MongoDBNoiSanXuatRepository : MongoDbRepository<VaccineCovidManagerMongoDbContext, NoiSanXuat, Guid>, INoiSanXuatRepository
    {
        public MongoDBNoiSanXuatRepository(IMongoDbContextProvider<VaccineCovidManagerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<NoiSanXuat>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter)
        {
            var queryable = await GetMongoQueryableAsync();

            return await queryable
                .ToListAsync();
        }
    }
}
