using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ProductService : IProductService
    {

        IUnidadDeTrabajo Unidad;
        public ProductService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                Unidad = unidadDeTrabajo;
        }




        public Task<bool> Add(ProductModel product)
        {
            Unidad._productDAL.Add(Convertir(product));
            var result = Unidad.Complete();

            return Task.FromResult(result);
        }

        ProductModel Convertir(Product product)
        {
            return new ProductModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
               Discontinued = product.Discontinued
            };
        }

        Product Convertir(ProductModel product)
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

        public Task<bool> Delete(int id)
        {
            Product product = new Product { ProductId = id };

            Unidad._productDAL.Remove(product);
            var result = Unidad.Complete();

            return Task.FromResult(result);
        }

        public Task<ProductModel> GetById(int id)
        {
            Product product = Unidad._productDAL.Get(id);
            return Task.FromResult( Convertir(product));
        }

        public Task<List<ProductModel>> GetProducts()
        {
             
            var Products = Unidad._productDAL.GetAll();
            List<ProductModel> lista = new List<ProductModel>();
            foreach (var product in Products) {
                lista.Add(Convertir(product));
            }
            return Task.FromResult(lista);
        }

        public Task<bool> Update(ProductModel product)
        {
            Unidad._productDAL.Update(Convertir(product));
            var result = Unidad.Complete();

            return Task.FromResult(result);
        }
    }
}
