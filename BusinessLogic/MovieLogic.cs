using Domain;
using Repository;

namespace BusinessLogic;

public class MovieLogic
{
    private readonly IRepository<Movie> _repository;

    public MovieLogic(IRepository<Movie> movieRepository)
    {
        _repository = movieRepository;
    }
    public Movie AddMovie(Movie movie)
    {
        ValidateMovieName(movie);
        return _repository.Add(movie);
    }

    public IList<Movie> GetAll()
    {
        return _repository.FindAll();
    }
    
    public Movie FindById(int id)
    {
        return _repository.Find(x => x.Id == id);
    }

    public Movie Update(Movie updatedMovie)
    {
        return _repository.Update(updatedMovie);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    private void ValidateMovieName(Movie movie)
    {
        if (_repository.Find(movieToFind => movieToFind.Title == movie.Title) != null)
        {
            throw new LogicException("Can't add movie with same Title");
        }
    }
}