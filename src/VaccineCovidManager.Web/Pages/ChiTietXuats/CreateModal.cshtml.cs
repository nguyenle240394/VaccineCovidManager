﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using VaccineCovidManager.ChiTietXuats;
using VaccineCovidManager.VaccineCovids;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VaccineCovidManager.Web.Pages.ChiTietXuats
{
    public class CreateModalModel : PageModel
    {
        private readonly ChiTietXuatAppService _chiTietXuatAppService;
        private readonly VaccineAppService _vaccineAppService;

        public CreateModalModel(ChiTietXuatAppService chiTietXuatAppService,
           VaccineAppService vaccineAppService )
        {
            _chiTietXuatAppService = chiTietXuatAppService;
            _vaccineAppService = vaccineAppService;
        }
        [BindProperty]
        public CreateChiTietXuatViewModal ChiTietXuat { get; set; }
        [BindProperty]
        public List<SelectListItem> Vaccines { get; set; }
        [BindProperty]
        public List<SelectListItem> DonViYTes { get; set; }
        public async void OnGet()
        {
            ChiTietXuat = new CreateChiTietXuatViewModal();
            var donViYTeLookup = await _chiTietXuatAppService.GetDonViYTeLookup();
            DonViYTes = donViYTeLookup.Items
                .Select(d => new SelectListItem(d.TenDonViYTe, d.Id.ToString()))
                .ToList();

            var vaccineLookup = await _chiTietXuatAppService.GetVaccineLookup();
            Vaccines = vaccineLookup.Items
                .Select(v => new SelectListItem(v.TenVaccine,v.Id.ToString()))
                .ToList();
        }

        public class CreateChiTietXuatViewModal
        {
            [SelectItems(nameof(Vaccines))]
            [DisplayName("Vaccine")]
            public Guid VaccineID { get; set; }
            [SelectItems(nameof(DonViYTes))]
            [DisplayName("Đơn vị y tế")]
            public Guid DonViID { get; set; }
            public int SoLuongXuat { get; set; }
        }
    }
}
