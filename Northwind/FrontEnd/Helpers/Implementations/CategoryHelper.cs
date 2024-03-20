using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {
        IServiceRepository ServiceRepository;
        public string Token { get; set; }

        public CategoryHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public CategoryViewModel AddCategory(CategoryViewModel category)
        {
           
            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Category", Convertir(category));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
              // var  categoryAPI = JsonConvert.DeserializeObject<Category>(content);
            }

            return category;
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

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Category/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new CategoryViewModel();
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
            CategoryViewModel category = new CategoryViewModel();
            ServiceRepository.Client.DefaultRequestHeaders.Authorization =
               new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
        
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Category/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                category = Convertir(JsonConvert.DeserializeObject<Category>(content));
            }

            return category;
        }

        public CategoryViewModel UpdateCategory(CategoryViewModel category)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Category", Convertir(category));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
             // var  categoryAPI = JsonConvert.DeserializeObject<Category>(content);
            }

            return category;
        }
    }
}
