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
    }
}
