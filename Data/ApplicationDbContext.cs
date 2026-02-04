using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NeedSomeHelp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<HelpRequest> HelpRequests { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ContactedHelpRequest> ContactedUserRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Review>()
            .HasOne(r => r.Reviewer)
            .WithMany(u => u.WrittenReviews)
            .HasForeignKey(r => r.ReviewerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Review>()
            .HasOne(r => r.Reviewee)
            .WithMany(u => u.ReceivedReviews)
            .HasForeignKey(r => r.RevieweeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Message>()
            .HasOne(m => m.Receiver)
            .WithMany()
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure One-to-Many relationship for Owner
        builder.Entity<HelpRequest>()
            .HasOne(r => r.Owner)
            .WithMany()
            .HasForeignKey(r => r.OwnerId)
            .OnDelete(DeleteBehavior.Cascade); // Keeping this cascade is fine if it doesn't conflict

        // Configure Explicit Many-to-Many relationship via ContactedHelpRequest
        builder.Entity<ContactedHelpRequest>()
            .HasKey(cr => new { cr.UserId, cr.RequestId });

        builder.Entity<ContactedHelpRequest>()
            .HasOne(cr => cr.User)
            .WithMany(u => u.ContactedRequests)
            .HasForeignKey(cr => cr.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ContactedHelpRequest>()
            .HasOne(cr => cr.Request)
            .WithMany(r => r.ContactedBy)
            .HasForeignKey(cr => cr.RequestId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
