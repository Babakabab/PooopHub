using Microsoft.AspNetCore.Identity;

namespace Domain;

public class AppUser: IdentityUser
{
    public string DisplayName { get; set; }

    public ICollection<ToiletReviewer> ReviewedToilets { get; set; }

    public ICollection<Toilet> CreatedToilets { get; set; } = new List<Toilet>();
    public ICollection<ToiletModifier> ModifiedToilets { get; set; } = new List<ToiletModifier>();
    public ICollection<Pooper> PoopedInToilets { get; set; } = new List<Pooper>();
}