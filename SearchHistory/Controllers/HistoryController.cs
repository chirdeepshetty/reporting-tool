using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.UI.DataVisualization.Charting;
using SearchHistory.Models;

namespace SearchHistory.Controllers
{
    public class XMLOutput : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            
        }
    }

    [HandleError]
    public class HistoryController : Controller
    {
        public ActionResult SearchHistory()
        {
            return View();
        }

        public ActionResult GetDailyHistoryXml()
        {
            return new XMLOutput();
        }
     }
}
