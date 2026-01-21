using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedSomeHelp.Data;

public class Review
{
    public int Id { get; set; }

    [Range(0, 5)]
    public int Rating { get; set; }

    [MaxLength(500)]
    public string Content { get; set; } = string.Empty;

    // Optional reference for blockchain (e.g. transaction signature)
    public string? BlockchainReference { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public string ReviewerId { get; set; } = string.Empty;

    [ForeignKey(nameof(ReviewerId))]
    public ApplicationUser Reviewer { get; set; } = null!;

    [Required]
    public string RevieweeId { get; set; } = string.Empty;

    [ForeignKey(nameof(RevieweeId))]
    public ApplicationUser Reviewee { get; set; } = null!;
    
    public int? HelpRequestId { get; set; }
    
    [ForeignKey(nameof(HelpRequestId))]
    public HelpRequest? HelpRequest { get; set; }
}
