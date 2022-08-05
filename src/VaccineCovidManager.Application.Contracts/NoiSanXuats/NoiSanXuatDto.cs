using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VaccineCovidManager.NoiSanXuats
{
    public class NoiSanXuatDto : AuditedEntityDto<Guid>
    {
        public int Stt { get; set; }
        public string TenNhaSX { get; set; }
        public string Diachi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
    }
}
