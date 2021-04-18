using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IWebLinkBusiness
    {
        WebLinkReturnModel GetDataAll(WebLinkModelParameter model);
        WebLinkModel GetDataID(int id);
        int CreateOrUpdate(WebLinkModel model);
        int Delete(WebLinkModel model);
    }
}
