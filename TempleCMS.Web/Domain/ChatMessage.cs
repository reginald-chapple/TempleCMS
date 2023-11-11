using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleCMS.Web.Domain
{
    public class ChatMessage : Entity
    {
        public long Id { get; set; }

        public string Content { get; set; } = string.Empty;

        [Editable(false, AllowInitialValue = true)]
        public string AuthorId { get; set; } = string.Empty;

        public long ChatId { get; set; }
        public virtual Chat? Chat { get; set; }
    }
}
