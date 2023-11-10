using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Domain
{
    public class Comment : Entity
    {
        public long Id { get; set; }
        
        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public long PostId { get; set; }

        public virtual Post? Post { get; set; }

        public long? ParentId { get; set; }

        public virtual Comment? Parent { get; set; }

        public string AuthorId { get; set; } = string.Empty;
        public virtual ApplicationUser? Author { get; set; }

        public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();
    }
}