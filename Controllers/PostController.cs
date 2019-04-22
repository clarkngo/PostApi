using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostApi.Models;

namespace PostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostContext _context;

        public PostController(PostContext context)
        {
            _context = context;

            if (_context.PostItems.Count() == 0)
            {
                // Create a new PostItem if collection is empty,
                // which means you can't delete all PostItems.
                _context.PostItems.Add(new PostItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
    }
}
