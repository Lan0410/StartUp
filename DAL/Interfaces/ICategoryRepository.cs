using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public interface ICategoryRepository
    {
        CategoryReturnModel GetDataAll(CategoryModelParameter model);
    }
}
