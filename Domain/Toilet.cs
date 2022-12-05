namespace Domain;

public class Toilet
{
    public Guid  Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }
    public string City { get; set; }
    public Toilet()
    {

    }
}