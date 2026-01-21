using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeedSomeHelp.Data;

namespace NeedSomeHelp.Pages;

public class LogoutModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public LogoutModel(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _signInManager.SignOutAsync();
        return LocalRedirect("/");
    }
    
    // Allow GET for simple Logout links if needed (though POST is safer/standard)
    public async Task<IActionResult> OnGetAsync()
    {
         await _signInManager.SignOutAsync();
         return LocalRedirect("/");
    }
}
