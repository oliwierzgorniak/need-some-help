using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedSomeHelp.Data;

public class HelpRequest
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Location { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? PhotoUrl { get; set; }

    [Required]
    public string OwnerId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public ApplicationUser Owner { get; set; } = null!;

    public virtual ICollection<ApplicationUser> ContactedByUsers { get; set; } = new List<ApplicationUser>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
