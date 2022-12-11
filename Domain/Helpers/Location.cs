namespace Domain;

public class Location
{
    public Guid Id;
    public Coordinates Coordinates { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}