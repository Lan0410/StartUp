using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public interface IPageRepository
    {
        PageReturnModel GetDataAll(PageModelParameter model);
        PageModel GetDataID(int id);
        int CreateOrUpdate(PageModel model);
        int Delete(PageModel model);
    }
}
