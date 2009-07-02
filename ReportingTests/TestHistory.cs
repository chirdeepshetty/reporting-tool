using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using SearchHistory.Models;

namespace ReportingTests
{
    public class MockRepo : IRepository
    {

        #region IRepository Members

        public List<DailyHistory> GetDailyHistory()
        {
            List<DailyHistory> histories = new List<DailyHistory>();
            histories.Add(new DailyHistory(DateTime.Now, 100));
            histories.Add(new DailyHistory(new DateTime(2009, 6, 1), 10));
            return histories;
        }

        public List<HourlyHistory> GetHourlyHistory()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    [TestFixture]
    public class TestHistory
    {
        [Test]
        public void TestRetriveDateWiseHistory()
        {
            HistoryService historyList = new HistoryService();
            var list = historyList.GetDailyHistory();
            Assert.That(list.Count.Equals(2), "Retrieved 2 items");

        }
    }

    [TestFixture]
    public class  TestDbRetrievals
    {
        [Test]   
        public void TestDbRetrieval()
        {
            IRepository repo = new DbRepository();
            var list = repo.GetDailyHistory();
            Assert.That(list.Count.Equals(2));

        }
    }
}
