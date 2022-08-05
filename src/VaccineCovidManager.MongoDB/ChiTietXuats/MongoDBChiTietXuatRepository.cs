using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCovidManager.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace VaccineCovidManager.ChiTietXuats
{
    public class MongoDBChiTietXuatRepository : MongoDbRepository<VaccineCovidManagerMongoDbContext, ChiTietXuat, Guid>, IChiTietXuatRepository
    {
        public MongoDBChiTietXuatRepository(IMongoDbContextProvider<VaccineCovidManagerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ChiTietXuat>> GetlistAsync(int skipCount, int maxResultCount, string sorting, string filter)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                        .ToListAsync();
        }
    }
}
