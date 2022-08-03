using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
namespace VaccineCovidManager.NoiSanXuats
{
    public class GetNoiSanXuatInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
