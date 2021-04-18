using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebLinkController : ControllerBase
    {
        IWebLinkBusiness _bus;
        public WebLinkController(IWebLinkBusiness bus)
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public WebLinkReturnModel GetDataAll([FromBody] WebLinkModelParameter model)
        {
            return _bus.GetDataAll(model);
        }

        [Route("get-by-id")]
        [HttpPost]
        public WebLinkModel GetDataID([FromBody] WebLinkModel model)
        {
            return _bus.GetDataID(model.Id);
        }
        
        [Route("create-weblink")]
        [HttpPost]
        public int CreateOrUpdate([FromBody] WebLinkModel model)
        {
             return _bus.CreateOrUpdate(model);
        }

        [Route("delete-weblink")]
        [HttpPost]
        public int Delete([FromBody] WebLinkModel model)
        {
            return _bus.Delete(model);
        }
    }
}
