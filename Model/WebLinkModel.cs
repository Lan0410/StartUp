using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class WebLinkModel
    {
        public int Id { get; set; }
        public string Link_Code { get; set; }
        public string Link_Name { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class WebLinkModelParameter
    {
        public WebLinkModel Data { get; set; }
        public PageParameter Page { get; set; }
    }
    public class WebLinkReturnModel
    {
        public List<WebLinkModel> Data { get; set; }
        public int TotalRow { get; set; }
    }
}
