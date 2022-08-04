using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VaccineCovidManager.VaccineCovids;

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
            await _vaccineAppService.CreateAsync(
                ObjectMapper.Map<CreateVaccineCovidViewModal, CreateUpdateVaccineDto>(VaccineCovids));
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
