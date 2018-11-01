using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Model;

namespace Publisher.Soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRateService" in both code and config file together.
    [ServiceContract]
    public interface IRateService
    {
        [OperationContract]
        IEnumerable<Rate> GetRates(IEnumerable<string> rateNames, DateTime? dtFrom, DateTime? dtTo);
    }
}
