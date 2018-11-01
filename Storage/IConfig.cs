using System.Collections.Generic;

namespace Common
{
    public interface IConfig
    {
        IEnumerable<string> RateNames { get; }
        int PauseInSeconds { get; }
        int ErrorQntLeadingToCrash { get; }
        string ReqwestUrl { get; }
        string DbPath { get; }
    };
}