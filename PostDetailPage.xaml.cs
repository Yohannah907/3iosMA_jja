using System.Collections.ObjectModel;
using TeamRing.Models;

namespace TeamRing;

public partial class PostDetailPage : ContentPage
{
    private readonly Post _post;
    private ObservableCollection<string> Comments = new ObservableCollection<string>();

    public PostDetailPage(Post post)
    {
        InitializeComponent();

        _post = post;

        AuthorLabel.Text = _post.Author;
        TimeLabel.Text = _post.TimeDisplay;
        ContentLabel.Text = _post.Content;
        LikesLabel.Text = $"Likes: {_post.Likes}";

        if (!string.IsNullOrWhiteSpace(_post.ImageUrl))
        {
            PostImage.Source = _post.ImageUrl;
            PostImage.IsVisible = true;
        }
        else
        {
            PostImage.IsVisible = false;
        }

        CommentsCollectionView.ItemsSource = Comments;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void OnLikeClicked(object sender, EventArgs e)
    {
        _post.Likes++;
        LikesLabel.Text = $"Likes: {_post.Likes}";
    }

    private void OnAddCommentClicked(object sender, EventArgs e)
    {
        string comment = CommentEditor.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(comment))
            return;

        Comments.Add(comment);
        CommentEditor.Text = string.Empty;
    }
}