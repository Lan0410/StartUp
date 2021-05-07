using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class ActionModel
    {
        public int Id { get; set; }
        public string Action_Code { get; set; }
        public string Action_Name { get; set; }
        public int Id_Page { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class ActionModelParameter
    {
        public ActionModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class ActionReturnModel
    {
        public List<ActionModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
