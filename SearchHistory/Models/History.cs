using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace SearchHistory.Models
{
    public class DailyHistory
    {
        private DateTime _date;
        private int _noOfSearches;
        
        public DailyHistory(DateTime date, int searches)
        {
            _date = date;
            _noOfSearches = searches;
        }


        public DateTime Date
        {
            get { return _date; }
        }

        public int NoOfSearches
        {
            get { return _noOfSearches; }
        }
    }

    public class HourlyHistory
    {
        private int _hour;
        private int _noOfSearches;

        public HourlyHistory(int hour, int noOfSearches)
        {
            _hour = hour;
            _noOfSearches = noOfSearches;
        }


    }
}
