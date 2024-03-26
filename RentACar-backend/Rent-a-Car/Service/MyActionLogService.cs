using GMS.Entities.Models;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Http.Extensions;
using RentACar.DBContext;

namespace RentACar.Service
{
    public class MyActionLogService
    {
        public async Task Create(HttpContext httpContext)
        {
            var authService = httpContext.RequestServices.GetService<MyAuthService>()!;
            var request = httpContext.Request;

            var queryString = request.Query;

            //if (queryString.Count == 0 && !request.HasFormContentType)
            //    return 0;

            //IHttpRequestFeature feature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            string detalji = "";
            if (request.HasFormContentType)
            {
                foreach (string key in request.Form.Keys)
                {
                    detalji += " | " + key + "=" + request.Form[key];
                }
            }

            // convert stream to string
            StreamReader reader = new StreamReader(request.Body);
            string bodyText = await reader.ReadToEndAsync();

            var x = new LogKretanjePoSistemu
            {
                Korisnik = authService.GetAuthInfo().korisnickiNalog!,
                Vrijeme = DateTime.Now,
                QueryPath = request.GetEncodedPathAndQuery(),
                PostData = detalji + "" + bodyText,
                IpAdresa = request.HttpContext.Connection.RemoteIpAddress?.ToString(),
            };

            //if (exceptionMessage != null)
            //{
            //    x.isException = true;
            //    x.exceptionMessage = exceptionMessage.Error.Message + " |" + exceptionMessage.Error.InnerException;
            //}

            ApplicationDbContext db = request.HttpContext.RequestServices.GetService<ApplicationDbContext>();

            db.Add(x);
            await db.SaveChangesAsync();

        }
    }
}
