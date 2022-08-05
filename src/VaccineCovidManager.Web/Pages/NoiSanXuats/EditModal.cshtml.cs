using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VaccineCovidManager.NoiSanXuats;

namespace VaccineCovidManager.Web.Pages.NoiSanXuats
{
    public class EditModalModel : VaccineCovidManagerPageModel
    {
        private readonly INoiSanXuatAppService _noiSanXuatAppService;

        public EditModalModel(INoiSanXuatAppService noiSanXuatAppService)
        {
            _noiSanXuatAppService = noiSanXuatAppService;
        }

        [BindProperty]
        public EditNoiSanXuatViewModal EditNoiSanXuats { get; set; }
        public async Task OnGetAsync(Guid Id)
        {
            var editnsx = await _noiSanXuatAppService.GetNoiSanXuatAsync(Id);
            EditNoiSanXuats = ObjectMapper.Map<NoiSanXuatDto, EditNoiSanXuatViewModal>(editnsx);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _noiSanXuatAppService.UpdateAsync(
                EditNoiSanXuats.Id,
                ObjectMapper.Map<EditNoiSanXuatViewModal, CreateUpdateNoiSanXuatDto>(EditNoiSanXuats));
            return NoContent();
        }

        public class EditNoiSanXuatViewModal
        {
            [HiddenInput]
            public Guid Id { get; set; } 
            [DisplayName("Tên Nhà sản xuất")]
            public string TenNhaSX { get; set; }
            [DisplayName("Địa chỉ")]
            public string Diachi { get; set; }
            [DisplayName("Số điện thoại")]
            [RegularExpression("[0-9]{10}")]
            public string SDT { get; set; }
            [EmailAddress]
            public string Email { get; set; }
        }
    }
}
