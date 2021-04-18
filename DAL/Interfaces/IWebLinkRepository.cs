using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IWebLinkRepository
    {
        WebLinkReturnModel GetDataAll(WebLinkModelParameter model);
        WebLinkModel GetDataID(int id);
        int CreateOrUpdate(WebLinkModel model);
        int Delete(WebLinkModel model);
    }
}
