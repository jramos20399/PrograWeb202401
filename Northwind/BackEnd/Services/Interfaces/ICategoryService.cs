using BackEnd.Models;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetCategories();
        CategoryModel GetById(int id);
        bool AddCategory(CategoryModel category);
        bool UpdateCategory(CategoryModel category);
        bool DeteleCategory(CategoryModel category);


    }
}
