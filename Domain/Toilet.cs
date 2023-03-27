namespace Domain;

public class Toilet
{
    public Guid  Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public double lat { get; set; }
    public double lng { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatorUserId { get; set; }
    public AppUser Creator { get; set; }

    public ICollection<ToiletReviewer> ToiletReviewers { get; set; } = new List<ToiletReviewer>();
    public ICollection<ToiletModifier> ToiletModifiers { get; set; } = new List<ToiletModifier>();
    public ICollection<Pooper> Poopers { get; set; } = new List<Pooper>();
}