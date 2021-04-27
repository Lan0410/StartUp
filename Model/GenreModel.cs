using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Genre_Code { get; set; }
        public string Genre_Name { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifyBy { get; set; }
        public DateTime LastModifyDate { get; set; }

    }
    public class GenreModelParameter
    {
        public GenreModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class GenreReturnModel
    {
        public List<GenreModel> Data { get; set; }
        public int TotalRow { get; set; }
    }
}
