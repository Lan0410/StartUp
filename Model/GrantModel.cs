using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class GrantModel
    {
        public int Id { get; set; }
        public int Id_Action { get; set; }
        public int Id_Role { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }

    public class GrantModelParameter
    {
        public GrantModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class GrantReturnModel
    {
        public List<GrantModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
