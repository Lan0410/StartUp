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
    public class ProvinceController : ControllerBase
    {
        IProvinceBusiness _bus;
        public ProvinceController(IProvinceBusiness bus)
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public ProvinceReturnModel GetAllData([FromBody] ProvinceModelParameter model)
        {
            return _bus.GetAllData(model);
        }

        [Route("get-by-id")]
        [HttpPost]
        public ProvinceModel GetDataID([FromBody] ProvinceModel model)
        {
            return _bus.GetDataID(model.Id);
        }

        [Route("create")]
        [HttpPost]
        public int CreateOrUpdate([FromBody] ProvinceModel model)
        {
            return _bus.CreateOrUpdate(model);
        }

        [Route("delete")]
        [HttpPost]
        public int Delete([FromBody] ProvinceModel model)
        {
            return _bus.Delete(model);
        }

    }
}
