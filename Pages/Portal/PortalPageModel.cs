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

        // Returns the logged-in username, "Guest", or null when nobody logged in yet.
        public static string? LoggedInUser(HttpRequest request)
        {
            return request.Cookies[UserCookie];
        }

        public static string SelectedTeam(HttpRequest request)
        {
            return MockData.FindTeam(request.Cookies[TeamCookie] ?? "").Name;
        }

        public string UserName => LoggedInUser(Request) ?? GuestName;

        public bool IsGuest => UserName == GuestName;

        public string TeamName => SelectedTeam(Request);
    }
}
