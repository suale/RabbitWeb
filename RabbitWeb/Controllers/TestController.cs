using RabbitWeb.Models;

using RabbitWeb.Models.Entities2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RabbitWeb.Controllers
{
    public class TestController : Controller
    {
        RabbitMQDBEntities2 db = new RabbitMQDBEntities2();
        
       
        public ActionResult TestActRes()
        {
          
            

              return View();
        }

        public JsonResult GetClientList()
        {
           
            List<Table2> gidecek = new List<Table2>();
            //List<ClientDateStr> gidecek2 = new List<ClientDateStr>();
            var model = db.Table2.ToList();
            foreach (var item in model)
            {
                var date1 = ((DateTime)item.PublishTime);
                var date2 = DateTime.Now;
                var differ = (date2 - date1).TotalSeconds;
                if (differ < 5)
                {
                    gidecek.Add(item);
                }
            }

            var clientNolar = gidecek
                              .GroupBy(o => new { o.Guid })
                              .Select(o => o.FirstOrDefault());
            var clientNos = clientNolar.ToList();
          
            return Json(clientNos, JsonRequestBehavior.AllowGet);
        }
    }
}
