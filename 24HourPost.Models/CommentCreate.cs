using _24HourPost.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourPost.Models
{
    public class CommentCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(250, ErrorMessage = "Only enter 250 characters.")]
        public string Text { get; set; }

        public int PostId { get; set; }
        public List<Comment> Replies { get; set; }
    }
}
