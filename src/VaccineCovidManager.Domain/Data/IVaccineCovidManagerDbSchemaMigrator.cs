using System.Threading.Tasks;

namespace VaccineCovidManager.Data;

public interface IVaccineCovidManagerDbSchemaMigrator
{
    Task MigrateAsync();
}
