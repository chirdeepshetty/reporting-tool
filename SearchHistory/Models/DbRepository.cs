using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace SearchHistory.Models
{
    public class DbRepository : IRepository
    {
        public List<DailyHistory> GetDailyHistory()
        {
            List<DailyHistory> list = new List<DailyHistory>();

            using (var connection = new SQLiteConnection(@"data source=\\sathya\db\groupHistory.db"))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = @"select count(*), QUERYTIME from GROUP_SEARCH_HISTORY                                                          
                                                            GROUP BY date(QUERYTIME)";

                command.CommandType = CommandType.Text;
                    
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //var temp = reader.GetValue(1);
                    
                    DailyHistory history = new DailyHistory(DateTime.Parse(reader.GetValue(1).ToString()).Date, 
                                                            int.Parse(reader.GetValue(0).ToString()));
                    list.Add(history);
                }
                reader.Close();
                command.Dispose();
            }
        
            return list;
            
        }

        public List<HourlyHistory> GetHourlyHistory()
        {
            throw new NotImplementedException();
        }
    }
}