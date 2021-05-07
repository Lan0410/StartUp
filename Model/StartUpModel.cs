using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;


namespace Model
{
    public class StartUpModel
    {
        public int Id { get; set; }
        public string StartUp_Code { get; set; }
        public string StartUp_Name { get; set; }
        public int Id_Users { get; set; }
        public int Id_Province { get; set; }
        public string Address { get; set; }
        public string Size { get; set; }
        public string Website { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class StartUpModelParameter
    {
        public StartUpModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class StartUpReturnModel
    {
        public List<StartUpModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
