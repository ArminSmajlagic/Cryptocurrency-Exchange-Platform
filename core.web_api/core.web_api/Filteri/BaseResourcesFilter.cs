using Microsoft.AspNetCore.Mvc.Filters;

namespace core.web_api.Filteri
{
    public class BaseResourcesFilter : Attribute, IResourceFilter
    {
        private readonly ILogger logger;

        public BaseResourcesFilter(ILogger logger)
        {
            this.logger = logger;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //called at the end - after action filter
            logger.Log(LogLevel.Information, "Base resource filter has ben called upon...and it is executed!");
            //Console.WriteLine(context.HttpContext.Request.Path);
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //called before action filter
            logger.Log(LogLevel.Information, "Base resource filter has ben called upon...and it is executing!");

            //Console.WriteLine(context.HttpContext.Request.Path);
        }
    }
}
