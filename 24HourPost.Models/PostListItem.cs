using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourPost.Models
{
    public class PostListItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        /*public List<Post> Comments { get; set; }

        public List<Post> Likes { get; set; }*/
    }
}
