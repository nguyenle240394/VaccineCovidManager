using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VaccineCovidManager.ChiTietXuats
{
    public class GetVaccineLookup : EntityDto<Guid>
    {
        public string TenVaccine { get; set; }
    }
}
