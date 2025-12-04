using Hillerød_Sejlklub_Library.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models
{
    public class Comment
    {
        public string MakeComment
        {
            get; set;
        }
        public Blog Blog
        {
            get; private set;
        }
        DateTime DateOfPost { get; set; }

        public Member Member { get; set; }


        public Comment(string comment, Member member, Blog blog)
        {
            MakeComment = comment;
            Member = member;
            Blog = blog;
        }

        public override string ToString()
        {
            return $"Member: {Member}   Comment: {MakeComment}   Blog: {Blog}";
        }
    }
}
