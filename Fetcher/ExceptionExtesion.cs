using System;

namespace Fetcher
{
    public static class ExceptionExtesion
    {
        public static Exception GetLastInnerException(this Exception exc)
        {
            if (exc.InnerException == null)
                return exc;
            else
                return exc.InnerException.GetLastInnerException();
        }
    }
}