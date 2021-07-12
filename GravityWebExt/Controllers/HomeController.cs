using GravityCalc;
using GravityData;
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
        private readonly WebDataProvider _dataProvider;
        private readonly Emulator _emu;
        private readonly WebDataReporter _webDataReporter;

        public HomeController(ILogger<HomeController> logger, DataContext db, WebDataProvider dataProvider, Emulator emu, WebDataReporter webDataReporter)
        {
            _logger = logger;
            _db = db;
            _dataProvider = dataProvider;
            _emu = emu;
            _webDataReporter = webDataReporter;

        }
        /// <summary>
        /// Получены новые данные от контроллера
        /// </summary>
        /// <param name="controllerData"></param>
        public JsonResult GetControllerDataRepeat()
        {
            //MeasurementData measurementDb = await _db.Measurement.FindAsync(1);

            //if (measurementDb != null)
            //{
            //    _db.Measurement.Remove(measurementDb);
            //    await _db.Measurement.AddAsync(new(_webDataReporter.Data));
            //    await _db.SaveChangesAsync();
            //}
            return Json(GetControllerData());
        }

        public List<MeasurementData> GetControllerData()
        {
            return new List<MeasurementData>() { new MeasurementData(_webDataReporter.Data) };
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NSP()
        {
            return View(_db.NSP.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> NSP(GravityWebExt.Models.NSPData data)
        {
            GravityWebExt.Models.NSPData findData = await _db.NSP.FindAsync(data?.Id);
            if (findData != null)
            {
                _db.NSP.Remove(findData);
                await _db.NSP.AddAsync(data);
                await _db.SaveChangesAsync();
                //Отправляем новые данные в Калькулятор
                //_dataProvider.SendData(_db.NSP.ToList().ElementAt(0).SetDataForCalculate());
                //_logger.LogInformation("Отправлены паспортные данные для расчёта");
                //Отправляем новые данные в эмулятор 
                //_emu.SetPassportData(_db.Options.ToList().ElementAt(0).SetDataForCalculate());
                //_logger.LogInformation("Отправлены паспортные данные для эмулятор");
            }

            return View(_db.NSP.ToList());
        }


        [HttpGet]
        public IActionResult Measurement()
        {
            return View(GetControllerData());
        }

        [HttpGet]
        public IActionResult Options()
        {
            return View(_db.Options.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Options(OptionsData optData)
        {
            OptionsData findData = await _db.Options.FindAsync(optData?.Id);
            if(findData != null)
            {
                _db.Options.Remove(findData);
                await _db.Options.AddAsync(optData);
                await _db.SaveChangesAsync();
                //Отправляем новые данные в Калькулятор
                _dataProvider.SendData(_db.Options.ToList().ElementAt(0).SetDataForCalculate());
                _logger.LogInformation("Отправлены паспортные данные для расчёта");
                //Отправляем новые данные в эмулятор 
                _emu.SetPassportData(_db.Options.ToList().ElementAt(0).SetDataForCalculate());
                _logger.LogInformation("Отправлены паспортные данные для эмулятор");
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
