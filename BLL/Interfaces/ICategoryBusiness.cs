using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface ICategoryBusiness
    {
        CategoryReturnModel GetDataAll(CategoryModelParameter model);
        CategoryModel GetDataByID(int id);
        int CreateOrUpdate(CategoryModel model);
        int Delete(CategoryModel model);
    }
}
