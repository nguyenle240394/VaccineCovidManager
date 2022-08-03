using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VaccineCovidManager.ChiTietXuats
{
    public class ChiTietXuat : AuditedAggregateRoot<Guid>
    {
        public Guid VaccineID { get; set; }
        public Guid DonViID { get; set; }
        public int SoLuongXuat { get; set; }
    }
}
