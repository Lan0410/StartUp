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
        int CreateOrUpdate(MentorModel model);
        int Delete(MentorModel model);
    }
}
