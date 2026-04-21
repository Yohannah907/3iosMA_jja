using System.Collections.ObjectModel;
using System.Linq;
using TeamRing.Models;

namespace TeamRing;

public partial class SocialFeedPage : ContentPage
{
    private ObservableCollection<Post> Posts = new ObservableCollection<Post>();

    public SocialFeedPage()
    {
        InitializeComponent();

        Posts.Add(new Post
        {
            Author = "Kath",
            Content = "Welcome to the social feed!",
            CreatedAt = DateTime.Now.AddMinutes(-20),
            ImageUrl = "C:\\Users\\Donalen G. Alvarado\\source\\repos",
            Likes = 3
        });

        Posts.Add(new Post
        {
            Author = "Dona",
            Content = "TIREDDDDDDDDDD",
            CreatedAt = DateTime.Now.AddMinutes(-10),
            ImageUrl = "",
            Likes = 1
        });

        PostsCollectionView.ItemsSource = Posts;
    }

    private async void OnNewPostClicked(object sender, EventArgs e)
    {
        var modal = new NewPostPage();

        modal.PostCreated += (newPost) =>
        {
            Posts.Insert(0, newPost);
        };

        await Navigation.PushModalAsync(new NavigationPage(modal));
    }

    private async void OnPostSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedPost = e.CurrentSelection.FirstOrDefault() as Post;

        if (selectedPost == null)
            return;

        await Navigation.PushModalAsync(new NavigationPage(new PostDetailPage(selectedPost)));

        PostsCollectionView.SelectedItem = null;
    }
}