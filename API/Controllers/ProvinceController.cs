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
        [HttpGet]
        public IEnumerable<ProvinceModel> GetAllData()
        {
            return _bus.GetAllData();
        }

    }
}
