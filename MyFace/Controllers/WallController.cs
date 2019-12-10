using MyFace.DataAccess;
using MyFace.Helpers;
using MyFace.Middleware;
using MyFace.Models.ViewModels;
using System.Web.Mvc;
using System.Linq;

namespace MyFace.Controllers
{
    [BasicAuthentication]
    public class WallController : Controller
    {
        private readonly IPostRepository postRepository;

        public WallController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        // GET: Wall
        public ActionResult Index(string username, string fullname)
        {
            var posts = postRepository.GetPostsOnWall(username);                     
            var viewModel = new WallViewModel(posts, username);
            viewModel.fullname = fullname;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult NewWall(WallViewModel wallViewModel)
        {
            var username = AuthenticationHelper.ExtractUsernameAndPassword(Request).Username;
            postRepository.CreatePost(new Post() { Content = wallViewModel.NewPost, Recipient = wallViewModel.OwnerUsername, Sender = username });
            return RedirectToAction("Index", new {username= wallViewModel.OwnerUsername});
        }
    }
}
