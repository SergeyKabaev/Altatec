using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using Common.Model;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Common.Dal
{
    class RateRepository : RepositoryBase, IRateRepository
    {
        public RateRepository(IConfig config) : base(config)
        {
        }

        public void InsertRate(Rate rate)
        {
            using (var conn = GetConnection())
            using (var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                conn.Insert<Rate>(rate, transaction);
                transaction.Commit();
            }
        }

        public IEnumerable<Rate> QueryRate(IEnumerable<string> rateNames, DateTime? dtFrom, DateTime? dtTo)
        {
            using (var conn = GetConnection())
            {
                var sql = "select * from Rate";
                dynamic expandoObj = new ExpandoObject();

                var conditions = new List<string>();
                if (rateNames.Any())
                {
                    conditions.Add($"RateName in @RateNames");
                    expandoObj.RateNames = rateNames;
                }

                if (dtFrom.HasValue)
                {
                    conditions.Add($"Dt >= @DtFrom");
                    expandoObj.DtFrom = dtFrom.Value;
                }

                if (dtTo.HasValue)
                {
                    conditions.Add($"Dt <= @DtTo");
                    expandoObj.DtTo = dtTo.Value;
                }

                if (!conditions.Any())
                    return conn.Query<Rate>(sql);
                    
                sql += " where " + string.Join(" and ", conditions);
                var parameters = new DynamicParameters();
                ((ExpandoObject)expandoObj).ToList().ForEach(kvp => parameters.Add(kvp.Key, kvp.Value));
                var result = conn.Query<Rate>(sql, parameters);
                return result;
            }
        }
    }
}