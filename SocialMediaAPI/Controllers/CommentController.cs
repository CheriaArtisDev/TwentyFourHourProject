using SocialMedia.Data;
using SocialMediaAPI.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialMediaAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        //CRUD
        //Creating
        [HttpPost]
        public async Task<IHttpActionResult> PostComment(Comment model)
        {
            if(ModelState.IsValid)
            {
                _context.Comments.Add(model);
                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest(ModelState);
        }

        //GetAll 
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<Comment> comments = await _context.Comments.ToListAsync();
            return Ok();
        }


        //GetById
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int Id)
        {
            Comment comment = await _context.Comments.FindAsync(Id);

            if(comment != null)
            {
                return Ok(comment);
            }

            return NotFound();
        }

        //GetByPostId
        [HttpGet]
        public async Task<IHttpActionResult> GetByPostId(int PostId)
        {
            Comment comment = await _context.Comments.FindAsync(PostId);

            if (comment != null)
            {
                return Ok(comment);
            }

            return NotFound();
        }

        //GetByAuthorId
        [HttpGet]
        public async Task<IHttpActionResult> GetByAuthorId(int AuthorId)
        {
            Comment comment = await _context.Comments.FindAsync(AuthorId);

            if (comment != null)
            {
                return Ok(comment);
            }

            return NotFound();
        }

        //Update
        [HttpPut]
        public async Task<IHttpActionResult> UpdateComment([FromUri]int Id, [FromBody]Comment model)
        {
            if(ModelState.IsValid)
            {
                Comment comment = await _context.Comments.FindAsync(Id);

                if(comment != null)
                {
                    comment.Text = model.Text;
                    comment.AuthorId = model.AuthorId;


                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            return BadRequest(ModelState);
        }

        //Delete
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCommentById(int Id)
        {
            Comment comment = await _context.Comments.FindAsync(Id);

            if(comment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
