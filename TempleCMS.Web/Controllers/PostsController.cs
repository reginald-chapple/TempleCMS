using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TempleCMS.Web.Data;
using TempleCMS.Web.Domain;
using TempleCMS.Web.Models;

namespace TempleCMS.Web.Controllers
{
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(TextPostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var json = JsonConvert.SerializeObject(errors);

                return Json(json);
            }

            var post = new Post
            {
                Body = model.Body,
                ClubId = model.ClubId,
                AuthorId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            };

            await _context.AddAsync(post);
            await _context.SaveChangesAsync();

            var response = new 
            {
                Body = post.Body,
                Author = User.FindFirst("FullName")!.Value,
                AuthorImage = $"/media/members/{User.FindFirst("Image")!.Value}"
            };
            
            return new JsonResult(response);
        }

        [Route("Image")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Image(ImagePostInputModel model)
        {
            return new JsonResult("Do Work");
        }

        [Route("Video")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Video(VideoPostInputModel model)
        {
            return new JsonResult("Do Work");
        }
    }
}