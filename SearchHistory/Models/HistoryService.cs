using System.Collections.Generic;

namespace SearchHistory.Models
{
    public class HistoryService
    {
        private IRepository _repository;

        public List<DailyHistory> GetDailyHistory()
        {
            return _repository.GetDailyHistory();
        }

        public List<HourlyHistory> GetHourlyHistory()
        {
            return _repository.GetHourlyHistory();
        }

        public HistoryService()
        {
            _repository = new DbRepository();
        }

        internal void GetDailyHistoryXml()
        {
            throw new System.NotImplementedException();
        }
    }
}