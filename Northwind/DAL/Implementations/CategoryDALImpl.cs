using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoryDALImpl : DALGenericoImpl<Category>, ICategoryDAL
    {
        NorthWindContext _context;

        public CategoryDALImpl(NorthWindContext context): base(context) 
        {
            _context = context;        
        }



        public IEnumerable<Category> GetAll()
        {
            List<sp_GetAllCategories_Result> results;

            string sql = "[dbo].[sp_GetAllCategories]";

            results = _context.Sp_GetAllCategories_Results
                        .FromSqlRaw(sql)
                        .ToList();

            List<Category> categories = new List<Category>();

            foreach (var item in results)
            {
                categories.Add(
                    new Category
                    {
                        CategoryId= item.CategoryId,
                        CategoryName = item.CategoryName,
                        Description = item.Description,
                        Picture = item.Picture
                    }
                    );
            }



            return categories;
        }
    }
}
