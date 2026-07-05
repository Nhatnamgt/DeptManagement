using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeptManagement.RazorPage.Pages.QuanLiNapRut
{
    public class NaprutModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public NaprutModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ApiBaseUrl { get; private set; } = string.Empty;

        public void OnGet()
        {
            ApiBaseUrl = _configuration["ApiSettings:BaseUrl"]
                ?? "https://deptmanagement.onrender.com/api";
        }
    }
}
