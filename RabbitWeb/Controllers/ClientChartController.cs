using Newtonsoft.Json;
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

        [Route("ClientChart/ClientChartActRes/{GuidInCome}")]// GET: ClientChart
        public ActionResult ClientChartActRes(string GuidInCome)
        {
            var model = db2.Table1.ToList();
            ClientChart clientChart = new ClientChart();
            clientChart.InsertMoments = new List<DateTime?>();
           
            List<Table1> LessFifteen = new List<Table1>();

            foreach (var item in model)
            {
                var date1 = ((DateTime)item.InsertDate);
                var date2 = DateTime.Now;
                var differ = (date2 - date1).TotalSeconds;
                if (differ <= 900 && item.ClientNo == GuidInCome)
                {
                    LessFifteen.Add(item);

                }
            }

            foreach (var item in LessFifteen)
            {
                clientChart.InsertMoments.Add(item.InsertDate);
            }
            
            clientChart.ClientGuid = GuidInCome;
            clientChart.deneme = "deneme";
            return View(clientChart);
        }
      
    }
}