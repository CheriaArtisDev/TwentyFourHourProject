using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostListItem
    {
        public int Id { get; set; }

        [Display(Name ="Post Created")]
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
