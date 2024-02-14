using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
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


        public bool Add(Category entity)
        {
            try
            {

                string sql = "exec [dbo].[sp_AddCategory] @CategoryName, @Description";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName= "@CategoryName",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.CategoryName
                    },
                    new SqlParameter()
                    {
                        ParameterName= "@Description",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value=entity.Description
                    }

                };


                _Context.Database.ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
