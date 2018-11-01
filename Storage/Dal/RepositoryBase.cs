using System.Data;
using System.Data.SQLite;

namespace Common.Dal
{
    public class RepositoryBase
    {
        private readonly IConfig _config;

        public RepositoryBase(IConfig config)
        {
            _config = config;
            Initialize();
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection("Data Source=" + _config.DbPath).OpenAndReturn();
        }

        public void Initialize()
        {
            if (!RateTableExists())
                CreateRateTable();
        }

        private bool RateTableExists()
        {
            using (var query = new SQLiteCommand(GetConnection()))
            {
                query.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='Rate'";
                query.CommandType = CommandType.Text;
                var res = query.ExecuteScalar(CommandBehavior.CloseConnection);
                return res != null;
            }
        }

        private void CreateRateTable()
        {
            using (var cmd = new SQLiteCommand(GetConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "CREATE TABLE Rate ( " +
                                  "Dt TEXT NOT NULL, " +
                                  "RateName TEXT NOT NULL, " +
                                  "BuyValue NUMERIC NOT NULL, " +
                                  "SellValue NUMERIC )";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE UNIQUE INDEX Dt_RateName ON Rate ( Dt ASC, RateName ASC )";
                cmd.ExecuteNonQuery(CommandBehavior.CloseConnection);
            }
        }
    }
}