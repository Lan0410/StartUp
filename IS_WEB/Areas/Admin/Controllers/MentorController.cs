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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using RestSharp;
using System.Net.Http;
using System.IO;

namespace IS_WEB.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MentorController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public MentorController(IWebHostEnvironment _host)
        {
            _hostEnvironment = _host;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetData(RequestDataModel request)
        {
            var mentorModelParamater = new MenTorModelParameter();
            var settings = new JsonSerializerSettings();
            var searchObject = new MentorModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<MentorModel>(request.model, settings);
            var page = new PageParameter
            {
                PageIndex = request.start,
                PageSize = request.length
            };

            mentorModelParamater.Page = page;
            mentorModelParamater.Data = searchObject;
            var hostAPI = "https://localhost:44322";
            var data = await ApiProvider.PostAsync<MenTorReturnModel>(hostAPI, ApiConstant.GetAllMentor, mentorModelParamater);
            return Json(data);
        }

        public async Task<IActionResult> CreateOrUpdate(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new MentorModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            string fileName = null;
            string orgFileName = ContentDispositionHeaderValue.Parse(request.files.ContentDisposition).FileName.Value;
            fileName = DateTime.Now.ToFileTime() + Path.GetExtension(orgFileName);


            searchObject = JsonConvert.DeserializeObject<MentorModel>(request.model, settings);

            var mentor = new MentorModel();
            mentor = searchObject;
            mentor.Avatar = fileName;
            mentor.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.CreateMentor, mentor);
            if (rs == Constant.ReturnExcuteFunction.Success)
            {
                string fullPath = GetFullPathOfFile(fileName);

                // Create the directory.
                Directory.CreateDirectory(Directory.GetParent(fullPath).FullName);

                // Save the file to the server.
                await using FileStream output = System.IO.File.Create(fullPath);
                await request.files.CopyToAsync(output);
                return Json(new { messege = "Thành công !" });
            }
            else
            {
                return Json(new { messege = "Thất bại!" });
            }
        }
        private string GetFullPathOfFile(string fileName)
        {
            return $"{_hostEnvironment.WebRootPath}\\img\\avatars\\{fileName}";
        }
        public async Task<IActionResult> GetByID(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new MentorModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<MentorModel>(request.model, settings);

            var mentor = new MentorModel();
            mentor = searchObject;
            mentor.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<MentorModel>(hostAPI, ApiConstant.GetMentorId, mentor);
            return Json(rs);
        }

        public async Task<IActionResult> Delete(RequestDataModel request)
        {
            var settings = new JsonSerializerSettings();
            var searchObject = new MentorModel
            {
            };
            settings.DateFormatString = "dd/MM/yyyy";
            searchObject = JsonConvert.DeserializeObject<MentorModel>(request.model, settings);

            var mentor = new MentorModel();
            mentor = searchObject;
            mentor.LastModifyDate = DateTime.Now;
            var hostAPI = "https://localhost:44322";
            var rs = await ApiProvider.PostAsync<int>(hostAPI, ApiConstant.DeleteMentor, mentor);
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
