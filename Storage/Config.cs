using System.Collections.Generic;

namespace Common
{
    class Config : ConfigBase, IConfig
    {
        public IEnumerable<string> RateNames => GetSetting("RateNames").Split(',');
        public int PauseInSeconds => GetIntSetting("PauseInSeconds");

        public int ErrorQntLeadingToCrash => GetIntSetting("ErrorQntLeadingToCrash");
        public string ReqwestUrl => GetSetting("ReqwestUrl");
        public string DbPath => GetSetting("DbPath");
    }
}