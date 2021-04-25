using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothackForum.Data
{
    public class PostReply
    {
        public int PostReplyId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}
