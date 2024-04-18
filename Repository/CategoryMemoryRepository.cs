using Domain;

namespace Repository;

public class CategoryMemoryRepository : IRepository<Category>
{

    private List<Category> _categories = new List<Category>();
    
    public Category Add(Category oneElement)
    {
        oneElement.Id = _categories.OrderByDescending(x => x.Id)
            .Select(x => x.Id)
            .FirstOrDefault() + 1;
        _categories.Add(oneElement);
        return oneElement;
    }

    public Category? Find(Func<Category, bool> filter)
    {
        return _categories.Where(filter).FirstOrDefault();
    }

    public IList<Category> FindAll()
    {
        return _categories;
    }

    public Category? Update(Category updatedEntity)
    {
        Category findCategory = Find(x => x.Id == updatedEntity.Id);
        findCategory = updatedEntity;
        return findCategory;
    }

    public void Delete(int id)
    {
        _categories.RemoveAll(x => x.Id == id);
    }
    
}