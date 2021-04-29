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
    public class PageGroupController : ControllerBase
    {
        IPageGroupBusiness _bus;
        public PageGroupController(IPageGroupBusiness bus)
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public PageGroupReturnModel GetAllData([FromBody] PageGroupModelParameter model)
        {
            return _bus.GetAllData(model);
        }

        [Route("get-by-id")]
        [HttpPost]
        public PageGroupModel GetDataID([FromBody] PageGroupModel model)
        {
            return _bus.GetDataID(model.Id);
        }

        [Route("create")]
        [HttpPost]
        public int CreateOrUpdate([FromBody] PageGroupModel model)
        {
            return _bus.CreateOrUpdate(model);
        }

        [Route("delete")]
        [HttpPost]
        public int Delete([FromBody] PageGroupModel model)
        {
            return _bus.Delete(model);
        }
    }
}
