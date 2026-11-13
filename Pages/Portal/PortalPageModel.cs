using Microsoft.AspNetCore.Mvc.RazorPages;
using QPlanner.Data;

namespace QPlanner.Pages.Portal
{
    // Every portal page inherits from this class so it knows who is logged in and which team is selected.
    public class PortalPageModel : PageModel
    {
        public const string UserCookie = "QPlannerUser";
        public const string TeamCookie = "QPlannerTeam";
        public const string GuestName = "Guest";

        public string UserName => Request.Cookies[UserCookie] ?? GuestName;

        public bool IsGuest => UserName == GuestName;

        public string TeamName => MockData.FindTeam(Request.Cookies[TeamCookie] ?? "").Name;
    }
}
