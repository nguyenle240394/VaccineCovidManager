using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VaccineCovidManager.ChiTietNhaps
{
    public class GetVaccineCovidLookup : EntityDto<Guid>
    {
        public string TenVaccine { get; set; }
    }
}
