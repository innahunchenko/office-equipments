using Autofac;
using System.Windows;

namespace OfficeEquipment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = ContainerConfig.Configure();
            var app = container.Resolve<IApplicationRun>();
            app.Run();
        }
    }
}
