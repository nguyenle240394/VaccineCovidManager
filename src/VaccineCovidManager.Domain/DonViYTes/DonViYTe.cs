using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
namespace VaccineCovidManager.DonViYTes
{
    public class DonViYTe : AuditedAggregateRoot<Guid>
    {
        public string TenDonViYTe { get; set; }
    }
}
