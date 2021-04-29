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
    public class GroupPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        string url = "https://localhost:44322";
        public async Task<IActionResult> GetData(RequestDataModel request)
        {
            var grouppageModelParamater = new GroupPageModelParameter();
            var settings = new JsonSerializerSettings();
            var searchObject = new GroupPageModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<GroupPageModel>(request.model, settings);
            var page = new PageParameter
            {
                PageIndex = request.start,
                PageSize = request.length
            };

            grouppageModelParamater.Page = page;
            grouppageModelParamater.Data = searchObject;
            var hostAPI = url;
            var data = await ApiProvider.PostAsync<GroupPageReturnModel>(hostAPI, ApiConstant.GetAllGroupPage, grouppageModelParamater);
            return Json(data);
        }

        public async Task<IActionResult> CreateOrUpdate(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new GroupPageModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<GroupPageModel>(request.model, settings);

            var grouppage = new GroupPageModel();
            grouppage = searchObject;
            grouppage.LastModifyDate = DateTime.Now;
            var hostAPI = url; ;
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.CreateGroupPage, grouppage);
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
            var searchObject = new GroupPageModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<GroupPageModel>(request.model, settings);

            var grouppage = new GroupPageModel();
            grouppage = searchObject;
            grouppage.LastModifyDate = DateTime.Now;
            var hostAPI = url;
            var rs = await ApiProvider.PostAsync<GroupPageModel>(hostAPI, ApiConstant.GetGroupPageId, grouppage);
            return Json(rs);
        }

        public async Task<IActionResult> Delete(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new GroupPageModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<GroupPageModel>(request.model, settings);

            var grouppage = new GroupPageModel();
            grouppage = searchObject;
            grouppage.LastModifyDate = DateTime.Now;
            var hostAPI = url;
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.DeleteGroupPage, grouppage);
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
