using System;
using System.Collections.Generic;
using System.Text;

namespace Vindi
{
    class Configuration
    {
        public Configuration(string urlApi, int version, string authorization) {
            UrlApi = urlApi;
            Version = version;
            Authorization = authorization;
        }

        public string UrlApi { get; }
        public int Version { get; }
        public string Authorization { get; }
    }
}
