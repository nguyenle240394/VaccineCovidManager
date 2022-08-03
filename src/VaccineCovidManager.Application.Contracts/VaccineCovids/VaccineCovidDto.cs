using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VaccineCovidManager.VaccineCovids
{
    public class VaccineCovidDto : AuditedEntityDto<Guid>
    {
        public string TenVaccine { get; set; }
        public int SoLuongTonKho { get; set; }
    }
}
