using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class CreateCommentViewModel
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Content { get; set; }
    }
}