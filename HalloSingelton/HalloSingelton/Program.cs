
using HalloSingelton;

Console.WriteLine("Hello, Singelton!");

//var log = new Logger();

for (int i = 0; i < 20; i++)
{
    Task.Run(() => Logger.Instance.Info("Eine Info"));
}

Logger.Instance.Info("Mehr Info");
Logger.Instance.Info("Noch mehr Info");
