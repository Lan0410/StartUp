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
    public class MentorController : ControllerBase
    {
        IMentorBusiness _bus;
        public MentorController(IMentorBusiness bus)
        {
            _bus = bus;
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<MentorModel> GetDatabAll()
        {
            return _bus.GetDataAll();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public MentorModel GetDataByID(int id)
        {
            return _bus.GetDataByID(id);
        }

        [Route("create-mentor")]
        [HttpPost]
        public MentorModel Create([FromBody] MentorModel model)
        {
            _bus.Create(model);
            return model;
        }
        [Route("update-mentor")]
        [HttpPut]
        public MentorModel Update([FromBody] MentorModel model)
        {
            _bus.Update(model);
            return model;
        }
        [Route("delete-mentor")]
        [HttpDelete]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = Convert.ToString(formData["id"]); }
            _bus.Delete(id);
            return Ok();
        }
    }
}
