namespace Domain;

public class Movie
{
    public int Id { get; set; }

    private string? _title;

    public string? Title
    {
        get => _title;
        set
        {
            if (value is null || value.Length == 0)
            {
                throw new DomainException("Title must not be empty");
            }
            _title = value;
        }
    }

    public string? Director { get; set; }

    public int? ReleaseYear { get; set; }

    public Category Category { get; set; }

    public List<Actor> Actors { get; set; } = new List<Actor>();
    
    public bool HasActor(int id){
        return Actors.Any(a => a.Id == id);
    }
}