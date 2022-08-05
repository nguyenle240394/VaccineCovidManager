using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using VaccineCovidManager.ChiTietXuats;
using VaccineCovidManager.VaccineCovids;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VaccineCovidManager.Web.Pages.ChiTietXuats
{
    public class CreateModalModel : VaccineCovidManagerPageModel
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

        public async Task<IActionResult> OnPostAsync()
        {
            if(ChiTietXuat.SoLuongXuat > 0)
            {
                var vaccineDto = await _vaccineAppService.FindVaccineById(ChiTietXuat.VaccineID);
                var createVaccineDto = new CreateUpdateVaccineDto();
                var mess = "Số vaccine " + '"' + vaccineDto.TenVaccine + '"' + " trong kho còn " + vaccineDto.SoLuongTonKho + " (liều) không đủ để xuất";
                if (vaccineDto.SoLuongTonKho < ChiTietXuat.SoLuongXuat)
                {
                    throw new UserFriendlyException(L[mess]);
                }
                createVaccineDto.TenVaccine = vaccineDto.TenVaccine;
                createVaccineDto.SoLuongTonKho = vaccineDto.SoLuongTonKho - ChiTietXuat.SoLuongXuat;
                await _vaccineAppService.UpdateAsync(vaccineDto.Id, createVaccineDto);
                var upDateChiTiet = ObjectMapper.Map<CreateChiTietXuatViewModal, CreateUpdateChiTietXuatDto>(ChiTietXuat);
                await _chiTietXuatAppService.CreateAsync(upDateChiTiet);
            }
            else
            {
                throw new UserFriendlyException(L["Số lượng Vaccine xuất phải lớn hơn 0"]);
            }
            return NoContent();
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
