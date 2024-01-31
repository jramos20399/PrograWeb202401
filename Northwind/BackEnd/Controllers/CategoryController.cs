using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            return CategoryService.GetCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryModel Get(int id)
        {
            return CategoryService.GetById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public string Post([FromBody] CategoryModel category)
        {
            var result = CategoryService.AddCategory(category);

            if (result)
            {
                return "Categoría Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public string Put([FromBody] CategoryModel category)
        {
            var result = CategoryService.UpdateCategory(category);

            if (result)
            {
                return "Categoría Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            CategoryModel category = new CategoryModel { CategoryId = id };
            var result = CategoryService.DeteleCategory(category);

            if (result)
            {
                return "Categoría Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}
