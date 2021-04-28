using System;
using ISCommon.Model;
using ISWeb;
using Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ISCommon.Constant;


namespace IS_WEB.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LocaltionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        string url = "https://localhost:44322";
        public async Task<IActionResult> GetData(RequestDataModel request)
        {
            var localtionModelParamater = new LocaltionModelParameter();
            var settings = new JsonSerializerSettings();
            var searchObject = new LocaltionModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<LocaltionModel>(request.model, settings);
            var page = new PageParameter
            {
                PageIndex = request.start,
                PageSize = request.length
            };

            localtionModelParamater.Page = page;
            localtionModelParamater.Data = searchObject;
            var hostAPI = url;
            var data = await ApiProvider.PostAsync<LocaltionReturnModel>(hostAPI, ApiConstant.GetAllLocaltion, localtionModelParamater);
            return Json(data);
        }

        public async Task<IActionResult> CreateOrUpdate(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new LocaltionModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<LocaltionModel>(request.model, settings);

            var localtion = new LocaltionModel();
            localtion = searchObject;
            localtion.LastModifyDate = DateTime.Now;
            var hostAPI = url;
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.CreateLocaltion, localtion);
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
            var searchObject = new LocaltionModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<LocaltionModel>(request.model, settings);

            var localtion = new LocaltionModel();
            localtion = searchObject;
            localtion.LastModifyDate = DateTime.Now;
            var hostAPI = url;
            var rs = await ApiProvider.PostAsync<LocaltionModel>(hostAPI, ApiConstant.GetLocaltionId, localtion);
            return Json(rs);
        }

        public async Task<IActionResult> Delete(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new LocaltionModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<LocaltionModel>(request.model, settings);

            var localtion = new LocaltionModel();
            localtion = searchObject;
            localtion.LastModifyDate = DateTime.Now;
            var hostAPI = url;
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.DeleteLocaltion, localtion);
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
