using System;
using DAL.Helper;
using Model;
using System.Linq;
using ISCommon.Constant;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial class CategoryRepository:ICategoryRepository
    {
        private IDatabaseHelper _dbHelper;
        public CategoryRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public CategoryReturnModel GetDataAll(CategoryModelParameter model)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_category_search",
                    "@page_index", model.Page?.PageIndex,
                    "@page_size", model.Page?.PageSize,
                    "@tencate", model.Data.Category_Name);
                var result = new CategoryReturnModel();
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                else
                {
                    result.Data = dt.ConvertTo<CategoryModel>().ToList();
                    result.TotalRow = int.Parse(dt.Rows[0].ItemArray[dt.Rows[0].ItemArray.Length - 1].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
