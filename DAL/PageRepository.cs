using System;
using DAL.Helper;
using Model;
using System.Linq;
using ISCommon.Constant;

namespace DAL
{
    public partial class PageRepository:IPageRepository
    {
        private IDatabaseHelper _dbHelper;
        public PageRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public PageReturnModel GetDataAll(PageModelParameter model)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_page_search",
                    "@page_index", model.Page?.PageIndex,
                    "@page_size", model.Page?.PageSize,
                    "@tenpage", model.Data.Page_Name);
                var result = new PageReturnModel();
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                else
                {
                    result.Data = dt.ConvertTo<PageModel>().ToList();
                    result.TotalRow = int.Parse(dt.Rows[0].ItemArray[dt.Rows[0].ItemArray.Length - 1].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PageModel GetDataID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Page_get_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PageModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateOrUpdate(PageModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "PAGE_INSERT_OR_UPDATE",
                "@id", model.Id,
                "@Page_code", model.Page_Code,
                "@Page_name", model.Page_Name,
                "@Id_group_page",model.Id_Group_Page,
                "@is_public", model.Is_public,
                "@description", model.Description,
                "@active", model.Active);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                else
                {
                    return Constant.ReturnExcuteFunction.Success;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(PageModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Page_delete",
                "@id", model.Id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                else
                {
                    return Constant.ReturnExcuteFunction.Success;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
