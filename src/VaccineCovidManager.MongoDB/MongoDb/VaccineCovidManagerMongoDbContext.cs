using MongoDB.Driver;
using VaccineCovidManager.ChiTietNhaps;
using VaccineCovidManager.ChiTietXuats;
using VaccineCovidManager.DonViYTes;
using VaccineCovidManager.NoiSanXuats;
using VaccineCovidManager.VaccineCovids;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace VaccineCovidManager.MongoDB;

[ConnectionStringName("Default")]
public class VaccineCovidManagerMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    public IMongoCollection<VaccineCovid> VaccineCovids => Collection<VaccineCovid>();
    public IMongoCollection<NoiSanXuat> NoiSanXuats => Collection<NoiSanXuat>();
    public IMongoCollection<DonViYTe> DonViYTes => Collection<DonViYTe>();
    public IMongoCollection<ChiTietNhap> ChiTietNhaps => Collection<ChiTietNhap>();
    public IMongoCollection<ChiTietXuat> ChiTietXuats => Collection<ChiTietXuat>();



    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
