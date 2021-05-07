using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class AdveriseModel
    {
        public int Id { get; set; }
        public string Adverise_Code { get; set; }
        public string Adverise_Name { get; set; }
        public int Id_Page { get; set; }
        public int Id_location { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public int Number_Click { get; set; }
        public string Code_Html { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class AdveriseModelParameter
    {
        public AdveriseModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class AdveriseReturnModel
    {
        public List<AdveriseModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
