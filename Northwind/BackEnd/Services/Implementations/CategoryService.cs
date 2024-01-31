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
            Category entity = Convertir(category);
            _unidadDeTrabajo._categoryDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        CategoryModel Convertir(Category category)
        {
            return new CategoryModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }

        Category Convertir(CategoryModel category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }
        public bool DeteleCategory(CategoryModel category)
        {
            Category entity = Convertir(category);
            _unidadDeTrabajo._categoryDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public CategoryModel GetById(int id)
        {
           var entity = _unidadDeTrabajo._categoryDAL.Get(id);

            CategoryModel categoryModel = Convertir(entity);
            return categoryModel;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {

            var result = _unidadDeTrabajo._categoryDAL.GetAll();
            List<CategoryModel> lista = new List<CategoryModel>();
            foreach (var category in result)
            {
                lista.Add(Convertir(category));                  
                    

            }
           return lista;
        }

        public bool UpdateCategory(CategoryModel category)
        {
            Category entity = Convertir(category);
            _unidadDeTrabajo._categoryDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}
