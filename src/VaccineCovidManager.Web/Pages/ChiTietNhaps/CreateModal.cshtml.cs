using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VaccineCovidManager.ChiTietNhaps;
using VaccineCovidManager.VaccineCovids;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VaccineCovidManager.Web.Pages.ChiTietNhaps
{
    public class CreateModalModel : VaccineCovidManagerPageModel
    {
        private readonly ChiTietNhapAppService _chiTietNhapAppService;
        private readonly VaccineAppService _vaccineAppService;

        public CreateModalModel(ChiTietNhapAppService chiTietNhapAppService, VaccineAppService vaccineAppService)
        {
            _chiTietNhapAppService = chiTietNhapAppService;
            _vaccineAppService = vaccineAppService;
        }
        [BindProperty]
        public CreateChiTietNhapViewModal NhapVaccine { get; set; }
        [BindProperty]
        public List<SelectListItem> NoiSanXuats { get; set; }
        [BindProperty]
        public List<SelectListItem> VaccineCovids { get; set; }
        public async void OnGet()
        {
            NhapVaccine = new CreateChiTietNhapViewModal();
            var noiSanXuatLookup = await _chiTietNhapAppService.GetNoiSanXuatLookupAsync();
            NoiSanXuats = noiSanXuatLookup.Items
                .Select(n=> new SelectListItem(n.DiaChi, n.Id.ToString()))
                .ToList();

            var vaccineLookup = await _chiTietNhapAppService.GetVaccineCovidLookupAsync();
            VaccineCovids = vaccineLookup.Items
                .Select(v => new SelectListItem(v.TenVaccine, v.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(NhapVaccine.SLNhap > 0)
            {
                NhapVaccine.HanSuDung += " Tháng";

                var createUpdasteVaccine = new CreateUpdateVaccineDto();
                var vaccineDto = await _vaccineAppService.FindVaccineById(NhapVaccine.VaccineId);
                createUpdasteVaccine.TenVaccine = vaccineDto.TenVaccine;
                createUpdasteVaccine.SoLuongTonKho = vaccineDto.SoLuongTonKho + NhapVaccine.SLNhap;
                await _vaccineAppService.UpdateAsync(NhapVaccine.VaccineId, createUpdasteVaccine);

                var chitietNhapVaccineDto = ObjectMapper.Map<CreateChiTietNhapViewModal, CreateUpdateChiTietNhapDto>(NhapVaccine);
                await _chiTietNhapAppService.CreateAsync(chitietNhapVaccineDto);
            }
            else
            {
                throw new UserFriendlyException(L["Số lượng Vaccine nhập phải lớn hơn 0"]);
            }
            return NoContent();
        }

        public class CreateChiTietNhapViewModal
        {
            [Required]
            [SelectItems(nameof(NoiSanXuats))]
            [DisplayName("Sản xuất")]
            public Guid NoiSxID { get; set; }
            [Required]
            [SelectItems(nameof(VaccineCovids))]
            [DisplayName("Vaccine")]
            public Guid VaccineId { get; set; }
            [Required]
            [DisplayName("Ngày sản xuất")]
            public DateTime NgaySx { get; set; } = DateTime.Now;
            [Required]
            [DisplayName("Hạn sử dụng")]
            public string HanSuDung { get; set; }
            [Required]
            [DisplayName("Số Lượng Nhập")]
            public int SLNhap { get; set; }
        }
    }
}
