namespace Vindi
{
    public class Configuration
    {
        #region Constructor

        public Configuration(string urlApi, int version, string authorization) {
            UrlApi = urlApi;
            Version = version;
            Authorization = authorization;
        }

        #endregion

        #region Atributes

        public string UrlApi { get; set; }
        public int Version { get; set; }
        public string Authorization { get; set; }

        #endregion
    }
}
