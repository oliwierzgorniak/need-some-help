using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NeedSomeHelp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<HelpRequest> HelpRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
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

        // Configure Many-to-Many relationship with NO ACTION deletion to avoid cycles
        builder.Entity<ApplicationUser>()
            .HasMany(u => u.ContactedHelpRequests)
            .WithMany(r => r.ContactedByUsers)
            .UsingEntity<Dictionary<string, object>>(
                "ContactedHelpRequests",
                j => j.HasOne<HelpRequest>().WithMany().HasForeignKey("ContactedHelpRequestsId").OnDelete(DeleteBehavior.Restrict), // Prevent cascading delete from Request
                j => j.HasOne<ApplicationUser>().WithMany().HasForeignKey("ContactedByUsersId").OnDelete(DeleteBehavior.Restrict)   // Prevent cascading delete from User
            );
    }
}
