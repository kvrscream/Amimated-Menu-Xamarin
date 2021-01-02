using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace animatedMenu
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<animatedMenu.Model.Menu> MenuItems { get; set; }

        public MainPage()
        {
            InitializeComponent();
            this.MenuItems = GetMenus();
            this.BindingContext = this;
        }

        void ShadowMenu(System.Object sender, System.EventArgs e)
        {
            ShowMenu();
        }

        async void ShowMenu()
        {
            _ = TitleTxt.FadeTo(0);
            _ = MenuItemsView.FadeTo(1);
            await MainMenuView.RotateTo(0, 300, Easing.BounceOut);
        }


        async void HideMenu()
        {
            _ = TitleTxt.FadeTo(1);
            _ = MenuItemsView.FadeTo(0);
            await MainMenuView.RotateTo(-90, 300, Easing.BounceIn);
        }

        public ObservableCollection<animatedMenu.Model.Menu> GetMenus()
        {
            return new ObservableCollection<Model.Menu>()
            {
                new Model.Menu{ Title = "Profile"},
                new Model.Menu{ Title = "Feed"},
                new Model.Menu{ Title = "Activity"},
                new Model.Menu{ Title = "Settings"},
            };
        }

        void MenuTapped(System.Object sender, System.EventArgs e)
        {
            TitleTxt.Text = ((sender as StackLayout).BindingContext as Model.Menu).Title;

            HideMenu();
        }
    }
}
