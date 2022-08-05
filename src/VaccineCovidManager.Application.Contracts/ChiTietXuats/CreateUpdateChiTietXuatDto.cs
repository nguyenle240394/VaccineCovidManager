using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCovidManager.ChiTietXuats
{
    public class CreateUpdateChiTietXuatDto
    {
        public Guid VaccineID { get; set; }
        public Guid DonViID { get; set; }
        public int SoLuongXuat { get; set; }
    }
}
