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
    public class CategoryController : ControllerBase
    {
        ICategoryBusiness _bus;
        public CategoryController(ICategoryBusiness bus)
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpPost]
        public CategoryReturnModel GetDataAll(CategoryModelParameter model)
        {
            return _bus.GetDataAll(model);
        }
    }
}
