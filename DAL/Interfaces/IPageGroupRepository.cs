using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IPageGroupRepository
    {
        PageGroupReturnModel GetAllData(PageGroupModelParameter model);
        PageGroupModel GetDataID(int id);
        int CreateOrUpdate(PageGroupModel model);
        int Delete(PageGroupModel model);

    }
}
