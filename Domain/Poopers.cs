namespace Domain;

public class Pooper
{
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public Guid ToiletId { get; set; }
    public Toilet Toilet { get; set; }

    public DateTime PoopedAt { get; set; }
}