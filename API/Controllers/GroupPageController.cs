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
    public class GroupPageController : ControllerBase
    {
        IGroupPageBusiness _bus;
        public GroupPageController(IGroupPageBusiness bus)
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public GroupPageReturnModel GetDataAll(GroupPageModelParameter model)
        {
            return _bus.GetDataAll(model);
        }

        [Route("get-by-id")]
        [HttpPost]
        public GroupPageModel GetDataID([FromBody] GroupPageModel model)
        {
            return _bus.GetDataID(model.Id);
        }

        [Route("create")]
        [HttpPost]
        public int CreateOrUpdate([FromBody] GroupPageModel model)
        {
            return _bus.CreateOrUpdate(model);
        }

        [Route("delete")]
        [HttpPost]
        public int Delete([FromBody] GroupPageModel model)
        {
            return _bus.Delete(model);
        }
    }
}
