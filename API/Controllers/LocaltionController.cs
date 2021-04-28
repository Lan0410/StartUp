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
    public class LocaltionController : ControllerBase
    {
        ILocaltionBusiness _bus;
        public LocaltionController(ILocaltionBusiness bus)
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public LocaltionReturnModel GetDataAll(LocaltionModelParameter model)
        {
            return _bus.GetDataAll(model);
        }

        [Route("get-by-id")]
        [HttpPost]
        public LocaltionModel GetDataID([FromBody] LocaltionModel model)
        {
            return _bus.GetDataByID(model.Id);
        }

        [Route("create")]
        [HttpPost]
        public int CreateOrUpdate([FromBody] LocaltionModel model)
        {
            return _bus.CreateOrUpdate(model);
        }

        [Route("delete")]
        [HttpPost]
        public int Delete([FromBody] LocaltionModel model)
        {
            return _bus.Delete(model);
        }
    }
}
