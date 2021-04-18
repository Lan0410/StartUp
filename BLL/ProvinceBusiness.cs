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
        public List<ProvinceModel> GetAllData()
        {
            return _res.GetAllData();
        }
    }
}
