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

namespace VaccineCovidManager.ChiTietNhaps
{
    public class MongoDBChiTietNhapRepository : MongoDbRepository<VaccineCovidManagerMongoDbContext, ChiTietNhap, Guid>, IChiTietNhapRepository
    {
        public MongoDBChiTietNhapRepository(IMongoDbContextProvider<VaccineCovidManagerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ChiTietNhap>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter)
        {

            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<ChiTietNhap, IMongoQueryable<ChiTietNhap>>(
                    !filter.IsNullOrWhiteSpace(),
                    ChiTietNhap => ChiTietNhap.HanSuDung.Contains(filter))
                .OrderByDescending(x => x.CreationTime)
                .As<IMongoQueryable<ChiTietNhap>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
