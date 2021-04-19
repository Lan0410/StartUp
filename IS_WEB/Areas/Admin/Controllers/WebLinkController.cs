using System;
using System.Collections.Generic;
using System.Linq;
using ISCommon.Model;
using ISWeb;
using Model;
using ISWeb.Extensions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using ISCommon.Constant;
using RestSharp.Deserializers;
using RestSharp;
namespace IS_WEB.Areas.Admin.Controllers
{
    [Area("admin")]
    public class WebLinkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetData(RequestDataModel request)
        {
            var webLinkModelParamater = new WebLinkModelParameter();
            var settings = new JsonSerializerSettings();
            var searchObject = new WebLinkModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<WebLinkModel>(request.model, settings);
            var page = new PageParameter
            {
                PageIndex = request.start,
                PageSize = request.length
            };

            webLinkModelParamater.Page = page;
            webLinkModelParamater.Data = searchObject;
            var hostAPI = "https://localhost:44322";
            var data = await ApiProvider.PostAsync<WebLinkReturnModel>(hostAPI, ApiConstant.GetAllWebLink, webLinkModelParamater);
            return Json(data);
        }

        public async Task<IActionResult> CreateOrUpdate(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new WebLinkModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<WebLinkModel>(request.model, settings);
            
            var weblink = new WebLinkModel();
            weblink = searchObject;
            weblink.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.CreateWebLink, weblink);
            if(rs == Constant.ReturnExcuteFunction.Success)
            {
                return Json(new { messege = "Thành công !" });
            }
            else
            {
                return Json(new { messege = "Thất bại!" });
            }
        }
        public async Task<IActionResult> GetByID(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new WebLinkModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<WebLinkModel>(request.model, settings);

            var weblink = new WebLinkModel();
            weblink = searchObject;
            weblink.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<WebLinkModel>(hostAPI, ApiConstant.GetWebLinkId, weblink);
            return Json(rs);
        }

        public async Task<IActionResult> Delete(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new WebLinkModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<WebLinkModel>(request.model, settings);

            var weblink = new WebLinkModel();
            weblink = searchObject;
            weblink.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.DeleteWebLink, weblink);
            if (rs == Constant.ReturnExcuteFunction.Success)
            {
                return Json(new { messege = "Thành công !" });
            }
            else
            {
                return Json(new { messege = "Thất bại!" });
            }
        }
    }
}
