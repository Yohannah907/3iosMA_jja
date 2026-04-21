using System.Collections.ObjectModel;

namespace TeamRing;

public partial class ListViewPage : ContentPage
{
    public ObservableCollection<string> Items { get; set; }

    public ListViewPage()
    {
        InitializeComponent();

        Items = new ObservableCollection<string>
        {
            "Home",
            "Profile",
            "Messages",
            "Settings",
            "Logout"
        };

        BindingContext = this;
    }
}