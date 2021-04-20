using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
   public class MentorModel
    {
        public int Id { get; set; }
        public string Mentor_Code { get; set; }
        public string Mentor_Name { get; set; }
        public string Position { get; set; }
        public string Introduce { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string LastModifyBy { get; set; }
    }
    public class MenTorModelParameter
    {
        public MentorModel Data { get; set; }
        public PageParameter Page { get; set; }
    }
    public class MenTorReturnModel
    {
        public List<MentorModel> Data { get; set; }
        public int TotalRow { get; set; }
    }
}
