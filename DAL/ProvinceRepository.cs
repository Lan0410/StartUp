using System;
using DAL.Helper;
using Model;
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
        public List<ProvinceModel> GetAllData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_province_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProvinceModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
