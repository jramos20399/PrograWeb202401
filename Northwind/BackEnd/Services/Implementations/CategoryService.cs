using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CategoryService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddCategory(CategoryModel category)
        {
            Category entity = new Category
            {
                CategoryId = category.CategoryId,
                Description = category.Description,
                CategoryName = category.CategoryName

            };

            _unidadDeTrabajo._categoryDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        public bool DeteleCategory(CategoryModel category)
        {
            throw new NotImplementedException();
        }

        public CategoryModel GetById(int id)
        {
           var entity = _unidadDeTrabajo._categoryDAL.Get(id);

            CategoryModel categoryModel = new CategoryModel
            {

                CategoryId = entity.CategoryId,
                Description = entity.Description,
                CategoryName = entity.CategoryName
            };
            return categoryModel;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(CategoryModel category)
        {
            throw new NotImplementedException();
        }
    }
}
