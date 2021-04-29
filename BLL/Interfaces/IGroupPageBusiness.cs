using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface IGroupPageBusiness
    {
        GroupPageReturnModel GetDataAll(GroupPageModelParameter model);
        GroupPageModel GetDataID(int id);
        int CreateOrUpdate(GroupPageModel model);
        int Delete(GroupPageModel model);

    }
}
