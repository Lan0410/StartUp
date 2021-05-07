using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class RolesModel
    {
        public int Id { get; set; }
        public string Role_Code { get; set; }
        public string Role_Name { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class RolesModelParameter
    {
        public RolesModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class RolesReturnModel
    {
        public List<RolesModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
