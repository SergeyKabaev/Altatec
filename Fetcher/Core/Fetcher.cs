using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading;
using Common;
using Common.Model;
using NLog;

namespace Fetcher.Core
{
    class Fetcher : IFetcher
    {
        private readonly IStorage _storage;
        private readonly ILogger _logger;
        private readonly IResponseParser _responseParser;
        private readonly IConfig _config;
        private int _errCounter = 0;

        public Fetcher(IStorage storage, ILogger logger, IResponseParser responseParser, IConfig config)
        {
            _storage = storage;
            _logger = logger;
            _responseParser = responseParser;
            _config = config;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    _storage.PutRates(FetchRates());
                    Thread.Sleep(_config.PauseInSeconds + 1000);
                }
                catch (Exception e)
                {
                    _logger.Error(e, "fetch error");
                    if (_errCounter >= _config.ErrorQntLeadingToCrash)
                        throw;
                }
            }
        }

        private IEnumerable<Rate> FetchRates()
        {
            foreach (var rateName in _config.RateNames)
                yield return FetchRate(rateName);
        }

        private Rate FetchRate(string rateName)
        {
            var url = ConstructUrl(rateName);
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = myReq.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
                return _responseParser.Parse(rateName, reader.ReadToEnd());
        }

        private string ConstructUrl(string rateName)
        {
            return _config.ReqwestUrl.Replace("$rateName$", rateName);
        }
    }
}