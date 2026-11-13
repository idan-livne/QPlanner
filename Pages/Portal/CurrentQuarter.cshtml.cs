using QPlanner.Data;

namespace QPlanner.Pages.Portal
{
    public class CurrentQuarterModel : QuarterPageModel
    {
        public void OnGet()
        {
            LoadQuarter(MockData.CurrentQuarter, "/Portal/CurrentQuarter");
        }
    }
}
