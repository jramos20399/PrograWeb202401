using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        public IUnidadDeTrabajo Unidad;


        SupplierModel Convertir(Supplier supplier)
        {
            return new SupplierModel 
            { 
                CompanyName = supplier.CompanyName,
                SupplierId = supplier.SupplierId
            };
        }

        public SupplierService(IUnidadDeTrabajo unidad)
        {
                Unidad = unidad;
        }


        public IEnumerable<SupplierModel> GetSuppliers()
        {
            var suppliers = Unidad._supplierDAL.GetAll();
            List<SupplierModel> result = new List<SupplierModel>();
            foreach (var supplier in suppliers)
            {
                result.Add(Convertir(supplier));
            }
            return result;
        }
    }
}
