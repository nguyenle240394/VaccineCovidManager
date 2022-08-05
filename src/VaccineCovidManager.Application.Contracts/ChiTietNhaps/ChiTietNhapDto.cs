using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VaccineCovidManager.ChiTietNhaps
{
    public class ChiTietNhapDto : AuditedEntityDto<Guid>
    {
        public int Stt { get; set; }
        public Guid NoiSxID { get; set; }
        public string TenNoiSX { get; set; }
        public Guid VaccineId { get; set; }
        public string TenVaccine { get; set; }
        public DateTime NgaySx { get; set; }
        public string HanSuDung { get; set; }
        public int SLNhap { get; set; }
        public string[] DanhSachVaccine  { get; set; }
    }
}
