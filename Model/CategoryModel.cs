using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Category_Code { get; set; }
        public string Category_Name { get; set; }
        public int Parents { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }

    public class CategoryModelParameter
    {
        public CategoryModel Data { get; set; }
        public PageParameter Page { get; set; }
    }
    public class CategoryReturnModel
    {
        public List<CategoryModel> Data { get; set; }
        public int TotalRow { get; set; }
    }
}
