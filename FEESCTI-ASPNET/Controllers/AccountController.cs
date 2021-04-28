using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using FEESCTI_ASPNET.Models;
using FEESCTI_ASPNET.Data;
using Microsoft.EntityFrameworkCore;
using FEESCTI_ASPNET.Session;


namespace FEESCTI_ASPNET.Controllers
{
  public class AccountController : Controller
  {
    private readonly ApplicationDbContext _db;

    public AccountController(ApplicationDbContext db)
    {
      _db = db;
    }

    public IActionResult Login()
    {
      if (LoginSession.Error != null)
      {
        ViewBag.error = LoginSession.Error;
        LoginSession.Error = null;
      }
      return View();
    }

    [HttpPost]
    public ActionResult Verify(Account model)
    {
      IQueryable<Account> queryResult = _db.Account.FromSqlRaw("select * from Account where Username='" + model.Username + "' and Password='" + model.Password + "'");
      if (queryResult.Contains(model))
      {
        LoginSession.Account = model;
        return RedirectToAction("Index", "Admin");
      }
      return View("Login");
    }


    public IActionResult Logout()
    {
      LoginSession.Account = null;
      return RedirectToAction("Index", "Home");
    }
  }
}
