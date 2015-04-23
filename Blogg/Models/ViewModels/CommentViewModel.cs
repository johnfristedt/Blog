using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class CommentViewModel
    {
        public DateTime Time { get; set; }
        public string Author { get; set; }
        public string Conent { get; set; }
    }
}