using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
   public class NewModel
    {
        public int Id { get; set; }
        public string News_Code { get; set; }
        public string Title { get; set; }
        public string Recap { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public int Id_Genre { get; set; }
        public string Tag { get; set; }
        public int Number_Audience { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class NewModelParameter
    {
        public NewModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class NewReturnModel
    {
        public List<NewModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
