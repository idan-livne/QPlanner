using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QPlanner.Pages.Portal;

namespace QPlanner.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            Response.Cookies.Delete(PortalPageModel.UserCookie);
            return RedirectToPage("/Index");
        }
    }
}
