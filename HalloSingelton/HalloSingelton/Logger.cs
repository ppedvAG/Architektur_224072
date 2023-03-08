namespace HalloSingelton
{
    internal class Logger
    {
        private static Logger _instance;
        private static object _instanceLock = new object();

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                            _instance = new Logger();
                    }

                return _instance;
            }
        }


        private Logger()
        {
            Info("Logger gestartet");
        }

        public void Info(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:G} {message}");
        }
    }
}
