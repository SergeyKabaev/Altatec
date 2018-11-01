using System;
using System.Collections.Generic;
using Common.Dal;
using Common.Model;

namespace Common
{
    internal class Storage : IStorage
    {
        private readonly IRateRepository _rateRepository;

        public Storage(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public void PutRates(IEnumerable<Rate> rates)
        {
            foreach (var rate in rates)
                _rateRepository.InsertRate(rate);
        }

        public IEnumerable<Rate> GetRates(IEnumerable<string> rateNames, DateTime? dtFrom, DateTime? dtTo)
        {
            return _rateRepository.QueryRate(rateNames, dtFrom, dtTo);
        }
    }
}