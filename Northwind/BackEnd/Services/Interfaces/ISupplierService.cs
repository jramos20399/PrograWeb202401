using BackEnd.Models;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> GetSuppliers();

    }
}
