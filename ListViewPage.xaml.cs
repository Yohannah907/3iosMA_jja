using System.Collections.ObjectModel;

namespace 3iosMA_jja;

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
