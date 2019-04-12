using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranslateLib;
using WebUI.Models;
using WebUI.Views.Shared;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITranslator _translator;

        public HomeController(ITranslator translator)
        {
            _translator = translator;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Translate(string toTranslate)
        {
            string result;
            try
            {
                result = _translator.Translate(toTranslate);
            }
            catch(Exception e)
            {
                result = TextFile.errorTranslateMessage + "\n" + e.Message;
            }
            return Content(result);
        }
    }
}
