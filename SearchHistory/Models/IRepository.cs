using System.Collections.Generic;

namespace SearchHistory.Models
{
    public interface IRepository
    {
        List<DailyHistory> GetDailyHistory();
        List<HourlyHistory> GetHourlyHistory();
        List<IpHistory> GetIpHistory();
    }
}