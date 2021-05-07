using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
   public class LikeModel
    {
        public int Id { get; set; }
        public string Like_Code { get; set; }
        public int Id_Users { get; set; }
        public int Type { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }

    public class LikeModelParameter
    {
        public LikeModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class LikeReturnModel
    {
        public List<LikeModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
