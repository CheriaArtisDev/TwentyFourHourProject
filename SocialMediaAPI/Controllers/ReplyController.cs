using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMediaAPI.Controllers
{
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var replys = replyService.GetReplys();
            return Ok(replys);

        }

        private ReplyService CreateReplyService()
        {
            Guid authorID = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(authorID);
            return replyService;
        }
    }
}
