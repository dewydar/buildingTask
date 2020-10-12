using buildingTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buildingTask.Controllers
{
    public class buildingController : Controller
    {
        Bulding_TaskEntities db = new Bulding_TaskEntities();
        // GET: building
        public ActionResult Index()
        {
            return View(db.buildingInfoDatas.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.zones = db.zoneDatas.ToList();
            ViewBag.buildingType= db.buildingTypeDatas.ToList();
            ViewBag.constartion = db.constructionDatas.ToList();
            ViewBag.buildingUses = db.buildingUsesDatas.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult create(buildingInfoData data,HttpPostedFileBase buildingImage)
        {
            string imgname = System.IO.Path.GetFileName(buildingImage.FileName);
            string imgPath = Server.MapPath("~/img/"+imgname);
            data.buildingImage = imgPath;
            db.buildingInfoDatas.Add(data);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}