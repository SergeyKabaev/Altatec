using System;
using Common;
using Common.Model;
using Newtonsoft.Json.Linq;

namespace Fetcher.Core
{
    public class ResponseParser : IResponseParser
    {
        public Rate Parse(string rateName, string rateAsJson)
        {
            dynamic rateAsDynamic = JObject.Parse(rateAsJson);
            dynamic rateBody = rateAsDynamic[rateName];
            return new Rate()
            {
                Dt = DateTime.Now,
                RateName = rateName,
                BuyValue = decimal.Parse(rateBody["buy"].ToString()),
                SellValue = decimal.Parse(rateBody["sell"].ToString())
            };
        }
    }
}