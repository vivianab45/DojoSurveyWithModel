using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithModel.Models;

namespace DojoSurveyWithModel.Controllers;

public class HomeController : Controller
{
    static User NewUser;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult FormView()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(User user)
    {
        NewUser= user;
        return RedirectToAction("ResultsView");
    }

    [HttpGet("results")]
    public IActionResult ResultsView()
    {
        return View(NewUser);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
