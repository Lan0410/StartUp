using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface IMentorBusiness
    {
        MenTorReturnModel GetDataAll(MenTorModelParameter model);
        MentorModel GetDataByID(int id);
        int CreateOrUpdate(MentorModel model);
        int Delete(MentorModel model);
    }
}
