using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoryHelper
    {
         string Token { get; set; }
        List<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategory(int id);
        CategoryViewModel AddCategory(CategoryViewModel category);
        CategoryViewModel DeleteCategory(int id);
        CategoryViewModel UpdateCategory(CategoryViewModel category);

    }
}
