using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedSomeHelp.Data;

public class ContactedHelpRequest
{
    public string UserId { get; set; } = string.Empty;
    
    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    public int RequestId { get; set; }

    [ForeignKey(nameof(RequestId))]
    public HelpRequest Request { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
