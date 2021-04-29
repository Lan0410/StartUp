using System;
using DAL;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class PageGroupBusiness:IPageGroupBusiness
    {
        IPageGroupRepository _res;
        public PageGroupBusiness(IPageGroupRepository res)
        {
            _res = res;
        }
        public PageGroupReturnModel GetAllData(PageGroupModelParameter model)
        {
            return _res.GetAllData(model);
        }

        public PageGroupModel GetDataID(int id)
        {
            return _res.GetDataID(id);
        }
        public int CreateOrUpdate(PageGroupModel model)
        {
            return _res.CreateOrUpdate(model);
        }

        public int Delete(PageGroupModel model)
        {
            return _res.Delete(model);
        }
    }
}
