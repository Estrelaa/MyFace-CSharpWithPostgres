﻿using System.Collections.Generic;
using System.Linq;
using MyFace.DataAccess;

namespace MyFace.Models.ViewModels
{
    public class WallViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public string OwnerUsername { get; set; }
        public string fullname { get; set; }
        public string LoggedInUser { get; set; }
        public string NewPost { get; set; }

        public WallViewModel() {}

        public WallViewModel(IEnumerable<Post> posts, string ownerUsername)
        {
            Posts = posts.Select(post => new PostViewModel(post));
        }
    }
}