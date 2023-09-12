using ApplicationView.Configurations;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Resolver.HelperError.IExceptions;
using Microsoft.Extensions.DependencyInjection;
using PlayerUI.Forms;
using System;
using System.Windows.Forms;

namespace ApplicationView
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //var builder = WebApplication;

                var host = ConfigurationBase.CreateHostBuilder().Build();
                ServiceProvider = host.Services;

                Application.Run(ServiceProvider.GetRequiredService<newfrmlogin>());
            }
            catch (ApiBusinessException ex)
            {

                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static IServiceProvider ServiceProvider { get; private set; }       
    }
}
