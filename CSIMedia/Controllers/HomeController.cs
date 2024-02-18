using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSIMedia.Models;
using CSIMedia.Services;

namespace CSIMedia.Controllers;

public class HomeController(NumberHandlerService numberHandlerService) : Controller
{
    public async Task<IActionResult> Index(bool error = false, string? message = null)
    {
        var numbers = await numberHandlerService.GetNumbersAsync();
        return View(new IndexModel
        {
            Numbers = numbers,
            ValidationResult = (error, message)
        });
    }

    public async Task<IActionResult> SubmitNumbers(UserInputModel userInputModel)
    {
        var result = await numberHandlerService.AddNumbers(userInputModel);
        return RedirectToAction("Index", "Home", new {result.Error, result.Message});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
