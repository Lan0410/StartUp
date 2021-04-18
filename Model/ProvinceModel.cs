using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class ProvinceModel
    {
        public int Id { get; set; }
        public string Province_Code { get; set; }
        public string Province_Name { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class ProvinceModelParameter
    {
        public ProvinceModel Data { get; set; }
        public PageParameter Page { get; set; }
    }
    public class ProvinceReturnModel
    {
        public List<ProvinceModel> Data { get; set; }
        public int TotalRow { get; set; }
    }
}
