using System;
using System.Collections.Generic;
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
using SearchHistory.Infrastructure;

namespace SearchHistory.Models
{
    public class SearchHistory
    {
        public SearchResult GetHourlySearchData(DateTime fromDate, DateTime toDate)
        {
            return new SearchResult();
        }
        public SearchResult GetDailySearchData(DateTime fromMonth, DateTime toMonth)
        {
            return new SearchResult();
        }
        public SearchResult GetIPSearchData()
        {
            return new SearchResult();
        }


    }

}
