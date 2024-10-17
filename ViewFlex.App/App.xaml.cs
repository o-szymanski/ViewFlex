using System.Windows;
using ViewFlex.App.ViewModels;
using ViewFlex.ExpensesModule.ViewModels;
using ViewFlex.ExpensesModule.Views;
using ViewFlex.TodoModule.ViewModels;
using ViewFlex.TodoModule.Views;

namespace ViewFlex.App
{
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<TodoListView, TodoListViewModel>();
            containerRegistry.RegisterForNavigation<ExpenseListView, ExpenseListViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<TodoModule.TodoModule>();
            moduleCatalog.AddModule<ExpensesModule.ExpensesModule>();
        }

        protected override Window CreateShell() => ContainerLocator.Container.Resolve<MainWindow>();
    }
}
