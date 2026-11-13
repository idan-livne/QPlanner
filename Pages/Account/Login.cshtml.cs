using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QPlanner.Pages.Portal;

namespace QPlanner.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public bool Registered { get; set; }

        public void OnGet(bool registered)
        {
            Registered = registered;
        }

        // There is no database yet, so every username and password is accepted.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Response.Cookies.Append(PortalPageModel.UserCookie, Username);
            return RedirectToPage("/Portal/Home");
        }

        public IActionResult OnPostGuest()
        {
            Response.Cookies.Append(PortalPageModel.UserCookie, PortalPageModel.GuestName);
            return RedirectToPage("/Portal/Home");
        }
    }
}
