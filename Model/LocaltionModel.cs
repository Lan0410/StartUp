using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
   public class LocaltionModel
    {
        public int Id { get; set; }
        public string Localtion_Code { get; set; }
        public string Localtion_Name { get; set; }
        public float Point_X { get; set; }
        public float Point_Y { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }

    }

    public class LocaltionModelParameter
    {
        public LocaltionModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class LocaltionReturnModel
    {
        public List<LocaltionModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
