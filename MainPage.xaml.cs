namespace TeamRing;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OpenScrollViewPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ScrollViewPage());
    }

    private async void OpenListViewPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListViewPage());
    }

    private async void OpenCollectionViewPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CollectionViewPage());
    }

    private async void OpenSocialFeedPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SocialFeedPage());
    }
}