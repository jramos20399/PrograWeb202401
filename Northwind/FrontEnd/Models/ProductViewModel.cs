using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ProductViewModel
    {

        public int ProductId { get; set; }
        [Required(ErrorMessage ="Debe digitar un nombre")]
        public string ProductName { get; set; } = null!;
        public int? SupplierId { get; set; }
        public IEnumerable<SupplierViewModel> Suppliers { get; set; }

        [Display(Name ="Categoría")]
        public int? CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public CategoryViewModel Category { get; set; }


        public bool Discontinued { get; set; }
    }
}
