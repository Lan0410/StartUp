using System;
using DAL;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class LocaltionBusiness:ILocaltionBusiness
    {
        ILocaltionRepository _res;
        public LocaltionBusiness(ILocaltionRepository res)
        {
            _res = res;
        }
        public LocaltionReturnModel GetDataAll(LocaltionModelParameter model)
        {
            return _res.GetDataAll(model);
        }
        public LocaltionModel GetDataByID(int id)
        {
            return _res.GetDataByID(id);
        }
        public int CreateOrUpdate(LocaltionModel model)
        {
            return _res.CreateOrUpdate(model);
        }

        public int Delete(LocaltionModel model)
        {
            return _res.Delete(model);
        }
    }
}
