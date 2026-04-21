using System.Collections.ObjectModel;

namespace TeamRing;

public partial class CollectionViewPage : ContentPage
{
    public ObservableCollection<Item> Items { get; set; }

    public CollectionViewPage()
    {
        InitializeComponent();

        Items = new ObservableCollection<Item>
        {
            new Item { Name = "Item 1", Description = "Description 1" },
            new Item { Name = "Item 2", Description = "Description 2" },
            new Item { Name = "Item 3", Description = "Description 3" },
            new Item { Name = "Item 4", Description = "Description 4" }
        };

        BindingContext = this;
    }

    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as Item;

        if (item != null)
            await DisplayAlert("Selected", item.Name, "OK");
    }
}