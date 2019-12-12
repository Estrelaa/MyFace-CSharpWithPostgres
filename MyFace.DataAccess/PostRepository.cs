using Dapper;
using System.Collections.Generic;

namespace MyFace.DataAccess
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPostsOnWall(string recipient);
        void CreatePost (Post newPost);
        void DeletePost(Post id);
        void AddReaction(Post CurrentPost, string UserName);
    }

    public class PostRepository : IPostRepository
    {
        public IEnumerable<Post> GetPostsOnWall(string recipient)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                return db.Query<Post>("SELECT * FROM Posts WHERE recipient = @recipient", new { recipient });
            }
        }
        public void CreatePost(Post newPost)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                db.Query<Post>("INSERT INTO Posts (Sender, Recipient, Content) VALUES(@Sender, @Recipient, @Content);", newPost);
            }
        }
        public void DeletePost(Post CurrentPost)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                var id = CurrentPost.id;
                db.Query<Post>("DELETE FROM Posts WHERE \"id\" = @id", new { id });
            }
        }
        public void AddReaction(Post CurrentPost, string UserName)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                var Reaction = ReactionsLogic.FormatAddReaction(CurrentPost.Reactions, UserName);
                db.Query<Post>($"UPDATE posts SET reactions = \'{Reaction}\' WHERE id = {CurrentPost.id};");
            }
        }
    }
}
