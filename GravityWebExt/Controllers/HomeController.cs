using GravityWebExt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _db;

        public HomeController(ILogger<HomeController> logger, DataContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Measurement()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Options()
        {
            return View(_db.Options.ToList());
        }
        [HttpPost]
        public IActionResult Options(OptionsData optData)
        {
            OptionsData _findData = _db.Options.Find(optData.Id);
            if(_findData != null)
            {
                 _db.Options.Remove(_findData);
                 _db.Options.Add(optData);
                 _db.SaveChanges();
                //Отправляем новые данные в Калькулятор
                //_db.Options.ElementAt(0).SetDataForCalculate();
            }

            return View(_db.Options.ToList());
        }
            

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
