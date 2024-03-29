﻿using System;
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
        public MenTorReturnModel GetDataAll(MenTorModelParameter model)
        {
            return _res.GetDataAll(model);
        }
        public MentorModel GetDataByID(int id)
        {
            return _res.GetDataByID(id);
        }
        public int CreateOrUpdate(MentorModel model)
        {
            return _res.CreateOrUpdate(model);
        }
        
        public int Delete(MentorModel model)
        {
            return _res.Delete(model);
        }
    }
}
