using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Comment_Code { get; set; }
        public int Id_News { get; set; }
        public int Id_Users { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifyDate { get; set; }
    }

    public class CommentModelParameter
    {
        public CommentModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class CommentReturnModel
    {
        public List<CommentModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
