using System;
using System.Collections.Generic;
using Common.Model;

namespace Common
{
    public interface IStorage
    {
        void PutRates(IEnumerable<Rate> storeItem);
        IEnumerable<Rate> GetRates(IEnumerable<string> rateNames, DateTime? dtFrom, DateTime? dtTo);
    }
}