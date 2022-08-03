using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
namespace VaccineCovidManager.NoiSanXuats
{
    public class NoiSanXuat : AuditedAggregateRoot<Guid>
    {
        public string NoiSX { get; set; }
    }
}
