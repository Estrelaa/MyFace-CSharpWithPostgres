using Dapper;
using System.Collections.Generic;

namespace MyFace.DataAccess
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPostsOnWall(string recipient);
        void CreatePost (Post newPost);
    }

    public class PostRepository : IPostRepository
    {
        public IEnumerable<Post> GetPostsOnWall(string recipient)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                return db.Query<Post>("SELECT * FROM Posts WHERE recipient = @recipient", new {recipient});
            }
        }

        public void CreatePost(Post newPost)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                db.Query<Post>("INSERT INTO Posts (Sender, Recipient, Content) VALUES(@Sender, @Recipient, @Content);", newPost);
            }
        }
    }
}
