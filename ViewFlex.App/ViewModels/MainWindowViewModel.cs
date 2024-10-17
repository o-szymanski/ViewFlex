namespace ViewFlex.App.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;

    public DelegateCommand<string> NavigateCommand { get; private set; }

    public MainWindowViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        NavigateCommand = new DelegateCommand<string>(Navigate);
    }

    private void Navigate(string viewName)
    {
        if (!string.IsNullOrEmpty(viewName))
        {
            _regionManager.RequestNavigate("MainRegion", viewName);
        }
    }
}
