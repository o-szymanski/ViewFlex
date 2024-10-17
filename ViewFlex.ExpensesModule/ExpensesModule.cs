using ViewFlex.Core.Interfaces;
using ViewFlex.ExpensesModule.Views;
using ViewFlex.Infrastructure.Services;

namespace ViewFlex.ExpensesModule;

public class ExpensesModule(IRegionManager regionManager) : IModule
{
    private readonly IRegionManager _regionManager = regionManager;

    public void OnInitialized(IContainerProvider containerProvider)
    {
        _regionManager.RegisterViewWithRegion("MainRegion", typeof(ExpenseListView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IExpenseService, ExpenseService>();
    }
}
