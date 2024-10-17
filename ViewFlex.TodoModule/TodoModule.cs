using ViewFlex.Core.Interfaces;
using ViewFlex.Infrastructure.Services;
using ViewFlex.TodoModule.Views;

namespace ViewFlex.TodoModule;

public class TodoModule(IRegionManager regionManager) : IModule
{
    private readonly IRegionManager _regionManager = regionManager;

    public void OnInitialized(IContainerProvider containerProvider) => _regionManager.RegisterViewWithRegion("Region", typeof(TodoListView));
    public void RegisterTypes(IContainerRegistry containerRegistry) => containerRegistry.RegisterSingleton<ITodoService, TodoService>();
}
