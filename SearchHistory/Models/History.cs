using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SearchHistory.Models
{
    public class History
    {
        public String HourlyData()
        {
            return "Hourly data";
        }
        public String DailyData()
        {
            return "Daily data";
        }
        public String ByComputerData()
        {
            return "By Computer data";
        }
    }
}
