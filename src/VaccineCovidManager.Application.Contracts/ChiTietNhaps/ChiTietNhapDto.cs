﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VaccineCovidManager.ChiTietNhaps
{
    public class ChiTietNhapDto : AuditedEntityDto<Guid>
    {
        public Guid NoiSxID { get; set; }
        public Guid VaccineId { get; set; }
        public DateTime NgaySx { get; set; }
        public string HanSuDung { get; set; }
        public int SLNhap { get; set; }
    }
}