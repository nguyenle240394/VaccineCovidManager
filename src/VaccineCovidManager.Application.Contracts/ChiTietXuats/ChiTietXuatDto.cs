using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
namespace VaccineCovidManager.ChiTietXuats
{
    public class ChiTietXuatDto : AuditedEntityDto<Guid>
    {
        public Guid VaccineID { get; set; }
        public string TenVaccine { get; set; }
        public Guid DonViID { get; set; }
        public string DonViYTe { get; set; }
        public int SoLuongXuat { get; set; }
    }
}
