using IS.Model.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Model
{
   public class ObjectParameterModel
    {
        public object Id { get; set; }
        public string Key { get; set; }
        public int Active { get; set; }
        public int UserType { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
    }
}
