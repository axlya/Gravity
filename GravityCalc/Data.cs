using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace GravityCalc
{
    /// <summary>
    /// Паспортные данные
    /// </summary>
    public struct PassportData
    {
        public void DefaultInit()
        {
            /////////////////////////////////////////////////////////////////////////StandParameters
            PasK = 837.5;
            PasS = 440;
            PasDevS = 0;
            PasH = 385;
            PasDevH = 0;
            PasL = 2405;
            PasDevL = 0;
            PasQ = 445;
            PasDevQ = 0;
            PasDevPdisbal = 0;
            PasDevEpsilon = 0;
            PasDevFi = 0;           
            PasD = 2120;
            PasDevD = 0;
            PasE = 0;
            PasDevE = 0;
            PasMassPG = 0;
            PasDevMassPG = 0;
            PasMm = 0;
            PasDevMm = 0;
            PasMa = 0;
            PasDevMa = 0;

            /////////////////////////////////////////////////////////////////////////AdapterParametrs
            PerX = 0;
            PerDevX = 0;
            PerY = 0;
            PerDevY = 0;
            PerZ = 0;
            PerDevZ = 0;
            PerMas = 0;
            PerDevMas = 0;
            PerH = 0;
            PerDevH = 0;

            /////////////////////////////////////////////////////////////////////////AdapterParametrs
            KpX = 0;
            KpDevX = 0;
            KpY = 0;
            KpDevY = 0;
            KpZ = 0;
            KpDevZ = 0;
            KpMas = 0;
            KpDevMas = 0;


            /////////////////////////////////////////////////////////////////////// Тарирования углов
            Dev = -0.022;

            ///////////////////////////////////////////////////////////////////////////////////////////// Поправки по координатам (Δ=Δ600+(m–m600)∙(Δ6000–Δ600)/(m6000–m600))
            DevX600 = -0.095;
            DevX6000 = 9.9;
            DevY600 = -0.1552;
            DevY6000 = 0.49;
            DevZ600 = -0.2201;
            DevZ6000 = -1.47;

            Cargo = true;
            KP = true;
        }

        /////////////////////////////////////////////////////////////////////////StandParameters
        /// <summary>
        /// Корректирующий груз для КЦМ
        /// </summary>
        public double PasMm { get; set; }
        /// <summary>
        /// Отклонения корректирующего груза для КЦМ
        /// </summary>
        public double PasDevMm { get; set; }
        /// <summary>
        /// Корректирующий груз для М
        /// </summary>
        public double PasMa { get; set; }
        /// <summary>
        /// Отклонения корректирующего груза для М
        /// </summary>
        public double PasDevMa { get; set; }
        /// <summary>
        ///Горизонтальное расстояние между осью наклона стенда и центром тяжести подвижного груза в его переднем положении (постоянное значение станка от центра изделия до центра линейки)
        /// </summary>
        public double PasK { get; set; } 
        public double PasDevK { get; set; }
        /// <summary>
        /// Горизонтальное расстояние между осью наклона стенда и осью поворота планшайбы
        /// </summary>
        public double PasS { get; set; } 
        /// <summary>
        /// (±Δ)PasS 
        /// </summary>
        public double PasDevS { get; set; } 
        /// <summary>
        /// Вертикальное расстояние между осью наклона стенда и установочной поверхностью планшайбы стенда
        /// </summary>
        public double PasH { get; set; } 
        /// <summary>
        /// (±Δ)PasH  
        /// </summary>
        public double PasDevH { get; set; } //PasDevH
        /// <summary>
        /// Горизонтальное расстояние между осью наклона стенда и центром опорного ролика
        /// </summary>
        public double PasL { get; set; } 
        /// <summary>
        /// (±Δ)PasL 
        /// </summary>
        public double PasDevL { get; set; } 
        /// <summary>
        /// Вертикальное расстояние между осью наклона стенда и центром опорного ролика
        /// </summary>
        public double PasQ { get; set; } 
        /// <summary>
        /// (±Δ)PasQ 
        /// </summary>
        public double PasDevQ { get; set; } 
        /// <summary>
        /// ±ΔР - погрешность измерение усилия датчиком дисбаланса
        /// </summary>
        public double PasDevPdisbal { get; set; } 
        /// <summary>
        /// ±ΔР - погрешность измерение усилия датчиком силы
        /// </summary>
        public double PasDevPpower { get; set; } 
        /// <summary>
        /// ±Δξ - Погрешность определения угла наклона стенда
        /// </summary>
        public double PasDevEpsilon { get; set; }
        /// <summary>
        /// ±ΔFi - Погрешность угла повотра 
        /// </summary>
        public double PasDevFi { get; set; }
        /// <summary>
        ///Горизонтальное расстояние между осью наклона стенда и осью подвеса грузов противовеса
        /// </summary>
        public double PasD { get; set; } //PasD = 2120
        /// <summary>
        /// (±Δ)PasD
        /// </summary>
        public double PasDevD { get; set; } //PasDevD
        /// <summary>
        /// Вертикальное расстояние между осью наклона стенда и осьюподвеса грузов противовеса
        /// </summary>
        public double PasE { get; set; } //PasE = 0
        /// <summary>
        /// (±Δ)PasE 
        /// </summary>
        public double PasDevE { get; set; } //PasDevE
        /// <summary>
        /// Подвижный груз
        /// </summary>
        public double PasMassPG { get; set; } //PasMasPG
        /// <summary>
        /// Отклонения подвижного груза
        /// </summary>
        public double PasDevMassPG { get; set; } //PasDevMasPG

        /////////////////////////////////////////////////////////////////////////AdapterParametrs
        /// <summary>
        /// Координаты переходника по оси Х
        /// </summary>
        public double PerX { get; set; } //PerX
        /// <summary>
        /// (±Δ)PerХ - допустимое отклонение переходника в системе координат переходника
        /// </summary>
        public double PerDevX { get; set; } //PerDevX
        /// <summary>
        /// Координаты переходника по оси Y
        /// </summary>
        public double PerY { get; set; } //PerY
        /// <summary>
        /// (±Δ)PerY - допустимое отклонение переходника в системе координат переходника 
        /// </summary>
        public double PerDevY { get; set; } //PerDevY
        /// <summary>
        /// Координаты переходника по оси Z
        /// </summary>
        public double PerZ { get; set; } //PerZ
        /// <summary>
        /// (±Δ)PerZ - допустимое отклонение переходника в системе координат переходника
        /// </summary>
        public double PerDevZ { get; set; } //PerDevX
        /// <summary>
        /// Масса переходника
        /// </summary>
        public double PerMas { get; set; } //PerMas
        /// <summary>
        /// (±Δ)PerMas - допустимое отклонение массы переходника 
        /// </summary>
        public double PerDevMas { get; set; } //PerDevMas
        /// <summary>
        /// Высота переходника 
        /// </summary>
        public double PerH { get; set; } //PerH
        /// <summary>
        /// (±Δ)PerH - допустимое отклонение длины переходника 
        /// </summary>
        public double PerDevH { get; set; } //PerDevH


        /////////////////////////////////////////////////////////////////////////KP_Parameters
        /// <summary>
        /// Координаты КП по Х
        /// </summary>
        public double KpX { get; set; } //KpX
        /// <summary>
        /// (±Δ)KpX
        /// </summary>
        public double KpDevX { get; set; } //KpDevX
        /// <summary>
        /// Координаты КП по Y
        /// </summary>
        public double KpY { get; set; } //KpY
        /// <summary>
        /// (±Δ)KpY
        /// </summary>
        public double KpDevY { get; set; } //KpDevY
        /// <summary>
        /// Координаты КП по Z
        /// </summary>
        public double KpZ { get; set; } //KpZ
        /// <summary>
        /// (±Δ)KpZ
        /// </summary>
        public double KpDevZ { get; set; } //KpDevZ
        /// <summary>
        /// Масса КП
        /// </summary>
        public double KpMas { get; set; } //KpMas
        /// <summary>
        /// (±Δ)KpMas
        /// </summary>
        public double KpDevMas { get; set; } //KpDevMas

        /// <summary>
        /// Угол поворота платформы
        /// </summary>
        public double Fi { get; set; }       

        ///////////////////////////////////////////////////////////////////////////////////////////// Данные из тарировки углов
        /// <summary>
        /// Δ - участвует в формуле для поправки углов (стд отклонение углов)
        /// </summary
        public double Dev { get; set; }


        /////////////////////////////////////////////////////////////////////////////////////////////Отклонение для ПОПРАВКИ во время расчета КМЦ
        public double DevX600 { get; set; }
        public double DevX6000 { get; set; }
        public double DevY600 { get; set; }
        public double DevY6000 { get; set; }
        public double DevZ600 { get; set; }
        public double DevZ6000 { get; set; }

        public bool Cargo { get; set; }
        public bool KP { get; set; }

    }
    public struct RecomValData
    {
        //___________________________________________________ Исходные данные
        /// <summary>
        /// Номинальное значение изделия по координате Х
        /// </summary>
        public double ProdX { get; set; }
        /// <summary>
        /// Номинальное отклонение изделия по координате Х
        /// </summary>
        public double ProdDevX { get; set; }
        /// <summary>
        /// Номинальное значение изделия по координате Y
        /// </summary>
        public double ProdY { get; set; }
        /// <summary>
        /// Номинальное отклонение изделия по координате Y
        /// </summary>
        public double ProdDevY { get; set; }
        /// <summary>
        /// Номинальное значение изделия по координате Z
        /// </summary>
        public double ProdZ { get; set; }
        /// <summary>
        /// Номинальное отклонение изделия по координате Z
        /// </summary>
        public double ProdDevZ { get; set; }
        /// <summary>
        /// Номинальная масса изделия
        /// </summary>
        public double ProdMas { get; set; }
        /// <summary>
        /// Номинальное отклонение массы изделия 
        /// </summary>
        public double ProdDevMas { get; set; }

        //___________________________________________________ Данные для расчета рекомендуемых значений       
        /// <summary>
        /// Угол наклона при нахождение КЦМ изделия
        /// </summary>
        public int EpsilonMa { get; set; }
        /// <summary>
        /// Угол наклона при нахождение М изделия
        /// </summary>
        public int EpsilonMm { get; set; }
        /// <summary>
        /// Эталонные значения массы корректирующих грузов при нахождения М
        /// </summary>
        public double[] ArrMasMa { get; set; }
        
        //// <summary>
        ///  Эталонные значения массы корректирующих грузов при при нахожденеи КЦМ
        /// </summary>
        public double[] ArrMasMm { get; set; }        

        //___________________________________________________ Рекомендуемые значения 
        /// <summary>
        /// Подходящая масса корректирующего груза для нахождения М
        /// </summary>
        public double Ma { get; set; }
        /// <summary>
        /// Подходящая масса корректирующего груза груза для нахождения КЦМ
        /// </summary>
        public double Mm { get; set; }
        /// <summary>
        /// Подходящий ∠ равновесия при нахождение КЦМ
        /// </summary>
        public double AngleKcm { get; set; }
        /// <summary>
        /// Подходящий ∠ равновесия при измерение массы изделия
        /// </summary>
        public double AngleMas { get; set; }
        /// <summary>
        /// Подходящий ∠ равновесия без использования грузов
        /// </summary>
        public double AngleNotMas { get; set; }

        public void DefaultInit()
        {
            ProdX = 0;
            ProdDevX = 0;
            ProdY = 0;
            ProdDevY = 0;
            ProdZ = 0;
            ProdDevZ = 0;      
            ProdMas = 0;
            ProdDevMas = 0;

            EpsilonMa = 16;
            EpsilonMm = 6;
        }
    }
    /// <summary>
    /// Данные от контроллера
    /// </summary>
    public struct ControllerDataOut
    {
        /// <summary>
        /// Положение домкрата
        /// </summary>
        public double JackPos { get; set; }
        /// <summary>
        /// Положение подвижного груза
        /// </summary>
        public double CargoPos { get; set; }
        /// <summary>
        /// Связь с устройством
        /// </summary>
        public double ConnectDevice { get; set; }
        /// <summary>
        /// Включение\ Выключение системы
        /// </summary>
        public double PowerSystem { get; set; }
        /// <summary>
        /// Включение\Выключение двигателя трения №1
        /// </summary>
        public double OutFrictionMotor1 { get; set; }
        /// <summary>
        /// Включение\Выключение двигателя трения №2
        /// </summary>
        public double OutFrictionMotor2 { get; set; }


        /// <summary>
        /// Датчик угловых перемещений
        /// </summary>
        public double SensorAngle { get; set; }
        /// <summary>
        /// Датчик дисбаланса
        /// </summary>
        public double SensorDisbalance { get; set; }
        /// <summary>
        /// Датчик силы измеретильной головки
        /// </summary>
        public double SensorPower { get; set; }
        /// <summary>
        /// Датчик линейного передвижения в начальной зоны работы 
        /// </summary>
        public double IndicationK { get; set; }
        /// <summary>
        /// Список ошибок
        /// </summary>
        public Dictionary<double, string> ErrorsList;

        public void DefaultInit()
        {
            JackPos = Defines.UNDEF_DBL_VALUE;
            CargoPos = Defines.UNDEF_DBL_VALUE;
            ConnectDevice = 0;
            PowerSystem = Defines.UNDEF_DBL_VALUE;
            OutFrictionMotor1 = Defines.UNDEF_DBL_VALUE;
            OutFrictionMotor2 = Defines.UNDEF_DBL_VALUE;
            SensorAngle = Defines.UNDEF_DBL_VALUE;
            SensorDisbalance  = Defines.UNDEF_DBL_VALUE;
            SensorPower = Defines.UNDEF_DBL_VALUE;
            IndicationK = Defines.UNDEF_DBL_VALUE;
            ErrorsList = new Dictionary<double, string>();
        }
    }
    /// <summary>
    /// Данные в контроллер
    /// </summary>
    public struct ControllerDataIn
    {
        /// <summary>
        /// Скорость движения домкрата
        /// </summary>
        public double SpeedCargo { get; set; }
        /// <summary>
        /// Скорость движения домкрата
        /// </summary>
        public double SpeedJack { get; set; }
        /// <summary>
        /// Ход домкрата влево
        /// </summary>
        public double GoJackUp { get; set; }
        /// <summary>
        /// Ход домкрата вправо
        /// </summary>
        public double GoJackDown { get; set; }
        /// <summary>
        /// Ход подвижного груза вправо
        /// </summary>
        public double GoCargoLeft { get; set; }
        /// <summary>
        /// Ход подвижного груза вправо
        /// </summary>
        public double GoCargoRight { get; set; }
        /// <summary>
        /// Включение двигателя трения №1
        /// </summary>
        public double OnFrictionMotor1 { get; set; }
        /// <summary>
        /// Включение двигателя трения №1
        /// </summary>
        public double OffFrictionMotor1 { get; set; }
        /// <summary>
        /// Включение двигателя трения №2
        /// </summary>
        public double OnFrictionMotor2 { get; set; }
        /// <summary>
        /// Включение двигателя трения №2
        /// </summary>
        public double OffFrictionMotor2 { get; set; }
        /// <summary>
        /// Сброс ошибок
        /// </summary>
        public double ResetErrors { get; set; }

    }
    /// <summary>
    /// Расчитанные данные
    /// </summary>
    public struct CalculatedData
    {
        public double RefK { get; set; }


        //Координаты Центра Масс (КЦМ)
        public double RES_X { get; set; }
        public double RES_Y { get; set; }
        public double RES_Z { get; set; }
        public double RES_M { get; set; }

        // КЦМ КП
        public double RES_Xkp { get; set; }
        public double RES_Ykp { get; set; }
        public double RES_Zkp { get; set; }
        public double RES_Mkp { get; set; }

        /// <summary>
        /// Средний угол равновесия - α
        /// </summary>
        public double AverageValue { get; set; }

        /// <summary>
        /// Поправка координат при определение КМЦ
        /// </summary>
        public double kcmDev { get; set; }

        /// <summary>
        /// Для тарировки углов
        /// </summary>
        public double Amendment { get; set; }

        /////////////////////////////////////////////////////////////////////////////////////////////Определение средних значений КЦМ и массы, и их отклонений 


        public List<double> BeginBalanceAngleArr0 { get; set; }
        public List<double> MiddleBalanceAngleArr0 { get; set; }
        public List<double> BeginDisbalanceSensorArr0 { get; set; }
        public List<double> MiddleDisbalanceSensorArr0 { get; set; }
        public List<double> BeginBalanceAngleArr90 { get; set; }
        public List<double> MiddleBalanceAngleArr90 { get; set; }
        public List<double> BeginDisbalanceSensorArr90 { get; set; }
        public List<double> MiddleDisbalanceSensorArr90 { get; set; }
        public List<double> BeginBalanceAngleArr180 { get; set; }
        public List<double> MiddleBalanceAngleArr180 { get; set; }
        public List<double> BeginDisbalanceSensorArr180 { get; set; }
        public List<double> MiddleDisbalanceSensorArr180 { get; set; }
        public List<double> BeginBalanceAngleArr270 { get; set; }
        public List<double> MiddleBalanceAngleArr270 { get; set; }
        public List<double> BeginDisbalanceSensorArr270 { get; set; }
        public List<double> MiddleDisbalanceSensorArr270 { get; set; }
        public List<double> BeginPowerSensor0 { get; set; }        
        public List<double> MiddlePowerSensor0 { get; set; }
        public List<double> BeginPowerSensor180 { get; set; }
        public List<double> MiddlePowerSensor180 { get; set; }
        public List<double> BeginIndicationK0 { get; set; }
        public List<double> MiddleIndicationK0 { get; set; }
        public List<double> BeginIndicationK180 { get; set; }
        public List<double> MiddleIndicationK180 { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////////Проверка углов
        /// <summary>
        /// Все углы заполнены 
        /// </summary>
        public bool AllAngelFilling { get; set; }
        /// <summary>
        /// Массивы находятся в процессе заполнения (для web отображения) 
        /// </summary>
        public bool ArraysAreFilling { get; set; }// 0 - массивы не заполнены, 1 - массивы заполены на половину, 2 - массивы заполнены полностью
        public int kcmAngel_0 { get; set; } 
        public int kcmAngel_90 { get; set; }
        public int kcmAngel_180 { get; set; }
        public int kcmAngel_270 { get; set; }
        public int mAngel_0 { get; set; }
        public int mAngel_180 { get; set; }

        //////////////////////////////////////////////// Итоговые значения для КП
        /// <summary>
        /// Разница
        /// </summary>
        public double _pX { get; set; }
        /// <summary>
        /// Разница
        /// </summary>
        public double _pY { get; set; }
        /// <summary>
        /// Разница
        /// </summary>
        public double _pZ { get; set; }
        /// <summary>
        /// Разница
        /// </summary>
        public double _pM { get; set; }
        /// <summary>
        /// Системные отклоениня после введения поправок
        /// </summary>
        public double SystemDevX { get; set; }
        /// <summary>
        /// Системные отклоениня после введения поправок
        /// </summary>
        public double SystemDevY { get; set; }
        /// <summary>
        /// Системные отклоениня после введения поправок
        /// </summary>
        public double SystemDevZ { get; set; }
        /// <summary>
        /// Системные отклоениня после введения поправок
        /// </summary>
        public double SystemDevM { get; set; }
        /// <summary>
        /// КЦМ изделия при использование метода замещения
        /// </summary>
        public double _kmcKPx { get; set; }
        /// <summary>
        /// КЦМ изделия при использование метода замещения
        /// </summary>
        public double _kmcKPy { get; set; }
        /// <summary>
        /// КЦМ изделия при использование метода замещения
        /// </summary>
        public double _kmcKPz { get; set; }
        /// <summary>
        /// КЦМ изделия при использование метода замещения
        /// </summary>
        public double _kmcKPm { get; set; }
        /// <summary>
        /// Системные погрешности изделия при использование КП
        /// </summary>
        public double SystemEerX { get; set; }
        /// <summary>
        /// Системные погрешности изделия при использование КП
        /// </summary>
        public double SystemEerY { get; set; }
        /// <summary>
        /// Системные погрешности изделия при использование КП
        /// </summary>
        public double SystemEerZ { get; set; }
        /// <summary>
        /// Системные погрешности изделия при использование КП
        /// </summary>
        public double SystemEerM { get; set; }
        /// <summary>
        /// Граница погрешности изделия при методе замещения
        /// </summary>
        public double GranKPx { get; set; }
        /// <summary>
        /// Граница погрешности изделия при методе замещения
        /// </summary>
        public double GranKPy { get; set; }
        /// <summary>
        /// Граница погрешности изделия при методе замещения
        /// </summary>
        public double GranKPz { get; set; }
        /// <summary>
        /// Граница погрешности изделия при методе замещения
        /// </summary>
        public double GranKPm { get; set; }

        public void DefaultInit()
        {
            BeginBalanceAngleArr0 = new();
            MiddleBalanceAngleArr0 = new();
            BeginDisbalanceSensorArr0 = new();
            MiddleDisbalanceSensorArr0 = new();
            BeginBalanceAngleArr90 = new();
            MiddleBalanceAngleArr90 = new();
            BeginDisbalanceSensorArr90 = new();
            MiddleDisbalanceSensorArr90 = new();
            BeginBalanceAngleArr180 = new();
            MiddleBalanceAngleArr180 = new();
            BeginDisbalanceSensorArr180 = new();
            MiddleDisbalanceSensorArr180 = new();
            BeginBalanceAngleArr270 = new();
            MiddleBalanceAngleArr270 = new();
            BeginDisbalanceSensorArr270 = new();
            MiddleDisbalanceSensorArr270 = new();
            BeginPowerSensor0 = new();
            MiddlePowerSensor0 = new();
            BeginPowerSensor180 = new();
            MiddlePowerSensor180 = new();
            BeginIndicationK0 = new();
            MiddleIndicationK0 = new();
            BeginIndicationK180 = new();
            MiddleIndicationK180 = new();
        }
    }

    public struct NSPData
    {
        public void DefaultInit()
        {
            //X1
            _devSx = 0.227193; _devHx = 0.030195; _devLx = 7.97E-10; _devQx = 4.517E-09; _devPx = 2.624E-06; _devEPSILx = 0.8533847; _devFIx = 0; _devXpx = 0.0101948; _devYpx = 0; _devZpx = 0; _devMpx = 0.0030387; _devHpx = 0.02; _devDx = 0.00564; _devEx = 0.00058; _devMAx = 0; _devMMx = 0; _devMASSx = 0;
            //Y1
            _devSy = 6.581E-05; _devHy = 0; _devLy = 6.63E-12; _devQy = 3.747E-11; _devPy = 2.658E-09; _devEPSILy = 0.0002378; _devFIy = 0.000393; _devXpy = 0; _devYpy = 0.0101948; _devZpy = 0; _devMpy = 2.995E-06; _devHpy = 0; _devDy = 5.6E-06; _devEy = 5.7E-07; _devMAy = 0; _devMMy = 0; _devMASSy = 0;
            //Z1
            _devSz = 0.0001483; _devHz = 0; _devLz = 5.51E-12; _devQz = 3.106E-11; _devPz = 1.738E-09; _devEPSILz = 0.0005358; _devFIz = 0.0002346; _devXpz = 0; _devYpz = 0; _devZpz = 0.0101948; _devMpz = 6.747E-06; _devHpz = 0; _devDz = 1.3E-05; _devEz = 1.3E-06; _devMAz = 0; _devMMz = 0; _devMASSz = 0;
            //M1
            _devSm = 0.2637498; _devHm = 0; _devLm = 3.456E-10; _devQm = 1.962E-09; _devPm = 3.167E-06; _devEPSILm = 0.954966; _devFIm = 0; _devXpm = 0; _devYpm = 0; _devZpm = 0; _devMpm = 0.012; _devHpm = 0; _devDm = 0.066; _devEm = 0.00682; _devMAm = 0; _devMMm = 0; _devMASSm = 0;
            //X2
            _devSx2 = -0.2227182; _devHx2 = -0.030195; _devLx2 = -7.97E-10; _devQx2 = -4.52E-09; _devPx2 = -2.62E-06; _devEPSILx2 = -0.852964; _devFIx2 = 0; _devXpx2 = -0.010195; _devYpx2 = 0; _devZpx2 = 0; _devMpx2 = -0.003039; _devHpx2 = -0.02; _devDx2 = -0.00564; _devEx2 = -0.00058; _devMAx2 = 0; _devMMx2 = 0; _devMASSx2 = 0;
            //Y2
            _devSy2 = -6.58E-05; _devHy2 = 0; _devLy2 = -6.58E-12; _devQy2 = -3.75E-11; _devPy2 = -2.66E-09; _devEPSILy2 = -0.000238; _devFIy2 = -0.000393; _devXpy2 = 0; _devYpy2 = -0.010195; _devZpy2 = 0; _devMpy2 = -2.99E-06; _devHpy2 = 0; _devDy2 = -5.6E-06; _devEy2 = -5.7E-07; _devMAy2 = 0; _devMMy2 = 0; _devMASSy2 = 0;
            //Z2
            _devSz2 = -0.000148277; _devHz2 = 0; _devLz2 = -5.43898E-12; _devQz2 = -3.10445E-11; _devPz2 = -1.73831E-09; _devEPSILz2 = -0.000535553; _devFIz2 = -0.000234616; _devXpz2 = 0; _devYpz2 = 0; _devZpz2 = -0.01019483; _devMpz2 = -6.74668E-06; _devHpz2 = 0; _devDz2 = -1.252E-05; _devEz2 = -1.295E-06; _devMAz2 = 0; _devMMz2 = 0; _devMASSz2 = 0;
            //M2
            _devSm2 = -0.263726; _devHm2 = 0; _devLm2 = -3.47E-10; _devQm2 = -1.96E-09; _devPm2 = -3.17E-06; _devEPSILm2 = -0.954979; _devFIm2 = 0; _devXpm2 = 0; _devYpm2 = 0; _devZpm2 = 0; _devMpm2 = -0.012; _devHpm2 = 0; _devDm2 = -0.066; _devEm2 = -0.00682; _devMAm2 = 0; _devMMm2 = 0; _devMASSm2 = 0;
            
        }
        /// <summary>
        /// Среднее значение Массы изделия для НСП
        /// </summary>
        public double AverProdValMas { get; set; }
        /// <summary>
        /// Среднее значение X изделия для НСП
        /// </summary>
        public double AverProdVal_X { get; set; }

        /// <summary>
        /// Среднее значение Y изделия для НСП
        /// </summary>
        public double AverProdVal_Y { get; set; }

        /// <summary>
        /// Среднее значение Z изделия для НСП
        /// </summary>
        public double AverProdVal_Z { get; set; }

        /// <summary>
        /// Среднеквадратичное отклонения средних арифм
        /// </summary>
        public double devMnsp { get; set; }
        /// <summary>
        /// Среднеквадратичное отклонения средних арифм
        /// </summary>
        public double devXnsp { get; set; }
        /// <summary>
        /// Среднеквадратичное отклонения средних арифм
        /// </summary>
        public double devYnsp { get; set; }
        /// <summary>
        /// Среднеквадратичное отклонения средних арифм
        /// </summary>
        public double devZnsp { get; set; }


        /////////////////////////////////////////////////////////////////////////////////////////////Определение NSP
        // - Граница суммарной не исключённой систематической погрешности c "+" Δθ=1,1√Σ(+Δi)2
        public double ErLimX1 { get; set; }
        public double ErLimY1 { get; set; }
        public double ErLimZ1 { get; set; }
        public double ErLimM1 { get; set; }
        // - Граница суммарной не исключённой систематической погрешности c "-" Δθ=1,1√Σ(-Δi)2
        public double ErLimX2 { get; set; }
        public double ErLimY2 { get; set; }
        public double ErLimZ2 { get; set; }
        public double ErLimM2 { get; set; }

        /// <summary>
        ///  Δθi - НСП(max)
        /// </summary>

        public double NSPmaxX { get; set; }
        public double NSPmaxY { get; set; }
        public double NSPmaxZ { get; set; }
        public double NSPmaxM { get; set; }


        /// <summary>
        /// СКО НСП - (Sθ) Средне квадратичное отклонение суммарных НСП
        /// </summary>
        public double ErLimSx { get; set; }
        public double ErLimSy { get; set; }
        public double ErLimSz { get; set; }
        public double ErLimSm { get; set; }

        /// <summary>
        /// Коэффициент Стьюдента 
        /// </summary>
        const double KF_t = 2.262;

        /// <summary>
        /// Весовой Коэффициент
        /// </summary>
        public double KvesX { get; set; }
        public double KvesY { get; set; }
        public double KvesZ { get; set; }
        public double KvesM { get; set; }

        /// <summary>
        /// Cсуммарное среднее квадратическое отклонение (СКОΣ)
        /// </summary>
        public double Sdev_reNsX { get; set; }
        public double Sdev_reNsY { get; set; }
        public double Sdev_reNsZ { get; set; }
        public double Sdev_reNsM { get; set; }

        /// <summary>
        /// Границы погрешности
        /// </summary>
        public double granX { get; set; }
        public double granY { get; set; }
        public double granZ { get; set; }
        public double granM { get; set; }
        public double _devSx { get; set; }
        public double _devHx { get; set; } 
        public double _devLx { get; set; } 
        public double _devQx { get; set; } 
        public double _devPx { get; set; }
        public double _devEPSILx { get; set; } 
        public double _devFIx { get; set; } 
        public double _devXpx { get; set; } 
        public double _devYpx { get; set; }
        public double _devZpx { get; set; } 
        public double _devMpx { get; set; } 
        public double _devHpx { get; set; } 
        public double _devDx { get; set; } 
        public double _devEx { get; set; } 
        public double _devMAx { get; set; } 
        public double _devMMx { get; set; }
        public double _devMASSx { get; set; }

        public double _devSy { get; set; }
        public double _devHy { get; set; } 
        public double _devLy { get; set; } 
        public double _devQy { get; set; } 
        public double _devPy { get; set; } 
        public double _devEPSILy { get; set; } 
        public double _devFIy { get; set; } 
        public double _devXpy { get; set; } 
        public double _devYpy { get; set; } 
        public double _devZpy { get; set; } 
        public double _devMpy { get; set; } 
        public double _devHpy { get; set; } 
        public double _devDy { get; set; } 
        public double _devEy { get; set; } 
        public double _devMAy { get; set; } 
        public double _devMMy { get; set; }
        public double _devMASSy { get; set; }

        public double _devSz { get; set; } 
        public double _devHz { get; set; } 
        public double _devLz { get; set; } 
        public double _devQz { get; set; } 
        public double _devPz { get; set; } 
        public double _devEPSILz { get; set; } 
        public double _devFIz { get; set; } 
        public double _devXpz { get; set; } 
        public double _devYpz { get; set; } 
        public double _devZpz { get; set; } 
        public double _devMpz { get; set; } 
        public double _devHpz { get; set; } 
        public double _devDz { get; set; } 
        public double _devEz { get; set; } 
        public double _devMAz { get; set; }
        public double _devMMz { get; set; }
        public double _devMASSz { get; set; }

        public double _devSm { get; set; } 
        public double _devHm { get; set; } 
        public double _devLm { get; set; }
        public double _devQm { get; set; } 
        public double _devPm { get; set; }
        public double _devEPSILm { get; set; } 
        public double _devFIm { get; set; }
        public double _devXpm { get; set; } 
        public double _devYpm { get; set; } 
        public double _devZpm { get; set; } 
        public double _devMpm { get; set; } 
        public double _devHpm { get; set; } 
        public double _devDm { get; set; } 
        public double _devEm { get; set; } 
        public double _devMAm { get; set; } 
        public double _devMMm { get; set; }
        public double _devMASSm { get; set; }

        public double _devSx2 { get; set; }
        public double _devHx2 { get; set; } 
        public double _devLx2 { get; set; } 
        public double _devQx2 { get; set; } 
        public double _devPx2 { get; set; } 
        public double _devEPSILx2 { get; set; } 
        public double _devFIx2 { get; set; } 
        public double _devXpx2 { get; set; }
        public double _devYpx2 { get; set; } 
        public double _devZpx2 { get; set; } 
        public double _devMpx2 { get; set; } 
        public double _devHpx2 { get; set; } 
        public double _devDx2 { get; set; } 
        public double _devEx2 { get; set; } 
        public double _devMAx2 { get; set; } 
        public double _devMMx2 { get; set; }
        public double _devMASSx2 { get; set; }

        public double _devSy2 { get; set; } 
        public double _devHy2 { get; set; } 
        public double _devLy2 { get; set; } 
        public double _devQy2 { get; set; } 
        public double _devPy2 { get; set; } 
        public double _devEPSILy2 { get; set; } 
        public double _devFIy2 { get; set; }
        public double _devXpy2 { get; set; } 
        public double _devYpy2 { get; set; } 
        public double _devZpy2 { get; set; }
        public double _devMpy2 { get; set; }
        public double _devHpy2 { get; set; }
        public double _devDy2 { get; set; } 
        public double _devEy2 { get; set; }
        public double _devMAy2 { get; set; } 
        public double _devMMy2 { get; set; }
        public double _devMASSy2 { get; set; }

        public double _devSz2 { get; set; }
        public double _devHz2 { get; set; }
        public double _devLz2 { get; set; }
        public double _devQz2 { get; set; } 
        public double _devPz2 { get; set; } 
        public double _devEPSILz2 { get; set; }
        public double _devFIz2 { get; set; } 
        public double _devXpz2 { get; set; } 
        public double _devYpz2 { get; set; } 
        public double _devZpz2 { get; set; } 
        public double _devMpz2 { get; set; } 
        public double _devHpz2 { get; set; } 
        public double _devDz2 { get; set; } 
        public double _devEz2 { get; set; }
        public double _devMAz2 { get; set; } 
        public double _devMMz2 { get; set; }
        public double _devMASSz2 { get; set; }

        public double _devSm2 { get; set; } 
        public double _devHm2 { get; set; } 
        public double _devLm2 { get; set; } 
        public double _devQm2 { get; set; }
        public double _devPm2 { get; set; } 
        public double _devEPSILm2 { get; set; } 
        public double _devFIm2 { get; set; } 
        public double _devXpm2 { get; set; } 
        public double _devYpm2 { get; set; } 
        public double _devZpm2 { get; set; } 
        public double _devMpm2 { get; set; } 
        public double _devHpm2 { get; set; } 
        public double _devDm2 { get; set; } 
        public double _devEm2 { get; set; }
        public double _devMAm2 { get; set; } 
        public double _devMMm2 { get; set; }
        public double _devMASSm2 { get; set; }
    }

    public struct MeasurementDataOut
    {
        /// <summary>
        /// Запуск расчета
        /// </summary>
        public bool CalculationCalc { get; set; }
        /// <summary>
        /// Угол поворота платформы
        /// </summary>
        public double Fi { get; set; }
        /// <summary>
        /// Показание для КЦМ - true \ Массы - false
        /// </summary>
        public bool findCoordMass { get; set; }
        /// <summary>
        /// Контрольное приспособление 
        /// </summary>
        public bool KP { get; set; }
    }


    /// <summary>
    /// обработка полученных данных
    /// </summary>
    public class ReceivedData
    {
        //public CalculatedData CalculatedData { get; set; }
        public ControllerDataOut ControllerDataOut;
        public ControllerDataIn ControllerDataIn;
        public PassportData PassportData;
        public NSPData NSPData;
        public RecomValData RecomValData;
        public MeasurementDataOut MeasurementData;

    }
    /// <summary>
    /// Ошибки
    /// </summary>
    public class Errors
    {
        /// <summary>
        /// Ошибки контроллера
        /// </summary>
        private List<double> ControllerErrors;
        private List<ErrorsTable> ErrorsList;
        private string FileName { get; }
        /// <summary>
        /// Описание ошибок
        /// </summary>
        public class ErrorsTable
        {
            /// <summary>
            /// Номер ошибки
            /// </summary>
            public double Number { get; set; }
            /// <summary>
            /// Описание ошибки
            /// </summary>
            public string Text { get; set; }
        }
        public sealed class ErrorsTableMap : ClassMap<ErrorsTable>
        {
            public ErrorsTableMap()
            {
                Map(x => x.Number).Name("Number");
                Map(x => x.Text).Name("Text");
            }
        }

        public Errors()
        {
            ControllerErrors = new();
            FileName = Directory.GetCurrentDirectory() + "\\" + "Errors.csv";
            ErrorsList = ReadErrorsListFile(FileName);

        }
        public bool IsErrorListExists()
        {
            return ErrorsList != null;
        }
        /// <summary>
        /// Очистить все ошибки
        /// </summary>
        public void ClearAllErrors()
        {
            ControllerErrors.Clear();
        }
        /// <summary>
        /// Получить количество ошибок
        /// </summary>
        /// <returns></returns>
        public int GetErrorsNumber()
        {
            return ControllerErrors.Count;
        }
        /// <summary>
        /// Добавить новую ошибку контроллера
        /// </summary>
        /// <param name="errNumber"></param>
        public void AddNewControllerError(double errNumber)
        {
            double result = ControllerErrors.Find(x => x == errNumber);
            if(errNumber == 998) // reset от контроллера
            {
                ControllerErrors.Clear();
            }
            else if(result == 0 && errNumber != 0 && errNumber != Defines.UNDEF_DBL_VALUE)
            {
                ControllerErrors.Add(errNumber);
            }
        }
        public Dictionary<double,string> GetDictErrorList()
        {
            Dictionary<double, string> tempList = new();

            foreach(double i in ControllerErrors)
            {
                ErrorsTable result = ErrorsList?.Find(x => x.Number == i);
                if (result == null)
                {
                    tempList.Add(i, "Нет описания ошибки");
                }
                else
                {
                    tempList.Add(result.Number, result.Text);
                }
            }
            
            return tempList;
        }
        /// <summary>
        /// Считать описание ошибок из файла
        /// </summary>
        private List<ErrorsTable> ReadErrorsListFile(string location)
        {
            try
            {
                using (var reader = new StreamReader(location, Encoding.UTF8))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<ErrorsTableMap>();
                    var records = csv.GetRecords<ErrorsTable>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                return null;
               // throw new Exception(e.Message);
            }
        }
    }

}





