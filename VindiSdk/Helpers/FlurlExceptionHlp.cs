using Flurl.Http;
using System;
using System.Net.Http;

namespace VindiSdk.Helpers
{
    public class FlurlExceptionHlp
    {
        public String ConvertToString(FlurlHttpException Except) {
            String Result = "";
            String ErrantJsonContent = "";

            Result = Except.GetResponseStringAsync().GetAwaiter().GetResult();
            HttpContent res2 = Except.Call.Response.Content;
            ErrantJsonContent = res2.ReadAsStringAsync().Result;

            if (Result != ErrantJsonContent) {
                Result += " ContentErrantJson: " + ErrantJsonContent;
            }

            Result = Result.Replace(":[{", "");
            Result = Result.Replace("{", "");
            Result = Result.Replace("}]}", "");
            Result = Result.Replace("}", "");
            Result = Result.Replace('"', ' ');
            Result = Result.Replace(":", "");
            Result = Result.Replace(",", "");
            Result = Result.Replace("errors", "Parâmetros Invalidos: ");
            Result = Result.Replace("invalid_parameter", "");
            Result = Result.Replace("parameter", "");
            Result = Result.Replace("message", "");
            Result = Result.Replace(" id ", "\n");
            Result = Result.Replace("   ", " ");
            Result = Result.Replace("  ", " ");
            
            Result = Result.Trim();

            return Result;
        }

        public String ConvertToJson(FlurlHttpException Except) {
            String Result = "";
            String ErrantJsonContent = "";

            Result = Except.GetResponseStringAsync().GetAwaiter().GetResult();
            
            HttpContent res2 = Except.Call.Response.Content;
            ErrantJsonContent = res2.ReadAsStringAsync().Result;
            if (Result != ErrantJsonContent) {
                Result += " ContentErrantJson: " + ErrantJsonContent;
            }

            return Result;
        }

    }
}
