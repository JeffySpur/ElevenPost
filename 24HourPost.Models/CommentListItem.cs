using _24HourPost.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourPost.Models
{
    public class CommentListItem
    {
        [Display(Name = "Comment Id")]
        public int CommentId { get; set; }

        public string Text { get; set; }

        //public List<Comment> Replies { get; set; }

    }
}
