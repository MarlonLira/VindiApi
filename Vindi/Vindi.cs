namespace Vindi {
    class Vindi {

        #region Configs

        private Configuration Config = new Configuration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk");
        private Service Service;

        #endregion

        #region Methods

        public dynamic GetByAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result = "";

            Result = Service.GetByAnythingAsync(Entitie).GetAwaiter().GetResult();

            return Result;
        }

        public dynamic CreateAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result = "";

            Result = Service.CreateAnythingAsync(Entitie).GetAwaiter().GetResult();

            return Result;
        }

        public dynamic UpdateAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result = "";

            Result = Service.UpdateAnythingAsync(Entitie).GetAwaiter().GetResult();

            return Result;
        }

        public dynamic DeleteAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result = "";

            Result = Service.DeleteAnythingAsync(Entitie).GetAwaiter().GetResult();

            return Result;
        }

        #endregion
    }
}
