using ApplicationView.Resolver.HelperError.IExceptions;
using System; 

namespace ApplicationView.Resolver.HelperError.Handlers
{
    public abstract class BaseExceptionHandler
    {
        private BaseExceptionHandler mychainhandler;

        public BaseExceptionHandler Mychainhandler
        {
            get
            {
                return mychainhandler;
            }

            set
            {
                mychainhandler = value;
            }
        }

        public abstract IApiExceptions HandleExceptions(Exception ex);
    }
}
