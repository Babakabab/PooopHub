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
    public DbSet<Pooper> Poopers { get; set; }
    public DbSet<ToiletModifier> ToiletModifiers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ToiletReviewer>(x => x.HasKey(tr => new { tr.ReviewerUserId,tr.ToiletId }));
        builder.Entity<ToiletReviewer>()
            .HasOne(t => t.Toilet)
            .WithMany(r => r.ToiletReviewers)
            .HasForeignKey(tr => tr.ToiletId);

        builder.Entity<ToiletReviewer>()
            .HasOne(t => t.AppUser)
            .WithMany(r => r.ReviewedToilets)
            .HasForeignKey(tr => tr.ReviewerUserId);

        builder.Entity<Pooper>(x => x.HasKey(p => new { p.AppUserId,p.ToiletId }));
        builder.Entity<Pooper>()
            .HasOne(t => t.AppUser)
            .WithMany(r => r.PoopedInToilets)
            .HasForeignKey(tr => tr.AppUserId);

        builder.Entity<Pooper>()
            .HasOne(t => t.Toilet)
            .WithMany(r => r.Poopers)
            .HasForeignKey(tr => tr.ToiletId);

        builder.Entity<ToiletModifier>(x => x.HasKey(t => new { t.AppUserId,t.ToiletId }));
        builder.Entity<ToiletModifier>()
            .HasOne(t => t.AppUser)
            .WithMany(r => r.ModifiedToilets)
            .HasForeignKey(tr => tr.AppUserId);

        builder.Entity<ToiletModifier>()
            .HasOne(t => t.Toilet)
            .WithMany(r => r.ToiletModifiers)
            .HasForeignKey(tr => tr.ToiletId);

        builder.Entity<Toilet>()
            .HasOne(c => c.Creator)
            .WithMany(t => t.CreatedToilets);

    }
}