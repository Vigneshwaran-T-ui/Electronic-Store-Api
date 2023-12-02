using System;
using System.IO;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Serilog;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Electronic_Store_Api.Services;
using Microsoft.AspNetCore.Authorization;
using Electronic_Store_Api.DataModels;
using Electronic_Store_Api.ViewModels;


namespace Electronic_Store_Api.Common
{
    public class TraceLog
    {
        private static Serilog.ILogger _logger;

        public static void LogActivity(string activityType, long userId, string userName, RouteData routeData, string serviceName, string inputParams)
        {
            JObject jObject = JObject.Parse(File.ReadAllText(Environment.CurrentDirectory + "/appsettings.json"));
            long logFileSizeLimitBytes = (Int64)jObject["Logging"]["LogFileSizeLimitBytes"];

            if (_logger == null)
            {
                var configuration = new ConfigurationBuilder()
                                    .AddJsonFile(Environment.CurrentDirectory + "/appsettings.json", optional: false, reloadOnChange: true)
                                    .Build();

                _logger = new LoggerConfiguration()
                .WriteTo.File(configuration["Logging:LogPath"], rollOnFileSizeLimit: true, fileSizeLimitBytes: logFileSizeLimitBytes, rollingInterval: RollingInterval.Day, retainedFileCountLimit: null)
                .CreateLogger();
            }

            if (activityType.Contains(ConstantProp.controllerIn))
            {
                _logger.Information(ConstantProp.controllerIn + " " + Convert.ToString(routeData.Values["controller"]) + "-" + Convert.ToString(routeData.Values["action"]) + " " + Convert.ToString(routeData.Values["controller"]) + "-" + Convert.ToString(routeData.Values["action"]) + "-START-" + DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss") + " UserPK:" + Convert.ToString(userId) + " UserID:" + userName + " InputParams:" + "Null" + " Error:" + "Null");

            }
            else if (activityType.Contains(ConstantProp.serviceIn))
            {
                _logger.Information(ConstantProp.serviceIn + " " + serviceName + " " + serviceName + "-START-" + DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss") + " UserPK:" + Convert.ToString(userId) + " UserID:" + userName + " InputParams:" + inputParams + " Error:" + "Null");
            }

            if (activityType.Contains(ConstantProp.serviceOut))
            {
                _logger.Information(ConstantProp.serviceOut + " " + serviceName + " " + serviceName + "-END-" + DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss") + " UserPK:" + Convert.ToString(userId) + " UserID:" + userName + " InputParams:" + inputParams + " Error:" + "Null");
            }

            if (activityType.Contains(ConstantProp.controllerOut))
            {
                _logger.Information(ConstantProp.controllerOut + " " + Convert.ToString(routeData.Values["controller"]) + "-" + Convert.ToString(routeData.Values["action"]) + " " + Convert.ToString(routeData.Values["controller"]) + "-" + Convert.ToString(routeData.Values["action"]) + "-END-" + DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss") + " UserPK:" + Convert.ToString(userId) + " UserID:" + userName + " InputParams:" + "Null" + " Error:" + "Null");
            }
        }
        public static void LogError(string userId, string userName, string serviceName, Exception ex, string inputParams)
        {
            JObject jObject = JObject.Parse(File.ReadAllText(Environment.CurrentDirectory + "/appsettings.json"));
            long logFileSizeLimitBytes = (Int64)jObject["Logging"]["LogFileSizeLimitBytes"];

            if (_logger == null)
            {
                var configuration = new ConfigurationBuilder()
                                    .AddJsonFile(Environment.CurrentDirectory + "/appsettings.json", optional: false, reloadOnChange: true)
                                    .Build();

                _logger = new LoggerConfiguration()
                .WriteTo.File(configuration["Logging:LogPath"], rollOnFileSizeLimit: true, fileSizeLimitBytes: logFileSizeLimitBytes, rollingInterval: RollingInterval.Day, retainedFileCountLimit: null)
                .CreateLogger();
            }

            string restrictedToMinimumLevel = (string)jObject["Serilog"]["WriteTo"][0]["Args"]["restrictedToMinimumLevel"];

            string errorText = "Data:" + ex.Data + "InnerException:" + ex.InnerException + "Message:" + ex.Message + "StackTrace:" + ex.StackTrace;

            _logger.Error(ConstantProp.serviceIn + " " + serviceName + " " + serviceName + "-START-" + DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss") + " UserPK:" + Convert.ToString(userId)
                + " UserID:" + userName + " InputParams:" + inputParams + " Error:" + "" + errorText.Replace(" ", "-").Replace(Environment.NewLine, "") + "");

            _logger.Error(ConstantProp.serviceOut + " " + serviceName + " " + serviceName + "-END-" + DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss") + " UserPK:" + Convert.ToString(userId) + " UserID:" + userName + " InputParams:" + inputParams + " Error:" + "Null");

        }

        public static string appendSingleObject(dynamic inputParam)
        {
            var vInputParam = inputParam;

            var result = new RouteValueDictionary(vInputParam);
            string inputParamText = "";

            foreach (var item in (dynamic)result)
            {
                inputParamText += item.Key + ":" + item.Value + ",";
            }
            inputParamText = inputParamText.Remove(inputParamText.Length - 1, 1);
            inputParamText = inputParamText.Replace(" ", "$");
            return inputParamText;
        }

        public static string appendListObject(dynamic inputParam)
        {
            string inputParamText = "";
            for (int i = 0; i <= inputParam.Count - 1; i++)
            {
                var vInputParam = inputParam[i];
                var result = new RouteValueDictionary(vInputParam);
                foreach (var item in (dynamic)result)
                {
                    inputParamText += item.Key + ":" + item.Value + ",";
                }
                inputParamText = inputParamText.Remove(inputParamText.Length - 1, 1);
                inputParamText = inputParamText + ";";
            }
            inputParamText = inputParamText.Remove(inputParamText.Length - 1, 1);
            inputParamText = inputParamText.Replace(" ", "$");
            return inputParamText;
        }
        public static void LogRequest(string logPath, string operation, string request)
        {
            string strRequestPath = string.Empty;
            string strFilename = string.Empty;

            logPath = logPath + "\\" + operation + "\\Request\\";

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            strFilename = DateTime.Now.ToString("yyyyddMM-hhmm-ssfff") + ".txt";
            string FilePath = logPath + "\\" + strFilename;

            string strlog = "--------------------- REQUEST ------------------------\r\n";

            strlog += request + "\r\n";

            File.WriteAllText(FilePath, strlog);
        }

        public static void LogResponse(string logPath, string operation, string response)
        {
            string strRequestPath = string.Empty;
            string strFilename = string.Empty;

            logPath = logPath + "\\" + operation + "\\Response\\";

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            strFilename = DateTime.Now.ToString("yyyyddMM-hhmm-ssfff") + ".txt";
            string FilePath = logPath + "\\" + strFilename;

            string strlog = "--------------------- RESPONSE ------------------------\r\n";

            strlog += response + "\r\n";

            File.WriteAllText(FilePath, strlog);
        }
    }
}