﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_KYA_Common
{
    public class ConfigHelper
    {
        public static string GetValue(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
