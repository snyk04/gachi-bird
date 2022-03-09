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
            AddNewBestScore("snyk04", 228);
        }

        public void AddNewBestScore(string userName, long bestScore)
        {
            // TODO : Handle situation, where you have to update existing userName (modify bestScore column for userName)
            ToCommand($"insert into User (name, best_score) values ('{userName}', {bestScore})").ExecuteNonQuery();
            UpdateProxy();
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
                    string name = reader.GetValue(0).ToString();
                    long bestScore = (long)reader.GetValue(1);

                    BestScores.Add(name, bestScore);
                }
            }
        }

        private SqliteCommand ToCommand(string query) => new SqliteCommand()
        {
            Connection = _connection, CommandText = query,
        };
    }
}
