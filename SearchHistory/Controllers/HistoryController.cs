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
    [HandleError]
    public class HistoryController : Controller
    {
        private History _history = new History();
        //
        // GET: /History/

        public ActionResult SearchHistory()
        {
            ViewData["Hourly"] = _history.HourlyData();
            ViewData["Daily"] = _history.DailyData();
            ViewData["ByComputer"] = _history.ByComputerData();
         
            return View();
        }

        public FileResult GetChart()
        {
            
            ViewData["Chart"] = Models.StaticModel.createStaticData();
            System.Web.UI.DataVisualization.Charting.Chart Chart2 = new System.Web.UI.DataVisualization.Charting.Chart();
            Chart2.Width = 412;
            Chart2.Height = 296;
            Chart2.RenderType = RenderType.ImageTag;
            Chart2.Palette = ChartColorPalette.BrightPastel;
            Title t = new Title("Google History", Docking.Top, new System.Drawing.Font("Trebuchet MS", 14, System.Drawing.FontStyle.Bold), System.Drawing.Color.FromArgb(26, 59, 105));
            Chart2.Titles.Add(t);
            Chart2.ChartAreas.Add("Series 1");
            // create a couple of series   
            Chart2.Series.Add("Series 1");
           
            // add points to series 1   
            foreach (int value in (List<int>)ViewData["Chart"])
            {
                Chart2.Series["Series 1"].Points.AddY(value);
            }
           
            Chart2.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            Chart2.BorderlineWidth = 2;
            Chart2.BorderColor = System.Drawing.Color.Black;
            Chart2.BorderlineDashStyle = ChartDashStyle.Solid;
            Chart2.BorderWidth = 2;

            Chart2.Legends.Add("Legend1");
            MemoryStream imageStream = new MemoryStream();
            Chart2.SaveImage(imageStream, ChartImageFormat.Png);
            return new FileResult("Yo.png", "image/png", imageStream.ToArray());
        }

        public FileResult GetHourlyChart()
        {
            return null;
            //return GetChart("Hourly History", Models.StaticModel.createStaticData())
        }

        public FileResult GetDailyChart()
        {
            return null;
            //return GetChart("Hourly History", Models.StaticModel.createStaticData())
        }

        public FileResult GetByComputerChart()
        {
            return null;
            //return GetChart("Hourly History", Models.StaticModel.createStaticData())
        }

    }
}
