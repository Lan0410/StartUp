using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class PageGroupModel
    {
        public int Id { get; set; }
        public string GroupPage_Code { get; set; }
        public string GroupPage_Name { get; set; }
        public int Is_public { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }

    public class PageGroupModelParameter
    {
        public PageGroupModel Data { get; set; }
        public PageParameter Page { get; set; }
    }
    public class PageGroupReturnModel
    {
        public List<PageGroupModel> Data { get; set; }
        public int TotalRow { get; set; }
    }
}
