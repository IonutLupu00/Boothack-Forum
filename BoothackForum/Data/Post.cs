using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BoothackForum.Data
{
    public class Post
    {
        public int Postid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        //In spiritul colectarii de date, cand userul vrea sa stearga postarea, ea doar o sa apara ca hidden, insta va ramane in baza de date
        
        public bool Hidden { get; set; }
        public virtual ApplicationUser User{ get; set; }
        public virtual Forum Forum { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }
        
    }
}
