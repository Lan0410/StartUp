using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IProvinceBusiness
    {
        ProvinceReturnModel GetAllData(ProvinceModelParameter model);
        ProvinceModel GetDataID(int id);
        int CreateOrUpdate(ProvinceModel model);
        int Delete(ProvinceModel model);
    }
}
