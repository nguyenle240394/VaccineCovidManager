using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VaccineCovidManager.ChiTietNhaps
{
    public class ChiTietNhap : AuditedAggregateRoot<Guid>
    {
        public Guid NoiSxID { get; set; }
        public Guid VaccineId { get; set; }
        public DateTime NgaySx { get; set; }
        public string HanSuDung { get; set; }
        public int SLNhap { get; set; }

    }
}
