using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class SavedNewModel
    {
        public int Id { get; set; }
        public int Id_News { get; set; }
        public int Id_Users { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class SavedNewModelParameter
    {
        public SavedNewModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class SavedNewsReturnModel
    {
        public List<SavedNewModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
