﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Инициализация БД с параметрами по-умолчанию
    /// </summary>
    public class InitDBData
    {
        public static void Initialize(DataContext context)
        {
            //Параметры
            if (!context.Options.Any())
            {
                context.Options.Add(
                    new OptionsData
                    {
                        OptionsData1 = 1,
                        OptionsData2 = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
