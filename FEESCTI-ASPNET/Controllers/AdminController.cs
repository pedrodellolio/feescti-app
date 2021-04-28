using FEESCTI_ASPNET.Data;
using FEESCTI_ASPNET.Filters;
using FEESCTI_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FEESCTI_ASPNET.Controllers
{
  [AuthUser]
  public class AdminController : Controller
  {
    private readonly ApplicationDbContext _db;

    public AdminController(ApplicationDbContext db)
    {
      _db = db;
    }

    public IActionResult Index()
    {
      IEnumerable<Inscricao> model = _db.Inscricao;
      return View(model);
    }

    public IActionResult Analise(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var model = _db.Inscricao.Find(id);

      if (model == null)
      {
        return NotFound();
      }
      return View(model);
    }


    //AntiForgeryToken
    [HttpPost]
    public IActionResult Analise(Inscricao model)
    {
      _db.Inscricao.Update(model);
      _db.SaveChanges();


      return RedirectToAction("Index");
    }
 
  }


}
