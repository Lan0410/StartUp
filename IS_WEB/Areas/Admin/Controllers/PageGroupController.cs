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
    public class PageGroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        string url = "https://localhost:44322";
        public async Task<IActionResult> GetData(RequestDataModel request)
        {
            var pageGroupModelParamater = new PageGroupModelParameter();
            var settings = new JsonSerializerSettings();
            var searchObject = new PageGroupModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<PageGroupModel>(request.model, settings);
            var page = new PageParameter
            {
                PageIndex = request.start,
                PageSize = request.length
            };

            pageGroupModelParamater.Page = page;
            pageGroupModelParamater.Data = searchObject;
            var hostAPI = url;
            var data = await ApiProvider.PostAsync<PageGroupReturnModel>(hostAPI, ApiConstant.GetAllPageGroup, pageGroupModelParamater);
            return Json(data);
        }

        public async Task<IActionResult> CreateOrUpdate(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new PageGroupModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<PageGroupModel>(request.model, settings);

            var pagegroup = new PageGroupModel();
            pagegroup = searchObject;
            pagegroup.LastModifyDate = DateTime.Now;
            var hostAPI = url; ;
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.CreatePageGroup, pagegroup);
            if (rs == Constant.ReturnExcuteFunction.Success)
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
            var searchObject = new PageGroupModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<PageGroupModel>(request.model, settings);

            var pagegroup = new PageGroupModel();
            pagegroup = searchObject;
            pagegroup.LastModifyDate = DateTime.Now;
            var hostAPI = url;
            var rs = await ApiProvider.PostAsync<PageGroupModel>(hostAPI, ApiConstant.GetPageGroupId, pagegroup);
            return Json(rs);
        }

        public async Task<IActionResult> Delete(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new PageGroupModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<PageGroupModel>(request.model, settings);

            var pagegroup = new PageGroupModel();
            pagegroup = searchObject;
            pagegroup.LastModifyDate = DateTime.Now;
            var hostAPI = url;
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.DeletePageGroup, pagegroup);
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
