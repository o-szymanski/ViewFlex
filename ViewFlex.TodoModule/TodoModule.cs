using ViewFlex.Core.Interfaces;
using ViewFlex.Infrastructure.Services;
using ViewFlex.TodoModule.Views;

namespace ViewFlex.TodoModule;

public class TodoModule(IRegionManager regionManager) : IModule
{
    private readonly IRegionManager _regionManager = regionManager;

    private const string RegionName = "Region";

    public void OnInitialized(IContainerProvider containerProvider) => _regionManager.RegisterViewWithRegion(RegionName, typeof(TodoListView));
    public void RegisterTypes(IContainerRegistry containerRegistry) => containerRegistry.RegisterSingleton<ITodoService, TodoService>();
}
