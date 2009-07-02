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

            using (var connection = new SQLiteConnection(@"data source=\\sathya\persistence\groupHistory.db"))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = @"select count(*), QUERYTIME from GROUP_SEARCH_HISTORY                                                          
                                                            GROUP BY date(QUERYTIME)";

                command.CommandType = CommandType.Text;
                    
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        DailyHistory history = new DailyHistory(reader.GetDateTime(1),
                                                                reader.GetInt32(0));
                        list.Add(history);
                    }
                    catch(Exception exception)
                    {
                        
                    }
                }
                reader.Close();
                command.Dispose();
            }
        
            return list;
            
        }

        public List<HourlyHistory> GetHourlyHistory()
        {
            List<HourlyHistory> list = new List<HourlyHistory>();

            using (var connection = new SQLiteConnection(@"data source=\\sathya\persistence\groupHistory.db"))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = @"select count(*), strftime(""%H"", QUERYTIME) from GROUP_SEARCH_HISTORY                                                          
                                                            GROUP BY strftime(""%H"", QUERYTIME)";

                command.CommandType = CommandType.Text;
                    
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //var temp = reader.GetValue(1);

                    HourlyHistory history = new HourlyHistory(int.Parse(reader.GetValue(1).ToString()), 
                                                            int.Parse(reader.GetValue(0).ToString()));
                    list.Add(history);
                }
                reader.Close();
                command.Dispose();
            }
        
            return list;
            
        }

        public List<IpHistory> GetIpHistory()
        {
            List<IpHistory> list = new List<IpHistory>();

            using (var connection = new SQLiteConnection(@"data source=\\sathya\persistence\groupHistory.db"))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = @"select count(*), IPADDRESS from GROUP_SEARCH_HISTORY                                                          
                                                            GROUP BY IPADDRESS";

                command.CommandType = CommandType.Text;

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //var temp = reader.GetValue(1);

                    IpHistory history = new IpHistory(reader.GetValue(1).ToString(),
                                                            int.Parse(reader.GetValue(0).ToString()));
                    list.Add(history);
                }
                reader.Close();
                command.Dispose();
            }

            return list;

        }
        
    }
}