using BusinessLogic;
using Domain;
using Repository;

namespace BusinessLogicTest;

[TestClass]
public class MovieLogicTest
{
    private MovieLogic _movieLogic;
    private IRepository<Movie> _movieRepository;
    
    [TestInitialize]
    public void SetUp()
    {
        _movieRepository = new MovieMemoryRepository();
        _movieLogic = new MovieLogic(_movieRepository);
    }
    
    [TestMethod]
    public void AddOneMovieOkTest()
    {
        Movie movie = new Movie()
        {
            Title = "Avatar",
            Director = "One Director",
            ReleaseYear = 2020
        };
        
        Movie returnMovie = _movieLogic.AddMovie(movie);
        
        Assert.AreEqual(1, returnMovie.Id);
        Assert.AreEqual(movie.Title, returnMovie.Title);
        Assert.AreEqual(movie.Director, returnMovie.Director);
        Assert.AreEqual(movie.ReleaseYear, returnMovie.ReleaseYear);
    }
    
    [TestMethod]
    [ExpectedException(typeof(LogicException))]
    public void AddMovieSameNameOkTest()
    {
        Movie movieOne = new Movie()
        {
            Title = "Avatar",
            Director = "One Director",
            ReleaseYear = 2020
        };
        Movie movieTwo = new Movie()
        {
            Title = "Avatar",
            Director = "One Director",
            ReleaseYear = 2020
        };

        _movieLogic.AddMovie(movieOne);
        _movieLogic.AddMovie(movieTwo);
    }
    
    [TestMethod]
    public void AddTwoMovieOkTest()
    {
        Movie movieOne = new Movie()
        {
            Title = "Avatar",
            Director = "One Director",
            ReleaseYear = 2020
        };
        Movie movieTwo = new Movie()
        {
            Title = "Avatar 2",
            Director = "One Director",
            ReleaseYear = 2020
        };

        Movie returnMovieOne = _movieLogic.AddMovie(movieOne);
        Movie returnMovieTwo = _movieLogic.AddMovie(movieTwo);

        Assert.AreEqual(1, returnMovieOne.Id);        
        Assert.AreEqual(2, returnMovieTwo.Id);
    }
    
    [TestMethod]
    public void ListAllMovieOkTest()
    {
        Movie movieOne = new Movie()
        {
            Title = "Avatar",
            Director = "One Director",
            ReleaseYear = 2020
        };
        Movie movieTwo = new Movie()
        {
            Title = "Avatar 2",
            Director = "One Director",
            ReleaseYear = 2020
        };

        Movie returnMovieOne = _movieLogic.AddMovie(movieOne);
        Movie returnMovieTwo = _movieLogic.AddMovie(movieTwo);

        IList<Movie> resultMovies = _movieLogic.GetAll();

        Assert.AreEqual("Avatar", resultMovies.FirstOrDefault(x => x.Id == 1).Title);        
        Assert.AreEqual("Avatar 2", resultMovies.FirstOrDefault(x => x.Id == 2).Title);        

    }
    
    [TestMethod]
    [ExpectedException(typeof(DomainException))]
    public void AddOneMovieTitleEmptyTest()
    {
        Movie movie = new Movie()
        {
            Title = "",
            Director = "One Director",
            ReleaseYear = 2020
        };
    }
    
    [TestMethod]
    [ExpectedException(typeof(DomainException))]
    public void AddOneMovieTitleNullTest()
    {
        Movie movie = new Movie()
        {
            Title = null,
            Director = "One Director",
            ReleaseYear = 2020
        };
    }
    
}