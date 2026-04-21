using 3iosMA_jja.Models;

namespace 3iosMA_jja;

public partial class NewPostPage : ContentPage
{
    public event Action<Post>? PostCreated;

    public NewPostPage()
    {
        InitializeComponent();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void OnPostClicked(object sender, EventArgs e)
    {
        string author = AuthorEntry.Text?.Trim() ?? "";
        string content = PostEditor.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(content))
        {
            await DisplayAlert("Missing Info", "Please enter your name and post content.", "OK");
            return;
        }

        var newPost = new Post
        {
            Author = author,
            Content = content,
            CreatedAt = DateTime.Now
        };

        PostCreated?.Invoke(newPost);

        await Navigation.PopModalAsync();
    }
}
