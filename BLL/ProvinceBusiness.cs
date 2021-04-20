using System;
using DAL;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class ProvinceBusiness: IProvinceBusiness
    {
        IProvinceRepository _res;
        public ProvinceBusiness(IProvinceRepository res)
        {
            _res = res;
        }
        public ProvinceReturnModel GetAllData(ProvinceModelParameter model)
        {
            return _res.GetAllData(model);
        }

        public ProvinceModel GetDataID(int id)
        {
            return _res.GetDataID(id);
        }
        public int CreateOrUpdate(ProvinceModel model)
        {
            return _res.CreateOrUpdate(model);
        }

        public int Delete(ProvinceModel model)
        {
            return _res.Delete(model);
        }
    }
}
