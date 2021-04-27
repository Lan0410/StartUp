using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface IGenreBusiness
    {
        GenreReturnModel GetDataAll(GenreModelParameter model);
        GenreModel GetDataByID(int id);
        int CreateOrUpdate(GenreModel model);
        int Delete(GenreModel model);
    }
}
