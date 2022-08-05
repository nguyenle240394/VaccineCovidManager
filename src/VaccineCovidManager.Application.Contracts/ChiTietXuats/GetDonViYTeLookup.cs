using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
namespace VaccineCovidManager.ChiTietXuats
{
    public class GetDonViYTeLookup : EntityDto<Guid>
    {
        public string TenDonViYTe { get; set; }
    }
}
