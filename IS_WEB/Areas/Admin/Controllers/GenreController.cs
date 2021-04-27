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
using System.Net.Http;
namespace IS_WEB.Areas.Admin.Controllers
{
    [Area("admin")]
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetData(RequestDataModel request)
        {
            var genreModelParamater = new GenreModelParameter();
            var settings = new JsonSerializerSettings();
            var searchObject = new GenreModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<GenreModel>(request.model, settings);
            var page = new PageParameter
            {
                PageIndex = request.start,
                PageSize = request.length
            };

            genreModelParamater.Page = page;
            genreModelParamater.Data = searchObject;
            var hostAPI = "https://localhost:44322";
            var data = await ApiProvider.PostAsync<GenreReturnModel>(hostAPI, ApiConstant.GetAllGenre, genreModelParamater);
            return Json(data);
        }

        public async Task<IActionResult> CreateOrUpdate(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new GenreModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<GenreModel>(request.model, settings);

            var genre = new GenreModel();
            genre = searchObject;
            genre.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.CreateGenre, genre);
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
            var searchObject = new GenreModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<GenreModel>(request.model, settings);

            var genre = new GenreModel();
            genre = searchObject;
            genre.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<GenreModel>(hostAPI, ApiConstant.GetGenreId, genre);
            return Json(rs);
        }

        public async Task<IActionResult> Delete(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new GenreModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<GenreModel>(request.model, settings);

            var genre = new GenreModel();
            genre = searchObject;
            genre.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.DeleteGenre, genre);
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
