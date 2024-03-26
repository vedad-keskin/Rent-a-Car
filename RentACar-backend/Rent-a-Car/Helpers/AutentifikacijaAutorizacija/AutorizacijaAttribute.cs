using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GMS.Helpers.AutentifikacijaAutorizacija
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool admin, bool korisnik)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { };
        }
    }


    public class MyAuthorizeImpl : IActionFilter
    {
        private readonly bool _admin;
        private readonly bool _korisnik;

        public MyAuthorizeImpl(bool admin, bool korisnik)
        {
            _admin = admin;
            _korisnik = korisnik;

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {


        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.GetLoginInfo().isLogiran)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            

            if (filterContext.HttpContext.GetLoginInfo().isLogiran)
            {
                return;//ok - ima pravo pristupa
            }


            //else nema pravo pristupa
            filterContext.Result = new UnauthorizedResult();
        }
    }
}
