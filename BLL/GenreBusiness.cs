using System;
using DAL;
using Model;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class GenreBusiness:IGenreBusiness
    {
        IGenreRepository _res;
        public GenreBusiness(IGenreRepository res)
        {
            _res = res;
        }
        public GenreReturnModel GetDataAll(GenreModelParameter model)
        {
            return _res.GetDataAll(model);
        }
        public GenreModel GetDataByID(int id)
        {
            return _res.GetDataByID(id);
        }
        public int CreateOrUpdate(GenreModel model)
        {
            return _res.CreateOrUpdate(model);
        }

        public int Delete(GenreModel model)
        {
            return _res.Delete(model);
        }
    }
}
