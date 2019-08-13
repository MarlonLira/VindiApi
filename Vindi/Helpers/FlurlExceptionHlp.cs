using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Vindi.Models;

namespace Vindi.Helpers
{
    class FlurlExceptionHlp
    {
        public String ConvertToString(FlurlHttpException Except) {
            Error NewError;
            String Result = "";
            String ErrantJsonContent = "";

            Result = Except.GetResponseStringAsync().GetAwaiter().GetResult();

            #region Testes Obsoleto
            NewError = JsonConvert.DeserializeObject<Error>(Result);
            var result = JsonConvert.DeserializeObject<dynamic>(Result);
            List<Error> myDeserializedObjList = (List<Error>)JsonConvert.DeserializeObject(Result, typeof(List<Error>));
            HttpContent res2 = Except.Call.Response.Content;
            ErrantJsonContent = res2.ReadAsStringAsync().Result;
            NewError = JsonConvert.DeserializeObject<Error>(ErrantJsonContent);
            #endregion

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
            Result = Result.Replace("errors", "parâmetros Invalidos: ");
            Result = Result.Replace("invalid_parameter", "");
            Result = Result.Replace("parameter", "");
            Result = Result.Replace("message", "");
            //Result = Result.Replace("id", "");
            Result = Result.Replace("  ", " ");
            Result = Result.Replace("   ", " ");
            Result = Result.Replace("  ", " ");
            Result.Trim();

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
