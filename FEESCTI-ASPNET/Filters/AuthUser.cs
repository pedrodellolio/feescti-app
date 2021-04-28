using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FEESCTI_ASPNET.Data;
using FEESCTI_ASPNET.Session;

namespace FEESCTI_ASPNET.Filters
{
  public class AuthUser : Attribute, IAsyncActionFilter
  {

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      ApplicationDbContext _context = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();

      if (LoginSession.Account == null)
      {
        LoginSession.Error = "Você precisa estar logado como administrador!";
        context.Result = new RedirectResult("/Account/Login");
        return;
      }
      if (!_context.Account.Contains(LoginSession.Account))
      {
        LoginSession.Error = "Este usuário não existe";
        context.Result = new RedirectResult("/Account/Login");
        return;
      }
      await next();
    }
  }
}
