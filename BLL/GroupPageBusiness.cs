using System;
using DAL;
using Model;
using System.Collections.Generic;
using System.Text;


namespace BLL
{
    public partial class GroupPageBusiness:IGroupPageBusiness
    {
        IGroupPageRepository _res;
        public GroupPageBusiness(IGroupPageRepository res)
        {
            _res = res;
        }
        public GroupPageReturnModel GetDataAll(GroupPageModelParameter model)
        {
            return _res.GetDataAll(model);
        }

        public GroupPageModel GetDataID(int id)
        {
            return _res.GetDataID(id);
        }

        public int CreateOrUpdate(GroupPageModel model)
        {
            return _res.CreateOrUpdate(model);
        }

        public int Delete(GroupPageModel model)
        {
            return _res.Delete(model);
        }
    }
}
