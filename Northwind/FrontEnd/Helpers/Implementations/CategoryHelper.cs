using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {
        IServiceRepository ServiceRepository;
       
        public CategoryHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public CategoryViewModel AddCategory(CategoryViewModel category)
        {
            throw new NotImplementedException();
        }


        Category Convertir(CategoryViewModel category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }

        CategoryViewModel Convertir(Category category)
        {
            return new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }


        public CategoryViewModel DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryViewModel> GetCategories()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/category");
            List<Category> resultado = new List<Category>() ;
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Category>>(content);
            }
            List<CategoryViewModel> lista = new List<CategoryViewModel>();

            if (resultado!=null && resultado.Count>0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;
            


        }

        public CategoryViewModel GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryViewModel UpdateCategory(CategoryViewModel category)
        {
            throw new NotImplementedException();
        }
    }
}
