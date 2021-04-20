using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public interface IMentorRepository
    {
        MenTorReturnModel GetDataAll(MenTorModelParameter model);
        MentorModel GetDataByID(int id);
        bool Create(MentorModel model);
        bool Update(MentorModel model);
        bool Delete(string id);
    }
}
