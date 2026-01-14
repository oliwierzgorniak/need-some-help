using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedSomeHelp.Data;

public class Message
{
    public int Id { get; set; }

    [Required]
    public string SenderId { get; set; }

    [ForeignKey(nameof(SenderId))]
    public ApplicationUser Sender { get; set; } = null!;

    [Required]
    public string ReceiverId { get; set; }

    [ForeignKey(nameof(ReceiverId))]
    public ApplicationUser Receiver { get; set; } = null!;

    [Required]
    public string Content { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
}
