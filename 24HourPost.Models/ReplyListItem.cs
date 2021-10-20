using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourPost.Models
{
    public class ReplyListItem
    {
        [Display(Name = "Reply Id")]
        public int ReplyId { get; set; }

        public string Text { get; set; }
    }
}
