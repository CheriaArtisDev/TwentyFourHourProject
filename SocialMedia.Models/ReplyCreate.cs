using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyCreate
    {

        [Required]
        public int ReplyId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [MaxLength(2000, ErrorMessage ="Your reply has too many characters.")]
        public string ReplyText { get; set; }

    }
}
