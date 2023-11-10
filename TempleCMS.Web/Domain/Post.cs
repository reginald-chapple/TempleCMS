using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Domain
{
    public class Post : Entity
    {
        public Post() {}
        
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string Body { get; set; } = string.Empty;

        public PostType Type { get; set; } = PostType.Text;

        public virtual Video? Video { get; set; }

        public long GroupId { get; set; }
        public virtual Group? Group { get; set; }

        public string AuthorId { get; set; } = string.Empty;
        public virtual ApplicationUser? Author { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public int DaysPassed()
        {
            return (DateTime.Now.Date - Created.Date).Days;
        }
    }

    public enum PostType
    {
        Text, Image, Video
    }
}