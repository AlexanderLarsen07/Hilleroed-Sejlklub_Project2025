using Hillerød_Sejlklub_Library.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hillerød_Sejlklub_Library.Models.Blogs
{
    public class Blog
    {
        private DateTime _startDate;
        private DateTime _lastUpdateDate;
        public List<Comment> _commentList;
        private int _blogID;
        private static int _counter = 1;
        

        public DateTime Date
        {
            get; set; //full eller auto?
        }
        public string Headline
        {
            get; set;
        }
        public int BlogID
        {
            get { return _blogID; }
        }

        public Member Member
        {
            get; private set;
        }
        public string TheText
        {
            get;  set;
        }
        public string Description
        {
            get;  set;
        }
        public Blog(string headline, Member member, string theText, string description)
        {
            _blogID = _counter++;
            _commentList = new List<Comment>();
            Headline = headline;
            Member = member;
            TheText = theText;
            Description = description;
        }

        #region Comments logic/methods
        public void AddComment(Comment comment) //tjekket ish skal fikses - den adder 2 
        {
            _commentList.Add(comment);
        }

        public void EditComment(Comment comment)   //samme her bare med comment i stedet for?
        {
            string commentChangedByUser = Console.ReadLine();
            for (int i = 0; i < _commentList.Count; i++)
            {
                if (_commentList[i] == comment)
                {
                    _commentList[i].MakeComment = commentChangedByUser;
                }
            }
        }

        //    public void RemoveComment(Comment comment)
        //    {
        //        _commentRepo.Remove(comment);
        //        Console.WriteLine($"Comment \"{comment.MakeComment}\" removed");
        //    }
        //    public List<Comment> ReturnAllCommentFromMembers()
        //    {
        //        return null;    //fjern
        //    }

        //    public void PrintAllCommentsOnBlog(Blog blog)      //vil printe alle comments i den ene blog
        //    {
        //        for (int i = 0; i < blog._commentList.Count; i++)
        //        {
        //            Console.WriteLine(blog._commentList[i].MakeComment);
        //        }
        //    }
        //}
        #endregion

        public override string ToString()
        {
            return $"Member: {Member}   Headline: {Headline}    the Text: {TheText}    Description: {Description}   Date: {Date}    Comment Section: {_commentList}    ID: {_blogID}";
        }
    }
}