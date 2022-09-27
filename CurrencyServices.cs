namespace SystemIO
{
    /// <summary>
    /// Disposable DesignPattern
    /// </summary>
    class CurrencyServices : IDisposable
    {
        private readonly HttpClient httpClient;
        private bool _disposed = false;
        public CurrencyServices()
        {
            httpClient = new HttpClient();
        }
        public string GetCurrencies()
        {
            string url = "https://coinbase.com/api/v2/currencies";
            var result = httpClient.GetStringAsync(url).Result;
            return result;
        }

        ~CurrencyServices()
        {
            Dispose(false);
        }
        /// <summary>
        /// disposing : true (dispose managed + unmanaged)      
        /// disposing : false (dispose unmanaged + large fields)
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            // Dispose Logic
            if (disposing)
                httpClient.Dispose(); // dispose managed resouces

            // unmanaged object
            // set large fields to null
            _disposed = true;
        }
        public void Dispose()
        {
            // dipose() is called 100%
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}