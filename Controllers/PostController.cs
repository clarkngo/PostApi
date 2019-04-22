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
                _context.PostItems.Add(new PostItem { Message = "Item1" });
                _context.SaveChanges();
            }
        }
       // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostItem>>> GetPostItems()
        {
            return await _context.PostItems.ToListAsync();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostItem>> GetPostItem(long id)
        {
            var PostItem = await _context.PostItems.FindAsync(id);

            if (PostItem == null)
            {
                return NotFound();
            }

            return PostItem;
        }        
        // POST: api/Post
        [HttpPost]
        public async Task<ActionResult<PostItem>> PostPostItem(PostItem item)
        {
            _context.PostItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostItem), new { id = item.Id }, item);
        }
        // PUT: api/Post/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostItem(long id, PostItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }    
        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostItem(long id)
        {
            var PostItem = await _context.PostItems.FindAsync(id);

            if (PostItem == null)
            {
                return NotFound();
            }

            _context.PostItems.Remove(PostItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }            
    }
}
