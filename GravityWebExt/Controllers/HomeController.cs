﻿using GravityCalc;
using GravityData;
using GravityWebExt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly WebNSPDataProvider _dataNSPProvider;
        private readonly Emulator _emu;
        private readonly WebDataReporter _webDataReporter;
        private readonly WebCalcDataReporter _webCalcDataReporter;

        public HomeController(ILogger<HomeController> logger, DataContext db, WebDataProvider dataProvider, WebNSPDataProvider dataNSPProvider, WebCalcDataReporter webCalcDataReporter ,Emulator emu, WebDataReporter webDataReporter)
        {
            _logger = logger;
            _db = db;
            _dataProvider = dataProvider;
            _dataNSPProvider = dataNSPProvider;
            _emu = emu;
            _webDataReporter = webDataReporter;
            _webCalcDataReporter = webCalcDataReporter;

        }
        /// <summary>
        /// Получены новые данные от контроллера
        /// </summary>
        public JsonResult GetControllerDataRepeat()
        {
            return Json(GetControllerData());
        }
        /// <summary>
        /// Получены новые данные от калькулятора
        /// </summary>
        public JsonResult GetCalculatorDataRepeat()
        {
            return Json(GetCalculatorData());
        }

        public List<MeasurementData> GetControllerData()
        {
            return new List<MeasurementData>() { new MeasurementData(_webDataReporter.Data) };
        }

        public ControlPanelDataWeb GetControllerData()
        {
            return new ControlPanelDataWeb(_webDataReporter.Data);
        }

        public CalculatedDataWeb GetCalculatorData()
        {
            return new CalculatedDataWeb(_webCalcDataReporter.Data);
        }

        public MeasurementData GetMeasurementData()
        {
            return new MeasurementData(new ControlPanelDataWeb(_webDataReporter.Data), new CalculatedDataWeb(_webCalcDataReporter.Data));
        }

        public JsonResult SetControllerData(double jackUp, double jackDown, double cargoLeft, double cargoRight, double speedJack, double speedCargo)
        {
                _dataWebToControllerDataProvider.SendData(new ControllerDataIn()
            {
                SpeedCargo = speedCargo,
                SpeedJack = speedJack,
                GoJackUp = jackUp,
                GoJackDown = jackDown,
                GoCargoLeft = cargoLeft,
                GoCargoRight = cargoRight
            });

            return Json(_webDataReporter.Data);
        }
        /// <summary>
        /// Очистить ошибки контроллера
        /// </summary>
        /// <returns></returns>
        public JsonResult SetResetErrors()
        {
            _dataWebToControllerDataProvider.SendData(new ControllerDataIn()
            {
                ResetErrors = 1
            });

            return Json(_webDataReporter.Data);
        }
        [HttpGet]
        public IActionResult Calculate()
        {
            return View(GetCalculatorData());
        }
        
        [HttpGet]
        public IActionResult NSP()
        {
            return View(_db.NSP.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> NSP(NSPWebData data)
        {
            NSPWebData findData = await _db.NSP.FindAsync(data?.Id);
            if (findData != null)
            {
                _db.NSP.Remove(findData);
                await _db.NSP.AddAsync(data);
                await _db.SaveChangesAsync();
                //Отправляем новые данные в Калькулятор
                _dataNSPProvider.SendData(_db.NSP.ToList().ElementAt(0).SetDataForCalculate());
                _logger.LogInformation("Отправлены НСП данные для расчёта");
            }

            return View(_db.NSP.ToList());
        } 


            return View(_db.RecomValWebData.ToList());
        }

        [HttpGet]
        public IActionResult ControlPanel()
        {
            return View(GetControllerData()); 
        }

        [HttpGet, Authorize(Roles = "admin")]
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
