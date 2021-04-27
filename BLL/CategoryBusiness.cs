using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public partial class CategoryBusiness:ICategoryBusiness
    {
        ICategoryRepository _res;
        public CategoryBusiness(ICategoryRepository res)
        {
            _res = res;
        }
        public CategoryReturnModel GetDataAll(CategoryModelParameter model)
        {
            return _res.GetDataAll(model);
        }
    }
}
