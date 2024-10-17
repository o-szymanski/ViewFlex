using System.Windows;
using ViewFlex.App.ViewModels;

namespace ViewFlex.App
{
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<TodoModule.TodoModule>();
            moduleCatalog.AddModule<ExpensesModule.ExpensesModule>();
        }

        protected override Window CreateShell()
        {
            return ContainerLocator.Container.Resolve<MainWindow>();
        }
    }
}
