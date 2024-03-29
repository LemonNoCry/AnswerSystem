﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnswerSystem.Helper
{
    class LogHelper
    {
        static LogHelper()
        {
            if (!System.IO.Directory.Exists(AppSetting.path + "\\logs"))
            {
                System.IO.Directory.CreateDirectory(AppSetting.path + "\\logs");
            }
        }
        public static void writeLog(string position, string message, params string[] paras)
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            List<string> mesList = new List<string>();
            mesList.Add("");
            mesList.Add("");
            mesList.Add("**************************" + position + DateTime.Now.ToString() + "*************************");
            if (paras != null)
            {
                for (var i = 0; i < paras.Length; i++)
                {
                    mesList.Add("Paramter " + i.ToString() + ":" + paras[i]);
                }
            }
            mesList.Add(message);
            mesList.Add("**************************************************************************************");

            File.AppendAllLines(AppSetting.path + "\\logs\\" + fileName, mesList, Encoding.UTF8);
        }

        public static void writeLog(Exception ex)
        {
            writeLog("Exception", ex.ToString(), null);
        }
    }
}
