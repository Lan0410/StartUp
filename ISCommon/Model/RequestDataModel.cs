using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace ISCommon.Model
{

    public class RequestDataModel
    { 
        public int start { get; set; }

        public int length { get; set; }

        public string model { get; set; }
        public IFormFile files { get; set; } 

    }
    
    public class FillterParameter
    {        
        public List<FillterModel> filters { get; set; }
    }
    public class FillterModel
    {
        public string field { get; set; }
        public string _operator { get; set; }
        public object value { get; set; }
        public string logic { get; set; }
    }
}
