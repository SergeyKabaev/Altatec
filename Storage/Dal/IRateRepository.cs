using System;
using System.Collections.Generic;
using Common.Model;

namespace Common.Dal
{
    internal interface IRateRepository
    {
        void InsertRate(Rate rate);
        IEnumerable<Rate> QueryRate(IEnumerable<string> rateNames, DateTime? dt, DateTime? dtTo);
    }
}