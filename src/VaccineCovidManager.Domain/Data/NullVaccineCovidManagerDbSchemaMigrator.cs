using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace VaccineCovidManager.Data;

/* This is used if database provider does't define
 * IVaccineCovidManagerDbSchemaMigrator implementation.
 */
public class NullVaccineCovidManagerDbSchemaMigrator : IVaccineCovidManagerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
