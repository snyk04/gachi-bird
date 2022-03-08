using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace GachiBird.LeaderBoard
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly SqliteConnection _connection;
        private readonly Dictionary<string, long> _bestScores;

        public DatabaseManager(string dataSource)
        {
            _connection = new SqliteConnection($"Data Source={dataSource}");
            _connection.Open();

            _bestScores = new Dictionary<string, long>();
            UpdateProxy();
            AddNewBestScore("snyk04", 228);
        }

        public void AddNewBestScore(string userName, long bestScore)
        {
            // TODO : Handle situation, where you have to update existing userName (modify bestScore column for userName)
            var command = new SqliteCommand()
            {
                Connection = _connection,
                CommandText = $"insert into User (name, best_score) values ('{userName}', {bestScore})"
            };
            command.ExecuteNonQuery();
            UpdateProxy();
        }
        public Dictionary<string, long> GetBestScores()
        {
            return _bestScores;
        }

        private void UpdateProxy()
        {
            _bestScores.Clear();
            
            var command = new SqliteCommand()
            {
                Connection = _connection,
                CommandText = "select name, best_score from User order by best_score desc"
            };
            SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var name = reader.GetValue(0).ToString();
                    var bestScore = (long) reader.GetValue(1);
                    
                    _bestScores.Add(name, bestScore);
                }
            }
        }
    }
}