using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VaccineCovidManager.VaccineCovids;
using Volo.Abp;

namespace VaccineCovidManager.Web.Pages.VaccineCovids
{
    public class EditModalModel : VaccineCovidManagerPageModel
    {
        private readonly IVaccineAppService _vaccineAppService;

        public EditModalModel(IVaccineAppService vaccineAppService)
        {
            _vaccineAppService = vaccineAppService;
        }

        [BindProperty]
        public EditVaccineCovidViewModal EditVaccineCovids { get; set; }
        public async Task OnGetAsync(Guid Id)
        {
            var vaccine = await _vaccineAppService.GetVaccineCovidAsync(Id);
            EditVaccineCovids = ObjectMapper.Map<VaccineCovidDto, EditVaccineCovidViewModal>(vaccine);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (EditVaccineCovids.SoLuongTonKho >= 0)
            {
                await _vaccineAppService.UpdateAsync(
                    EditVaccineCovids.Id,
                    ObjectMapper.Map<EditVaccineCovidViewModal, CreateUpdateVaccineDto>(EditVaccineCovids));
            }
            else
            {
                throw new UserFriendlyException(L["Số lượng tồn kho nhỏ hơn 0"]);
            }
            return NoContent();
        }

        public class EditVaccineCovidViewModal
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [DisplayName("Tên Vaccine")]
            public string TenVaccine { get; set; }
            [DisplayName("Số lượng tồn kho")]
            public int SoLuongTonKho { get; set; }
        }
    }
}
