using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogg.Models
{
    public interface IBlogRepository
    {
        LogViewModel[] GetLog();

        void AddPost(CreatePostViewModel model);
        PostListViewModel[] GetPosts(int from, int count);
        PostPageViewModel GetPost(int id);
    }
}
