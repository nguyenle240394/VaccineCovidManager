using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VaccineCovidManager.NoiSanXuats;
using Volo.Abp;

namespace VaccineCovidManager.Web.Pages.NoiSanXuats
{
    public class CreateModalModel : VaccineCovidManagerPageModel
    {
        private readonly INoiSanXuatAppService _noiSanXuatAppService;

        public CreateModalModel(INoiSanXuatAppService noiSanXuatAppService)
        {
            _noiSanXuatAppService = noiSanXuatAppService;
        }

        [BindProperty]
        public CreateNoiSanXuatViewModal NoiSanXuats { get; set; }
        public void OnGet()
        {
            NoiSanXuats = new CreateNoiSanXuatViewModal();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var noiSanXuatExist = await _noiSanXuatAppService.CheckTenNoiSanXuatExist(NoiSanXuats.TenNhaSX);
            if (noiSanXuatExist == false)
            {
                await _noiSanXuatAppService.CreateAsync(
                    ObjectMapper.Map<CreateNoiSanXuatViewModal, CreateUpdateNoiSanXuatDto>(NoiSanXuats));
            }
            else
            {
                throw new UserFriendlyException(L["Nhà sản xuất " + NoiSanXuats.TenNhaSX + " đã tồn tại"]);
            }
            return NoContent();
        }

        public class CreateNoiSanXuatViewModal
        {
            [Required]
            [DisplayName("Tên Nhà sản xuất")]
            public string TenNhaSX { get; set; }
            [Required]
            [DisplayName("Địa chỉ")]
            public string Diachi { get; set; }
            [Required]
            [DisplayName("Số điện thoại")]
            [RegularExpression("[0-9]{10}")]
            public string SDT { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }
    }
}
