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
    public class PageController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var grouppageModelParamater = new GroupPageModelParameter();
            GroupPageReturnModel data = await ApiProvider.PostAsync<GroupPageReturnModel>(url, ApiConstant.GetDataAllGroupPage, grouppageModelParamater);
            ViewData["GroupPage"] = data.Data;
            return View();
        }
        string url = "https://localhost:44322";
        public async Task<IActionResult> GetData(RequestDataModel request)
        {
            var pageModelParamater = new PageModelParameter();
            var settings = new JsonSerializerSettings();
            var searchObject = new PageModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<PageModel>(request.model, settings);
            var page = new PageParameter
            {
                PageIndex = request.start,
                PageSize = request.length
            };

            pageModelParamater.Page = page;
            pageModelParamater.Data = searchObject;
            var hostAPI = url;
            var data = await ApiProvider.PostAsync<PageReturnModel>(hostAPI, ApiConstant.GetAllPage, pageModelParamater);
            return Json(data);
        }


        public async Task<IActionResult> CreateOrUpdate(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new PageModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<PageModel>(request.model, settings);

            var page = new PageModel();
            page = searchObject;
            page.LastModifyDate = DateTime.Now;
            var hostAPI = url; ;
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.CreatePage, page);
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
            var searchObject = new PageModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<PageModel>(request.model, settings);

            var page = new PageModel();
            page = searchObject;
            page.LastModifyDate = DateTime.Now;
            var hostAPI = url;
            var rs = await ApiProvider.PostAsync<PageModel>(hostAPI, ApiConstant.GetPageId, page);
            return Json(rs);
        }

        public async Task<IActionResult> Delete(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new PageModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<PageModel>(request.model, settings);

            var page = new PageModel();
            page = searchObject;
            page.LastModifyDate = DateTime.Now;
            var hostAPI = url;
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.DeletePage, page);
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
