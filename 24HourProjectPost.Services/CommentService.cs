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
    public class CommentService
    {
        public void CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    AuthorId = _userId,
                    Text = model.Text,
                    PostId = model.PostId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<CommentListItem> GetCommentByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Where(e => e.PostId == id && e.AuthorId == _userId)
                        .Select(
                            e =>
                            new CommentListItem
                            {
                                CommentId = e.CommentId,
                                Text = e.Text
                            }
                        );
                return entity.ToArray();
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId && e.AuthorId == _userId);
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId && e.AuthorId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }

        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        private readonly Guid _userId;


    }
}
