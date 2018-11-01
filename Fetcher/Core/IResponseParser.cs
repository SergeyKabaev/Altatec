using Common;
using Common.Model;

namespace Fetcher.Core
{
    internal interface IResponseParser
    {
        Rate Parse(string rateName, string rateAsJson);
    }
}