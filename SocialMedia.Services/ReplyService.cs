using SocialMedia.Data;
using SocialMedia.Models;
using SocialMediaAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {
        private readonly Guid _authorId;

        public ReplyService(Guid ownerId)
        {
            _authorId = ownerId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = _authorId,
                    ReplyId = model.ReplyId,
                    ReplyText = model.ReplyText,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replys.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItems> GetReplys()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replys
                        .Where(e => e.AuthorId == _authorId)
                        .Select(
                            e =>
                                new ReplyListItems
                                {
                                    AuthorId = e.AuthorId,
                                    ReplyText = e.ReplyText,
                                    Id = e.ReplyId
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
