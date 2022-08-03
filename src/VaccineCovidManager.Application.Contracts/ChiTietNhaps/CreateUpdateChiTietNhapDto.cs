using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCovidManager.ChiTietNhaps
{
    public class CreateUpdateChiTietNhapDto
    {
        public Guid NoiSxID { get; set; }
        public Guid VaccineId { get; set; }
        public DateTime NgaySx { get; set; }
        public string HanSuDung { get; set; }
        public int SLNhap { get; set; }
    }
}
