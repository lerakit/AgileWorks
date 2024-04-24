namespace Domain;

public class Request : BaseEntity
{
    public string Description { get; set; } = default!;
    
    public DateTime Deadline { get; set; }
    public DateTime AddedAt { get; set; }
    
    public bool Finished { get; set; }
    
}