using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedSomeHelp.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }

    public string? Wallet { get; set; }
    
    public virtual ICollection<HelpRequest> ContactedHelpRequests { get; set; } = new List<HelpRequest>();

    [InverseProperty(nameof(Review.Reviewee))]
    public virtual ICollection<Review> ReceivedReviews { get; set; } = new List<Review>();

    [InverseProperty(nameof(Review.Reviewer))]
    public virtual ICollection<Review> WrittenReviews { get; set; } = new List<Review>();
}
