using Domain;
using Repository;

namespace BusinessLogic;

public class ActorLogic
{
    private readonly IRepository<Actor> _repository;

    public ActorLogic(IRepository<Actor> actorRepository)
    {
        _repository = actorRepository;
    }
    public Actor AddMovie(Actor movie)
    {
        return _repository.Add(movie);
    }

    public IList<Actor> GetAll()
    {
        return _repository.FindAll();
    }
    
    public Actor FindById(int id)
    {
        return _repository.Find(x => x.Id == id);
    }

    public Actor Update(Actor updatedActor)
    {
        return _repository.Update(updatedActor);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}