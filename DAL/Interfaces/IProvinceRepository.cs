using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public interface IProvinceRepository
    {
        List<ProvinceModel> GetAllData();
    }
}
