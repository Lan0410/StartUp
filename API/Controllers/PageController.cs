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
    public class PageController : ControllerBase
    {
        IPageBusiness _bus;
        public PageController(IPageBusiness bus)
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public PageReturnModel GetDataAll(PageModelParameter model)
        {
            return _bus.GetDataAll(model);
        }
        [Route("get-by-id")]
        [HttpPost]
        public PageModel GetDataID([FromBody] PageModel model)
        {
            return _bus.GetDataID(model.Id);
        }

        [Route("create")]
        [HttpPost]
        public int CreateOrUpdate([FromBody] PageModel model)
        {
            return _bus.CreateOrUpdate(model);
        }

        [Route("delete")]
        [HttpPost]
        public int Delete([FromBody] PageModel model)
        {
            return _bus.Delete(model);
        }
    }
}
