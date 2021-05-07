using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class PageModel
    {
        public int Id { get; set; }
        public string Page_Code { get; set; }
        public string Page_Name { get; set; }
        public int Id_Group_Page { get; set; }
        public string Group_Page_Name { get; set; }
        public int Is_public { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class PageModelParameter
    {
        public PageModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class PageReturnModel
    {
        public List<PageModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
