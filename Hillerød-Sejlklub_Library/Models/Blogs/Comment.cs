using Hillerød_Sejlklub_Library.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Models.Blogs
{
    public class Comment
    {
        private int _counterID;
        private static int _counter = 1;
        private DateTime _dateOfPost;
        public string MakeComment
        {
            get; set;
        }

        public Member Member { get; set; }

        public int CounterID
        {
            get { return _counterID; }
        }

        public Comment(string comment, Member member )
        {
            _counterID = _counter++;
            MakeComment = comment;
            Member = member;
            _dateOfPost = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Member: {Member}   Comment: {MakeComment}    Date of Post: {_dateOfPost}";
        }
    }
}
