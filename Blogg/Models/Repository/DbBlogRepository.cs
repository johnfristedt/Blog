using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class DbBlogRepository : IBlogRepository
    {
        const string DB_CONNECTION = "BlogDB";
        const string LOG_CONNECTION = "LogDB";

        public LogViewModel[] GetLog()
        {
            using (var db = new LogContext(LOG_CONNECTION))
            {
                return Mapper.Map<LogViewModel[]>(db.Errors.OrderByDescending(e => e.Time).ToArray());
            }
        }

        public void AddPost(CreatePostViewModel model)
        {
            using (var db = new BlogContext(DB_CONNECTION))
            {
                var post = Mapper.Map<Post>(model);
                post.PostTime = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public PostListViewModel[] GetPosts(int from, int count)
        {
            using (var db = new BlogContext(DB_CONNECTION))
            {
                return Mapper.Map<PostListViewModel[]>(db.Posts.OrderByDescending(p => p.PostTime).Skip(from).Take(count).ToArray());
            }
        }


        public PostPageViewModel GetPost(int id)
        {
            using (var db = new BlogContext(DB_CONNECTION))
            {
                return Mapper.Map<Post, PostPageViewModel>(db.Posts.Find(id));
            }
        }
    }
}