using System;
using DAL.Helper;
using Model;
using System.Linq;
using ISCommon.Constant;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial class GenreRepository:IGenreRepository
    {
        private IDatabaseHelper _dbHelper;
        public GenreRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public GenreReturnModel GetDataAll(GenreModelParameter model)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_genre_search",
                    "@page_index", model.Page?.PageIndex,
                    "@page_size", model.Page?.PageSize,
                    "@tengenre", model.Data.Genre_Name);
                var result = new GenreReturnModel();
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                else
                {
                    result.Data = dt.ConvertTo<GenreModel>().ToList();
                    result.TotalRow = int.Parse(dt.Rows[0].ItemArray[dt.Rows[0].ItemArray.Length - 1].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GenreModel GetDataByID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_genre_get_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GenreModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateOrUpdate(GenreModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "GENRE_INSERT_OR_UPDATE",
                "@id", model.Id,
                "@genre_code", model.Genre_Code,
                "@genre_name", model.Genre_Name,
                "@sequence", model.Sequence,
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

        public int Delete(GenreModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_genre_delete",
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
