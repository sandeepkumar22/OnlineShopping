﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.web.Controllers
{
    public class SharedController : Controller
    {
        [HttpPost]
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                //var fileName =file.FileName;
                var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                file.SaveAs(path);
                //result.Data = new { Succes = true, ImageURL = path};
                result.Data = new { Success = true, ImageURL = string.Format("/Content/images/{0}",fileName) };
                //var newImage = new Image()
                //{ new= fileName };
                //if (ImageService.instance.SaveNewImage(newImage))
                //{
                //    result.Data = new { Succes = true, Image = fileName, File = newImage.ID, ImageURL = string.Format("{0}{1}", Variables.ImageFolderPath, fileName) };
                //}
                //else
                //{
                //    result.Data = new { success = false, Message = new HttpStatusCodeResult(500) };
                //}
            }
            catch(Exception ex)
            {
                result.Data = new { Succes = false, Message = ex.Message };
            }
            return result;
        }

        [HttpPost]
        public void Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                file.SaveAs(path);
            }

        }
    }
}