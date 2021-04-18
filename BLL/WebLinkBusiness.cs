using System;
using DAL;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class WebLinkBusiness:IWebLinkBusiness
    {
        IWebLinkRepository _res;
        public WebLinkBusiness(IWebLinkRepository res)
        {
            _res = res;
        }
        public WebLinkReturnModel GetDataAll(WebLinkModelParameter model)
        {
            return _res.GetDataAll(model);
        }
        public WebLinkModel GetDataID(int id)
        {
            return _res.GetDataID(id);
        }
        public int CreateOrUpdate(WebLinkModel model)
        {
            return _res.CreateOrUpdate(model);
        }

        public int Delete(WebLinkModel model)
        {
            return _res.Delete(model);
        }
    }
}
