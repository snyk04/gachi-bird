using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace GachiBird.LeaderBoard
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly SqliteConnection _connection;
        
        public Dictionary<string, long> BestScores { get; }
        
        public DatabaseManager(string dataSource)
        {
            _connection = new SqliteConnection($"Data Source={dataSource}");
            _connection.Open();

            BestScores = new Dictionary<string, long>();
            UpdateProxy();
        }

        public void AddNewBestScore(string userName, long bestScore)
        {
            if (BestScores.ContainsKey(userName))
            {
                ToCommand($"update User set best_score = {bestScore} where name = '{userName}'").ExecuteNonQuery();
                BestScores[userName] = bestScore;
            }
            else
            {
                ToCommand($"insert into User (name, best_score) values ('{userName}', {bestScore})").ExecuteNonQuery();
                BestScores.Add(userName, bestScore);
            }
        }

        private void UpdateProxy()
        {
            BestScores.Clear();

            SqliteCommand command = ToCommand("select name, best_score from User order by best_score desc");

            SqliteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var name = reader.GetValue(0).ToString();
                    long bestScore = (int) reader.GetValue(1);

                    BestScores.Add(name, bestScore);
                }
            }
        }

        private SqliteCommand ToCommand(string query)
        {
            return new SqliteCommand()
            {
                Connection = _connection,
                CommandText = query
            };
        }
    }
}
