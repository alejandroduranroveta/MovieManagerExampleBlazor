using Domain;
using Repository;

namespace BusinessLogic;

public class CategoryLogic
{
    private readonly IRepository<Category> _repository;

    public CategoryLogic(IRepository<Category> categoryRepository)
    {
        _repository = categoryRepository;
    }
    public Category AddMovie(Category category)
    {
        return _repository.Add(category);
    }

    public IList<Category> GetAll()
    {
        return _repository.FindAll();
    }
    
    public Category FindById(int id)
    {
        return _repository.Find(x => x.Id == id);
    }

    public Category Update(Category updatedCategory)
    {
        return _repository.Update(updatedCategory);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}