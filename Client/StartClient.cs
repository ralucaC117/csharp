using mpp_proiect_csharp.Services;
using System;
using System.Windows.Forms;
using Networking;
using mpp_proiect_csharp;

namespace Client
{
    static class StartClient
    {
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IService server = new ServerProxy("127.0.0.1", 55555);
            Controller controller = new Controller(server);
            LogInForm logInForm = new LogInForm(controller);
            Application.Run(logInForm);
        }
    }
}
