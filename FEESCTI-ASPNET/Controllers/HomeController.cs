using FEESCTI_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using FEESCTI_ASPNET.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using FEESCTI_ASPNET.Session;

namespace FEESCTI_ASPNET.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
      _db = db;
      _logger = logger;
    }

    public Boolean UsuarioLogado()
    {
      if (LoginSession.Account == null)
      {
        return false;
      }
      return true;
    }

    public IActionResult Index()
    {
      return View("Form");
    }

    public IActionResult Form()
    {
      var model = new Inscricao();
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Form(Inscricao model)
    {

      if (ModelState.IsValid)
      {

        _db.Inscricao.Add(model);
        _db.SaveChanges();

        return View("FormSuccess", model);

      }
      return View(model);
    }

    public IActionResult FormSuccess(Inscricao model)
    {
      return View(model);
    }



    public IActionResult Search()
    {
      return View();
    }

    public IActionResult SearchResult(string searchId)
    {
      //Verificar a possibilidade de remover esse if pois é possível limitar o campo para valores !=null e >0
      if (searchId == null || searchId.Equals('0'))
      {
        return View();

      }
      else if (searchId.All(char.IsDigit))
      {
        var model = _db.Inscricao.Find(int.Parse(searchId));
        if (model == null)
        {
          return View();
        }
        return View(model);

      }

      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }


}
