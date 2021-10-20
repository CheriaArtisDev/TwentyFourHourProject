using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyListItems
    {
        public int Id { get; set; }

        public Guid AuthorId { get; set; }

        public string ReplyText { get; set; }
    }
}
