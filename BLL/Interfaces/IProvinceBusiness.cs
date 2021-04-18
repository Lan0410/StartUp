using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IProvinceBusiness
    {
        List<ProvinceModel> GetAllData();
    }
}
