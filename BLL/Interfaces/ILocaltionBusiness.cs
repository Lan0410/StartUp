using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface ILocaltionBusiness
    {
        LocaltionReturnModel GetDataAll(LocaltionModelParameter model);
        LocaltionModel GetDataByID(int id);
        int CreateOrUpdate(LocaltionModel model);
        int Delete(LocaltionModel model);

    }
}
