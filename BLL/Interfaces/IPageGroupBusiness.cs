using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface IPageGroupBusiness
    {
        PageGroupReturnModel GetAllData(PageGroupModelParameter model);
        PageGroupModel GetDataID(int id);
        int CreateOrUpdate(PageGroupModel model);
        int Delete(PageGroupModel model);

    }
}
