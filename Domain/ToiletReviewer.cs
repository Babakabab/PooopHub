namespace Domain;

public class ToiletReviewer
{
    public string ReviewerUserId { get; set; }
    public AppUser Reviewer { get; set; }
    public Guid ToiletId { get; set; }
    public Toilet Toilet { get; set; }

    public string Review { get; set; }
    public double Rating { get; set; }
    public bool IsCreator { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}