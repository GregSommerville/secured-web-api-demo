using System.Web.Http.Filters;

namespace DemoSecuredAPI
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // ELMAH is normally not called with a Web API (since all errors are converted into 500 errors, and sent back).
            // So we're catching any errors and calling Elmah directly.

            //Note that with this approach the following errors will not be handled:
            //Exceptions thrown from controller constructors.
            //Exceptions thrown from message handlers.
            //Exceptions thrown during routing.
            //Exceptions thrown during response content serialization

            // However, any errors in my controller code or the models will be caught

            Elmah.ErrorSignal.FromCurrentContext().Raise(context.Exception);
        }
    }
}