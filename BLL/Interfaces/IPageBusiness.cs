using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface IPageBusiness
    {
        PageReturnModel GetDataAll(PageModelParameter model);
        PageModel GetDataID(int id);
        int CreateOrUpdate(PageModel model);
        int Delete(PageModel model);
    }
}
