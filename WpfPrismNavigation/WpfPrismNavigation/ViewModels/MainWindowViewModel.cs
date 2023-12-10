using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using WPFDevelopers.Controls;
using WpfPrismNavigation.Views;

namespace WpfPrismNavigation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private DrawerMenuItem _selectedItem;
        public DrawerMenuItem SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }
        public DelegateCommand SelectionChangedCommand { get; }

        private readonly IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Home));
            SelectionChangedCommand = new DelegateCommand(UpdateRegionViews);
        }
        void UpdateRegionViews()
        {
            if (SelectedItem != null && !string.IsNullOrWhiteSpace(SelectedItem.Text))
                _regionManager.RequestNavigate("ContentRegion", new Uri(SelectedItem.Text, UriKind.Relative));
        }

    }
}
