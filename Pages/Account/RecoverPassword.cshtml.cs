using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QPlanner.Data;

namespace QPlanner.Pages.Account
{
    public class RecoverPasswordModel : PageModel
    {
        [BindProperty] public string Username { get; set; } = "";
        [BindProperty] public string Question1 { get; set; } = "";
        [BindProperty] public string Answer1 { get; set; } = "";
        [BindProperty] public string Question2 { get; set; } = "";
        [BindProperty] public string Answer2 { get; set; } = "";

        public bool Sent { get; set; }

        public List<SelectListItem> Questions =>
            MockData.SecurityQuestions.Select(q => new SelectListItem(q, q)).ToList();

        public void OnGet()
        {
        }

        // There is no database yet, so we cannot check the answers. We only show a message.
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Sent = true;
            }
        }
    }
}
