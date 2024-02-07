using BackEnd.Models;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();
        Task<bool> Add(ProductModel product);
        Task<bool> Update(ProductModel product);
        Task<bool> Delete(int id);
        Task<ProductModel> GetById(int id);

    }
}
