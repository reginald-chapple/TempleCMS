using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Models
{
    public class ChatMessageModel
    {
        public ChatMessage? Message { get; set; }
        public UserModel? Author { get; set; }
    }
}