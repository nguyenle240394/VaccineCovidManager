using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
namespace VaccineCovidManager.DonViYTes
{
    public class DonViYTeDto : AuditedEntityDto<Guid>
    {
        public string TenDonViYTe { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
    }
}
