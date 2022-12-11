using Domain;

namespace Application.Toilets;

public class ToiletDto
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
    public Profile.Profile Creator { get; set; }

}