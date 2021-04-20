using System;
using DAL.Helper;
using Model;
using ISCommon.Constant;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial class ProvinceRepository:IProvinceRepository
    {
        private IDatabaseHelper _dbHelper;
        public ProvinceRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public ProvinceReturnModel GetAllData(ProvinceModelParameter model)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_province_search",
                    "@page_index", model.Page?.PageIndex,
                    "@page_size", model.Page?.PageSize,
                    "@tenprovince", model.Data.Province_Name);
                var result = new ProvinceReturnModel();
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                else
                {
                    result.Data = dt.ConvertTo<ProvinceModel>().ToList();
                    result.TotalRow = int.Parse(dt.Rows[0].ItemArray[dt.Rows[0].ItemArray.Length - 1].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProvinceModel GetDataID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_province_get_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProvinceModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateOrUpdate(ProvinceModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "PROVINCE_INSERT_OR_UPDATE",
                "@id", model.Id,
                "@province_code", model.Province_Code,
                "@province_name", model.Province_Name,
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



        public int Delete(ProvinceModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_province_delete",
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
