using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class GroupPageModel
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
    public class GroupPageModelParameter
    {
        public GroupPageModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class GroupPageReturnModel
    {
        public List<GroupPageModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
