using RabbitWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RabbitWeb.Controllers
{
    public class ClientChartController : Controller
    {
        RabbitMQDBEntities3 db2 = new RabbitMQDBEntities3();


        [Route("ClientChart/ClientChartActRes")]// GET: ClientChart
        public ActionResult ClientChartActRes()
        {
            return View();
        }
        public JsonResult GetClientList(string GuidInCome)
        {
            var model = db2.Table1.ToList();
            List<int> clientNos = new List<int>();
           
            return Json(clientNos, JsonRequestBehavior.AllowGet);
        }
    }
}