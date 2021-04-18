using System.Collections.Generic;
using ISCommon.Model;
using System;

namespace IS.Model.Views
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TagUnsign { get; set; }
        public string AliasUrl { get; set; }
        public string Target { get; set; }
        public int SortOrder { get; set; }
        public int ParentId { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public int Level { get; set; }
        public string Icon { get; set; }
        public string Action { get; set; }
        public int Type { get; set; }
        public bool IsReport { get; set; }
        public int ReportType { get; set; }
        public int Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
        public string Key { get; set; }
        public string ParentName { get; set; }
        public FillterParameter Filter { get; set; }
    }
  
    public class MenuReturnModel : ErrorMessage
    {
        public List<MenuModel> Data { get; set; }
        public int TotalRecord { get; set; }
    }
    public class MenuModelParameter
    {
        public MenuModel Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
