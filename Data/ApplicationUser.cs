using Microsoft.AspNetCore.Identity;

namespace NeedSomeHelp.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
    
    public virtual ICollection<HelpRequest> ContactedHelpRequests { get; set; } = new List<HelpRequest>();
}
