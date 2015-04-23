using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class PostListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PostTime { get; set; }
        public string Content { get; set; }
    }
}