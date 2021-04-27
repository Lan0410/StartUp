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

        public CategoryModel GetDataByID(int id)
        {
            return _res.GetDataByID(id);
        }
        public int CreateOrUpdate(CategoryModel model)
        {
            return _res.CreateOrUpdate(model);
        }

        public int Delete(CategoryModel model)
        {
            return _res.Delete(model);
        }
    }
}
