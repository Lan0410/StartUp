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
        bool Create(MentorModel model);
        bool Update(MentorModel model);
        bool Delete(string id);
    }
}
