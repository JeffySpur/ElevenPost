using _24HourPost.Data;
using _24HourPost.Models;
using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectPost.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public void CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = _userId,
                    Text = model.Text,
                    CommentId = model.CommentId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replys.Add(entity);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<ReplyListItem> GetReplyByCommentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replys
                        .Where(e => e.CommentId == id && e.AuthorId == _userId)
                        .Select(
                        e =>
                        new ReplyListItem
                        {
                            ReplyId = e.ReplyId,
                            Text = e.Text
                        }
                        );
                return entity.ToArray();
            }
        }
    }
}
