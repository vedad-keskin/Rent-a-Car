using System.Diagnostics;
using GMS.Entities.Models;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentACar.Service;

namespace RentACar.Helpers.Auth
{
    public class MyAuthorizationAttribute : TypeFilterAttribute
    {
        public MyAuthorizationAttribute() : base(typeof(MyAuthorizationAsyncActionFilter))
        {
        }
    }
    public class MyAuthorizationAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authService = context.HttpContext.RequestServices.GetService<MyAuthService>()!;
            var actionLogService = context.HttpContext.RequestServices.GetService<MyActionLogService>()!;

            if (!authService.JelLogiran())
            {
                context.Result = new UnauthorizedObjectResult("Niste logirani na sistem!");
                return;
            }

            MyAuthInfo myAuthInfo = authService.GetAuthInfo();



            await next();
            await actionLogService.Create(context.HttpContext);



        }
    }
}