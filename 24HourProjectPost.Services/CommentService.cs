﻿using _24HourPost.Data;
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

        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }
    }
}
