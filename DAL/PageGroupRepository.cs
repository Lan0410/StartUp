using System;
using DAL.Helper;
using Model;
using ISCommon.Constant;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial class PageGroupRepository: IPageGroupRepository
    {
        private IDatabaseHelper _dbHelper;
        public PageGroupRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public PageGroupReturnModel GetAllData(PageGroupModelParameter model)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_page_group_search",
                    "@page_index", model.Page?.PageIndex,
                    "@page_size", model.Page?.PageSize,
                    "@tenpr", model.Data.GroupPage_Name);
                var result = new PageGroupReturnModel();
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                else
                {
                    result.Data = dt.ConvertTo<PageGroupModel>().ToList();
                    result.TotalRow = int.Parse(dt.Rows[0].ItemArray[dt.Rows[0].ItemArray.Length - 1].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public PageGroupModel GetDataID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Page_Group_get_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PageGroupModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateOrUpdate(PageGroupModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "PAGE_GROUP_INSERT_OR_UPDATE",
                "@id", model.Id,
                "@groupPage_code", model.GroupPage_Code,
                "@groupPage_name", model.GroupPage_Name,
                "@is_public",model.Is_public,
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

        public int Delete(PageGroupModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_page_group_delete",
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
