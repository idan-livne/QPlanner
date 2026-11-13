using Microsoft.AspNetCore.Mvc;
using QPlanner.Data;

namespace QPlanner.Pages.Portal
{
    public class SettingsModel : PortalPageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "user";

        public string Message { get; set; } = "";
        public bool Success { get; set; }

        public void OnGet(bool saved)
        {
            if (saved)
            {
                Message = "The team was changed. All portal pages now show " + TeamName + ".";
                Success = true;
            }
        }

        // There is no database yet, so the new password is checked but not saved.
        public void OnPostPassword(string newPassword, string confirmPassword)
        {
            Tab = "user";
            if (IsGuest)
            {
                Message = "Guests can only view the site. Log in to change your password.";
            }
            else if (newPassword != confirmPassword)
            {
                Message = "The new passwords do not match.";
            }
            else
            {
                Message = "Your password was changed (demo only, it is not saved until the site has a database).";
                Success = true;
            }
        }

        public IActionResult OnPostTeam(string selectedTeam)
        {
            Response.Cookies.Append(TeamCookie, MockData.FindTeam(selectedTeam).Name);
            return RedirectToPage(new { tab = "team", saved = true });
        }
    }
}
