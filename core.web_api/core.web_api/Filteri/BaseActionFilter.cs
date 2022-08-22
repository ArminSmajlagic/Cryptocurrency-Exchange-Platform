using Microsoft.AspNetCore.Mvc.Filters;

namespace core.web_api.Filteri
{
    //here can be added data validations
    public class BaseActionFilter : ActionFilterAttribute
    {
        private readonly ILogger logger;

        public BaseActionFilter(ILogger logger)
        {
            this.logger = logger;
        }

        //"sandwiched" between resources filter executing and executed methods
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            logger.Log(LogLevel.Debug, "Base action filter has ben called upon...and it is executed!");

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            logger.Log(LogLevel.Debug, "Base action filter has ben called upon...and it is executing!");
        }
    }
}
