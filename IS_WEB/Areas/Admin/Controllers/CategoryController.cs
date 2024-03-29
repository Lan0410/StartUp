﻿using System;
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
using System.Net.Http;

namespace IS_WEB.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetData(RequestDataModel request)
        {
            var categoryModelParamater = new CategoryModelParameter();
            var settings = new JsonSerializerSettings();
            var searchObject = new CategoryModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<CategoryModel>(request.model, settings);
            var page = new PageParameter
            {
                PageIndex = request.start,
                PageSize = request.length
            };

            categoryModelParamater.Page = page;
            categoryModelParamater.Data = searchObject;
            var hostAPI = "https://localhost:44322";
            var data = await ApiProvider.PostAsync<CategoryReturnModel>(hostAPI, ApiConstant.GetAllCategory, categoryModelParamater);
            return Json(data);
        }

        public async Task<IActionResult> CreateOrUpdate(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new CategoryModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<CategoryModel>(request.model, settings);

            var category = new CategoryModel();
            category = searchObject;
            category.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.CreateCategory, category);
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
            var searchObject = new CategoryModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<CategoryModel>(request.model, settings);

            var category = new CategoryModel();
            category = searchObject;
            category.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<CategoryModel>(hostAPI, ApiConstant.GetCategoryId, category);
            return Json(rs);
        }

        public async Task<IActionResult> Delete(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new CategoryModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<CategoryModel>(request.model, settings);

            var category = new CategoryModel();
            category = searchObject;
            category.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.DeleteCategory, category);
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
