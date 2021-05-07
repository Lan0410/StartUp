using System;
using DAL;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public partial class PageBusiness:IPageBusiness
    {
        IPageRepository _res;
        public PageBusiness(IPageRepository res)
        {
            _res = res;
        }
        public PageReturnModel GetDataAll(PageModelParameter model)
        {
            return _res.GetDataAll(model);
        }

        public PageModel GetDataID(int id)
        {
            return _res.GetDataID(id);
        }
        public int CreateOrUpdate(PageModel model)
        {
            return _res.CreateOrUpdate(model);
        }
        public int Delete(PageModel model)
        {
            return _res.Delete(model);
        }
    }
}
