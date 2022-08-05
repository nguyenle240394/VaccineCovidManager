using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VaccineCovidManager.DonViYTes;
using Volo.Abp;

namespace VaccineCovidManager.Web.Pages.DonViYTes
{
    public class CreateModalModel : VaccineCovidManagerPageModel
    {
        private readonly IDonViYTeAppService _donViYTeAppService;

        public CreateModalModel(IDonViYTeAppService donViYTeAppService)
        {
            _donViYTeAppService = donViYTeAppService;
        }

        [BindProperty]
        public CreateDonViYTeViewModal DonViYTes { get; set; }

        public void OnGet()
        {
            DonViYTes = new CreateDonViYTeViewModal();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var donviyteExist = await _donViYTeAppService.CheckDonViYTeExist(DonViYTes.TenDonViYTe);
            if(donviyteExist == false)
            {
                await _donViYTeAppService.CreateAsync(
                    ObjectMapper.Map<CreateDonViYTeViewModal, CreateUpdateDonViYTeDto>(DonViYTes));
            }
            else
            {
                throw new UserFriendlyException(L["Đơn vị Y tế " + DonViYTes.TenDonViYTe + " đã tồn tại"]);
            }
            return NoContent();
        }

        public class CreateDonViYTeViewModal
        {
            [Required]
            [DisplayName("Tên Đơn vị Y tế")]
            public string TenDonViYTe { get; set; }
            [Required]
            [DisplayName("Địa chỉ")]
            public string DiaChi { get; set; }
            [Required]
            [DisplayName("Số điện thoại")]
            [RegularExpression("[0-9]{10}")]
            public string SDT { get; set; }
        }
    }
}
