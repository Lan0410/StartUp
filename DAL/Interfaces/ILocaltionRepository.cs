using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
   public interface ILocaltionRepository
    {
        LocaltionReturnModel GetDataAll(LocaltionModelParameter model);
        LocaltionModel GetDataByID(int id);
        int CreateOrUpdate(LocaltionModel model);
        int Delete(LocaltionModel model);
    }
}
