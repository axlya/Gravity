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
        /// Координаты центра масс переходника в системе координат переходника
        /// </summary>
        public double Xper { get; set; }
        /// <summary>
        /// (±Δ)Хper - допустимое отклонение КЦМ переходника в системе координат переходника
        /// </summary>
        public double DevХper { get; set; }
        /// <summary>
        /// Координаты центра масс переходника в системе координат переходника
        /// </summary>
        public double Yper { get; set; }
        /// <summary>
        /// (±Δ)Yper - допустимое отклонение КЦМ переходника в системе координат переходника 
        /// </summary>
        public double DevYper { get; set; }
        /// <summary>
        /// Координаты центра масс переходника в системе координат переходника
        /// </summary>
        public double Zper { get; set; }
        /// <summary>
        /// (±Δ)Zper - допустимое отклонение КЦМ переходника в системе координат переходника
        /// </summary>
        public double DevZper { get; set; }
        /// <summary>
        /// масса переходника
        /// </summary>
        public double MassPer { get; set; }
        /// <summary>
        /// (±Δ)_m_per - допустимое отклонение массы переходника 
        /// </summary>
        public double DevMassPer { get; set; }
        /// <summary>
        /// высота переходника 
        /// </summary>
        public double Hper { get; set; }
        /// <summary>
        /// (±Δ)_h_p - допустимое отклонение длины переходника 
        /// </summary>
        public double DevHPer { get; set; }


        /////////////////////////////////////////////////////////////////////////KP_Parameters
        /// <summary>
        /// Координаты КП
        /// </summary>
        public double Xkp { get; set; }
        /// <summary>
        /// (±Δ)Xkp - допустимое отклонение
        /// </summary>
        public double DevXkp { get; set; }
        /// <summary>
        /// Координаты КП
        /// </summary>
        public double Ykp { get; set; }
        /// <summary>
        /// (±Δ)Ykp - допустимое отклонение
        /// </summary>
        public double DevYkp { get; set; }
        /// <summary>
        /// Координаты КП
        /// </summary>
        public double Zkp { get; set; }
        /// <summary>
        /// (±Δ)Zkp - допустимое отклонение
        /// </summary>
        public double DevZkp { get; set; }
        /// <summary>
        /// Координаты КП по Y
        /// </summary>
        public double MassKp { get; set; }
        /// <summary>
        /// (±Δ)_m_kp  - допустимое отклонение массы КП
        /// </summary>
        public double DevMassKp { get; set; }

        /////////////////////////////////////////////////////////////////////////ProductParameters
        /// <summary>
        /// Масса изделия
        /// </summary>
        public double MassProd { get; set; }
        /// <summary>
        /// Координаты изделия по КД
        /// </summary>
        public double Xprod { get; set; }
        /// <summary>
        /// Координаты изделия по КД
        /// </summary>
        public double Yprod { get; set; }
        /// <summary>
        /// Координаты изделия по КД
        /// </summary>
        public double Zprod { get; set; }
        /// <summary>
        /// Номинальное отклонение массы изделия 
        /// </summary>
        public double Fi { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////// Reference_ma
        public double[] ArrRef_ma { get; set; }
        /// <summary>
        /// DevArrRef_ma - допустипое отклонение эталонной массы подвижного груза  (4 элемента массива))
        /// </summary>
        public double[] DevArrRef_ma { get; set; }
        /// <summary>
        /// Для наклона стенда при подвижном грузе 
        /// </  summary>
        public double Epsilon_ma { get; set; }
        //// <summary>
        /// Массив эталоной массы груза - разгрузки (4 элемента массива)
        /// </summary>
        public double[] ArrRef_mm { get; set; }
       
        /// <summary>
        /// DevArrRef_ma - допустипое отклонение эталонной массы груза - разгрузки
        /// </summary>
        public double[] DevArrRef_mm { get; set; }
        /// <summary>
        /// Для наклона стенда при использование груза - разгрузки
        /// </  summary>
        public double Epsilon_mm { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////// Данные из тарировки углов
        /// <summary>
        /// Подходящий ∠ равновесия без использования грузов
        /// </summary>
        public double AngleNotMas { get; set; }

        public bool Cargo { get; set; }

            EpsilonMa = 16;
            EpsilonMm = 6;
        }
    }
    public struct ControllerData
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
        public double BeginUnbalanceSensor { get; set; } // Получаем 6 раз, по 10 значений – с ma 0⁰/90⁰/180⁰/270⁰ и с mm 0⁰/90⁰
        /// <summary>
        ///  Датчик дисбаланса в средней зоне работы
        /// </summary>
        public double MiddleUnbalanceSensor { get; set; } // Получаем 6 раз, по 10 значений – с ma 0⁰/90⁰/180⁰/270⁰ и с mm 0⁰/90⁰
        /// <summary>
        /// Расстояния от оси поворота стола до известных координат центра тяжести груза
        /// </summary>
        public double K1 { get; set; }
        /// <summary>
        /// Расстояния от оси поворота стола до известных координат центра тяжести груза
        /// </summary>
        public double K2 { get; set; }
        public double P1 { get; set; } // Какие-то датчики
        public double P2 { get; set; } // Какие-то датчики
    }
    /// <summary>
    /// Расчитанные данные
    /// </summary>
    public struct CalculatedData
    {
        /// <summary>
        /// Подходящий груз-разгрузки
        /// </summary>
        public double Result_mm { get; set; }

        /// <summary>
        /// Подходящий α угол наклона при грузе-разгрузки
        /// </summary>
        public double RefAngle_mm { get; set; }

        /// <summary>
        /// Подходящий подвижный груз
        /// </summary>
        public double Result_ma { get; set; }

        /// <summary>
        /// Подходящий α угол наклона при подвижном грузе
        /// </summary>
        public double RefAngle_ma { get; set; }

        /// <summary>
        /// Подходящий угол наклона без грузов
        /// </summary>
        public double A_not { get; set; }

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
        public double DevPlane_xOy { get; set; }

        /// <summary>
        /// Отклоления в плоскости xOz -> 3 значения будут => Градусы \ Минуты \ Секунды
        /// </summary>
        public double DevPlane_xOz { get; set; }
        //_____________________________________________________________________________________________________________________________________________________________________________________________
        //Нужно еще сделать диаграммы на каждый угол 0°\90°\180... для КП тоже самое... диаграммы одинаковые. (По значениям эталонного угла, углов равновессия и среднего значения углов равновесия)!!!
        //_____________________________________________________________________________________________________________________________________________________________________________________________


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
        public double AverageValue { get; set; } // Нужно для 90°\180°\270° - сделать, а так же для груза-разгрузки и КП

        /// <summary>
        /// Поправка координат при определение КМЦ
        /// </summary>
        public double kcmDev { get; set; }

        /// <summary>
        /// Для тарировки углов
        /// </summary>
        public double Amendment { get; set; }


        /////////////////////////////////////////////////////////////////////////////////////////////Определение средних значений КЦМ и массы, и их отклонений 
        /// <summary>
        /// Среднее значение Массы изделия
        /// </summary>
        public double AverProdValMas { get; set; }

        /// <summary>
        /// Среднее значение X
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
    }


    /// <summary>
    /// обработка полученных данных
    /// </summary>
    public class ReceivedData
    {
        //public CalculatedData CalculatedData { get; set; }
        public ControllerData ControllerData { get; set; }
        public PassportData PassportData { get; set; }
        public NSPData NSPData { get; set; }
        

    }
    /// <summary>
    /// Ошибки
    /// </summary>
    public class Errors
    {
        /// <summary>
        /// Ошибки контроллера
        /// </summary>
        public List<double> beginBalanceAngleArr0;
        public List<double> beginBalanceAngleArr0_2;
        public List<double> beginBalanceAngleArr90;
        public List<double> beginBalanceAngleArr180;
        public List<double> beginBalanceAngleArr180_2;
        public List<double> beginBalanceAngleArr270;

        /// <summary>
        /// Описание ошибок
        /// </summary>
        public List<double> MiddleBalanceAngleArr0;
        public List<double> MiddleBalanceAngleArr0_2;
        public List<double> MiddleBalanceAngleArr90;
        public List<double> MiddleBalanceAngleArr180;
        public List<double> MiddleBalanceAngleArr180_2;
        public List<double> MiddleBalanceAngleArr270;

        /// <summary>
        /// Датчик дисбаланса в начальной зоне работы
        /// </summary>
        public List<double> BeginUnbalanceSensorArr0;
        public List<double> BeginUnbalanceSensorArr0_2;
        public List<double> BeginUnbalanceSensorArr90;
        public List<double> BeginUnbalanceSensorArr180;
        public List<double> BeginUnbalanceSensorArr180_2;
        public List<double> BeginUnbalanceSensorArr270;

        /// <summary>
        /// Датчик дисбаланса в средней зоне работы
        /// </summary>
        public List<double> MiddleUnbalanceSensorArr0;
        public List<double> MiddleUnbalanceSensorArr0_2;
        public List<double> MiddleUnbalanceSensorArr90;
        public List<double> MiddleUnbalanceSensorArr180;
        public List<double> MiddleUnbalanceSensorArr180_2;
        public List<double> MiddleUnbalanceSensorArr270;




        public Errors()
        {
            beginBalanceAngleArr0 = new();
            beginBalanceAngleArr0_2 = new();
            beginBalanceAngleArr90 = new();
            beginBalanceAngleArr180 = new();
            beginBalanceAngleArr180_2 = new();
            beginBalanceAngleArr270 = new();

            MiddleBalanceAngleArr0 = new();
            MiddleBalanceAngleArr0_2 = new();
            MiddleBalanceAngleArr90 = new();
            MiddleBalanceAngleArr180 = new();
            MiddleBalanceAngleArr180_2 = new();
            MiddleBalanceAngleArr270 = new();

            BeginUnbalanceSensorArr0 = new();
            BeginUnbalanceSensorArr0_2 = new();
            BeginUnbalanceSensorArr90 = new();
            BeginUnbalanceSensorArr180 = new();
            BeginUnbalanceSensorArr180_2 = new();
            BeginUnbalanceSensorArr270 = new();

            MiddleUnbalanceSensorArr0 = new();
            MiddleUnbalanceSensorArr0_2 = new();
            MiddleUnbalanceSensorArr90 = new();
            MiddleUnbalanceSensorArr180 = new();
            MiddleUnbalanceSensorArr180_2 = new();
            MiddleUnbalanceSensorArr270 = new();
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
            beginBalanceAngleArr0.Clear(); 
            beginBalanceAngleArr90.Clear();
            beginBalanceAngleArr180.Clear();
            beginBalanceAngleArr270.Clear();

            MiddleBalanceAngleArr0.Clear();
            MiddleBalanceAngleArr90.Clear();
            MiddleBalanceAngleArr180.Clear();
            MiddleBalanceAngleArr270.Clear();

            BeginUnbalanceSensorArr0.Clear();
            BeginUnbalanceSensorArr90.Clear();
            BeginUnbalanceSensorArr180.Clear();
            BeginUnbalanceSensorArr270.Clear();

            MiddleUnbalanceSensorArr0.Clear();
            MiddleUnbalanceSensorArr90.Clear();
            MiddleUnbalanceSensorArr180.Clear();
            MiddleUnbalanceSensorArr270.Clear();
        }
    }

}





