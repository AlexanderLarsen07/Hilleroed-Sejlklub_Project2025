using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Services
{
    public class CommentRepo :ICommentRepo
    {
        private List<Comment> _commentRepo;

        public CommentRepo()
        {
            _commentRepo = new List<Comment>();
        }

        public List<Comment> ReturnAllCommentFromMembers()
        {
            return null;    //fjern
        }

        public void RemoveComment()
        {

        }
    }
}
