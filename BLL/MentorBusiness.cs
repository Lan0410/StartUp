using System;
using DAL;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class MentorBusiness:IMentorBusiness
    {
        IMentorRepository _res;
        public MentorBusiness(IMentorRepository res)
        {
            _res = res;
        }
        public List<MentorModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public MentorModel GetDataByID(int id)
        {
            return _res.GetDataByID(id);
        }
        public bool Create(MentorModel model)
        {
            return _res.Create(model);
        }
        public bool Update(MentorModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
    }
}
