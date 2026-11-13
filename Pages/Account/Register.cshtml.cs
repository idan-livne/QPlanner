using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QPlanner.Data;

namespace QPlanner.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty] public string Username { get; set; } = "";
        [BindProperty] public string Password { get; set; } = "";
        [BindProperty] public string ConfirmPassword { get; set; } = "";
        [BindProperty] public string FirstName { get; set; } = "";
        [BindProperty] public string LastName { get; set; } = "";
        [BindProperty] public string City { get; set; } = "";
        [BindProperty] public string Phone { get; set; } = "";
        [BindProperty] public string Email { get; set; } = "";
        [BindProperty, Required] public DateTime? BirthDate { get; set; }
        [BindProperty] public string Gender { get; set; } = "";
        [BindProperty] public string Question1 { get; set; } = "";
        [BindProperty] public string Answer1 { get; set; } = "";
        [BindProperty] public string Question2 { get; set; } = "";
        [BindProperty] public string Answer2 { get; set; } = "";

        public List<SelectListItem> Questions =>
            MockData.SecurityQuestions.Select(q => new SelectListItem(q, q)).ToList();

        public void OnGet()
        {
        }

        // There is no database yet, so after the checks we just send the user to the login page.
        public IActionResult OnPost()
        {
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError(nameof(ConfirmPassword), "The two passwords do not match.");
            }

            if (Question1 == Question2)
            {
                ModelState.AddModelError(nameof(Question2), "Please choose two different questions.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Account/Login", new { registered = true });
        }
    }
}
