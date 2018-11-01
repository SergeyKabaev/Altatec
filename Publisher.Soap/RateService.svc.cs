using System;
using System.Collections.Generic;
using Common;
using Common.Model;

namespace Publisher.Soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RateService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RateService.svc or RateService.svc.cs at the Solution Explorer and start debugging.
    public class RateService : IRateService
    {
        public IStorage Storage { get; set; }

        public IEnumerable<Rate> GetRates(IEnumerable<string> rateNames, DateTime? dtFrom, DateTime? dtTo)
        {
            return Storage.GetRates(rateNames, dtFrom, dtTo);
        }
    }
}
