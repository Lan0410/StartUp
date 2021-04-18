using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface IMentorBusiness
    {
        List<MentorModel> GetDataAll();
        MentorModel GetDataByID(int id);
        bool Create(MentorModel model);
        bool Update(MentorModel model);
        bool Delete(string id);
    }
}
