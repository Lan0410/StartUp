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
    public class ProvinceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetData(RequestDataModel request)
        {
            var provinceModelParamater = new ProvinceModelParameter();
            var settings = new JsonSerializerSettings();
            var searchObject = new ProvinceModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<ProvinceModel>(request.model, settings);
            var page = new PageParameter
            {
                PageIndex = request.start,
                PageSize = request.length
            };

            provinceModelParamater.Page = page;
            provinceModelParamater.Data = searchObject;
            var hostAPI = "https://localhost:44322";
            var data = await ApiProvider.PostAsync<ProvinceReturnModel>(hostAPI, ApiConstant.GetAllProvince, provinceModelParamater);
            return Json(data);
        }

        public async Task<IActionResult> CreateOrUpdate(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new ProvinceModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<ProvinceModel>(request.model, settings);

            var province = new ProvinceModel();
            province = searchObject;
            province.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.CreateProvince, province);
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
            var searchObject = new ProvinceModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<ProvinceModel>(request.model, settings);

            var province = new ProvinceModel();
            province = searchObject;
            province.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<ProvinceModel>(hostAPI, ApiConstant.GetProvinceId, province);
            return Json(rs);
        }

        public async Task<IActionResult> Delete(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new ProvinceModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<ProvinceModel>(request.model, settings);

            var province = new ProvinceModel();
            province = searchObject;
            province.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.DeleteProvince, province);
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
