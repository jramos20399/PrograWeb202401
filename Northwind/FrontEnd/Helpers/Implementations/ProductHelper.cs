using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class ProductHelper : IProductHelper
    {
        IServiceRepository _repository;
        

        public ProductHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
           

        }

        public ProductViewModel AddProduct(ProductViewModel ProductViewModel)
        {
            ProductViewModel product = new ProductViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Product", ProductViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
               // var result = JsonConvert.DeserializeObject<bool>(content);
            }

            return new ProductViewModel { };
        }

        ProductViewModel Convertir(Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued
            };
        }

        Product Convertir(ProductViewModel product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued
            };
        }




        public void DeleteProduct(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Product/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }
        }

        public ProductViewModel EdiProduct(ProductViewModel ProductViewModel)
        {
            ProductViewModel product = new ProductViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Product", ProductViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                //var result = JsonConvert.DeserializeObject<bool>(content);
            }

            return ProductViewModel;
        }

        public List<ProductViewModel> GetAll()
        {
            List<ProductViewModel> lista = new List<ProductViewModel>();
            List<Product> result = new List<Product>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Product");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                 result = JsonConvert.DeserializeObject<List<Product>>(content);
            }

            foreach (var item in result)
            {
                lista.Add(Convertir(item));
            }

            return lista;
        }

        public ProductViewModel GetById(int id)
        {
            ProductViewModel Product = new ProductViewModel();
            Product resultado = new Product();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Product/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Product>(content);
            }
            Product = Convertir(resultado);
            return Product;
        }
    }
}
