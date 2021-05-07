using System;
using System.Collections.Generic;
using System.Text;
using ISCommon.Model;

namespace Model
{
    public class QuestionAndAnswerModel
    {
        public int Id { get; set; }
        public string QandA_Code { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
    public class QuestionAndAnswerModelParameter
    {
        public QuestionAndAnswerModel Data { get; set; }
        public PageParameter Page { get; set; }
    }

    public class QuestionAndAnswerReturnModel
    {
        public List<QuestionAndAnswerModel> Data { get; set; }
        public int TotalRow { get; set; }

    }
}
