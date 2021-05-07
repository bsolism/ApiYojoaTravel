using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategory();
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        Task UpdateCategory(Category category);
        Task<Category> FindCategory(int categoryId);
    }
}