using MyFace.DataAccess;

namespace MyFace.Models.ViewModels
{
    public class PostViewModel
    {
        public string Sender { get; }
        public string Receiver { get; }
        public string Content { get; }
        public int id { get; set; }

        public PostViewModel(Post post)
        {
            Sender = post.Sender;
            Receiver = post.Recipient;
            Content = post.Content;
            id = post.id;
        }
    }
}