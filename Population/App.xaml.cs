using System.Windows;

using StructureMap;

namespace Population {
    public partial class App  {
        public App() {
            ContainerBootstrapper.BootstrapStructureMap();
            Startup += AppStartup;
        }

        private void AppStartup(object sender, StartupEventArgs e) {
            var vm = ObjectFactory.GetInstance<PopulationViewModel>();
            var window = new MainWindow { DataContext = vm };
            window.Show();
        }
    }
}
