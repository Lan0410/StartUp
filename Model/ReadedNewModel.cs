using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class ReadedNewModel
    {
        public int Id { get; set; }
        public int Id_News { get; set; }
        public int Id_Users { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }

    public class ReadedNewModelParameter
    {
        public ReadedNewModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class ReadedNewReturnModel
    {
        public List<ReadedNewModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
