using Domain;

namespace Repository;

public class MovieMemoryRepository : IRepository<Movie>
{

    private List<Movie> _movies = new List<Movie>()
    {
        new Movie()
        {
            Title = "Avatar",
            Director = "Bruno B",
            ReleaseYear = 2023
        }
    };
    public Movie Add(Movie oneElement)
    {
        oneElement.Id = _movies.OrderByDescending(x => x.Id)
            .Select(x => x.Id)
            .FirstOrDefault() + 1;
        _movies.Add(oneElement);
        return oneElement;
    }

    public Movie? Find(Func<Movie, bool> filter)
    {
        return _movies.Where(filter).FirstOrDefault();
    }

    public IList<Movie> FindAll()
    {
        return _movies;
    }

    public Movie? Update(Movie updatedEntity)
    {
        Movie findedMovie = Find(x => x.Id == updatedEntity.Id);
        findedMovie = updatedEntity;
        return findedMovie;
    }

    public void Delete(int id)
    {
        _movies.RemoveAll(x => x.Id == id);
    }
}