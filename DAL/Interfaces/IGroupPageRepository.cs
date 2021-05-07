using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public interface IGroupPageRepository
    {
        GroupPageReturnModel GetDataAll(GroupPageModelParameter model);
        GroupPageReturnModel GetAll(GroupPageModelParameter model);
        GroupPageModel GetDataID(int id);
        int CreateOrUpdate(GroupPageModel model);
        int Delete(GroupPageModel model);
    }
}
