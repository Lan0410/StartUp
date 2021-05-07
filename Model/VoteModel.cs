using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class VoteModel
    {
        public int Id { get; set; }
        public int Id_Users { get; set; }
        public int Id_StartUp { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class VoteModelParameter
    {
        public VoteModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class VoteReturnModel
    {
        public List<VoteModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
