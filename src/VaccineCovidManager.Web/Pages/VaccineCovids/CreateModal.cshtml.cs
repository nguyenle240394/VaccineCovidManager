using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VaccineCovidManager.VaccineCovids;
using Volo.Abp;

namespace VaccineCovidManager.Web.Pages.VaccineCovids
{
    public class CreateModalModel : VaccineCovidManagerPageModel
    {
        private readonly IVaccineAppService _vaccineAppService;

        public CreateModalModel(IVaccineAppService vaccineAppService)
        {
            _vaccineAppService = vaccineAppService;
        }

        [BindProperty]
        public CreateVaccineCovidViewModal VaccineCovids { get; set; }
        public void OnGet()
        {
            VaccineCovids = new CreateVaccineCovidViewModal();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(VaccineCovids.SoLuongTonKho >= 0)
            {
                await _vaccineAppService.CreateAsync(
                    ObjectMapper.Map<CreateVaccineCovidViewModal, CreateUpdateVaccineDto>(VaccineCovids));
            }
            else
            {
                throw new UserFriendlyException(L["Số lượng tồn kho nhỏ hơn 0"]);
            }
            return NoContent();
        }

        public class CreateVaccineCovidViewModal
        {
            [Required]
            [DisplayName("Tên Vaccine")]
            public string TenVaccine { get; set; }
            [Required]
            [DisplayName("Số lượng tồn kho")]
            public int SoLuongTonKho { get; set; }
        }
    }
}
