using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
    public class MongoDBNoiSanXuatRepository 
        : MongoDbRepository<VaccineCovidManagerMongoDbContext, NoiSanXuat, Guid>, INoiSanXuatRepository
    {
        public MongoDBNoiSanXuatRepository(IMongoDbContextProvider<VaccineCovidManagerMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<NoiSanXuat>> GetListAsync(
            int skipCount, 
            int maxResultCount, 
            string sorting, 
            string filter)
        {

            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<NoiSanXuat, IMongoQueryable<NoiSanXuat>>(
                    !filter.IsNullOrWhiteSpace(),
                    noiSanXuat => noiSanXuat.TenNhaSX.Contains(filter))
                .OrderByDescending(x => x.CreationTime)
                .As<IMongoQueryable<NoiSanXuat>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<NoiSanXuat> FindByNoiSanXuatWithIDAsync(Guid id)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
