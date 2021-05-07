using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class DomainModel
    {
        public int Id { get; set; }
        public string Domain_Code { get; set; }
        public string Domain_Name { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }

    public class DomainModelParameter
    {
        public DomainModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class DomainReturnModel
    {
        public List<DomainModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
