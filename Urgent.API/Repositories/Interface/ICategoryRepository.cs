using Urgent.API.Models.Domain;

namespace Urgent.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category); //Creates a category injects it in the database and returns the Category.

    }
}
