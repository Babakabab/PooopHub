using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class DataContext : IdentityDbContext<AppUser>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Toilet> Toilets { get; set; }
    public DbSet<ToiletReviewer> ToiletReviewers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ToiletReviewer>(x => x.HasKey(tr => new { tr.ReviewerUserId,tr.ToiletId }));
        builder.Entity<ToiletReviewer>()
            .HasOne(t => t.Toilet)
            .WithMany(r => r.ToiletReviewers)
            .HasForeignKey(tr => tr.ToiletId);

        builder.Entity<ToiletReviewer>()
            .HasOne(t => t.Reviewer)
            .WithMany(r => r.ReviewedToilets)
            .HasForeignKey(tr => tr.ReviewerUserId);

        builder.Entity<Toilet>()
            .HasOne(c => c.Creator)
            .WithMany(t => t.CreatedToilets);

    }
}