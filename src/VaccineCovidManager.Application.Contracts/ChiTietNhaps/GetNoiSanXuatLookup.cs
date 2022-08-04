using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VaccineCovidManager.ChiTietNhaps
{
    public class GetNoiSanXuatLookup : EntityDto<Guid>
    {
        public string DiaChi { get; set; }
    }
}
