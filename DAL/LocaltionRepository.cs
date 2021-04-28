using System;
using DAL.Helper;
using Model;
using System.Linq;
using ISCommon.Constant;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial class LocaltionRepository:ILocaltionRepository
    {
        private IDatabaseHelper _dbHelper;
        public LocaltionRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public LocaltionReturnModel GetDataAll(LocaltionModelParameter model)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_localtion_search",
                    "@page_index", model.Page?.PageIndex,
                    "@page_size", model.Page?.PageSize,
                    "@tenlocaltion", model.Data.Localtion_Name);
                var result = new LocaltionReturnModel();
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                else
                {
                    result.Data = dt.ConvertTo<LocaltionModel>().ToList();
                    result.TotalRow = int.Parse(dt.Rows[0].ItemArray[dt.Rows[0].ItemArray.Length - 1].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LocaltionModel GetDataByID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_localtion_get_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LocaltionModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateOrUpdate(LocaltionModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "LOCALTION_INSERT_OR_UPDATE",
                "@id", model.Id,
                "@localtion_code", model.Localtion_Code,
                "@localtion_name", model.Localtion_Name,
                "@point_x", model.Point_X,
                "@poin_y", model.Point_Y,
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

        public int Delete(LocaltionModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_localtion_delete",
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
