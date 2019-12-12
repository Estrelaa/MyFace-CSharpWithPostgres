using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFace.DataAccess
{
    public class ReactionsLogic
    {
        public static string FormatAddReaction(string Reaction, string Username)
        {
            return $"{Username}={Reaction},";
        }
        public static bool IsThisReactionTheUserLoggedIn(Post post, string LoggedInUser)
        {
            var seperatedReactions = post.Reactions.Split();
            if (seperatedReactions.Contains(LoggedInUser))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
