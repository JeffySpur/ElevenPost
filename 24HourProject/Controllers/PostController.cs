using _24HourPost.Models;
using _24HourProjectPost.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourProject.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        public IHttpActionResult Post(PostCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            var postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }


        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }
    }
}
