using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public interface IProvinceRepository
    {
        ProvinceReturnModel GetAllData(ProvinceModelParameter model);
        ProvinceModel GetDataID(int id);
        int CreateOrUpdate(ProvinceModel model);
        int Delete(ProvinceModel model);
    }
}
