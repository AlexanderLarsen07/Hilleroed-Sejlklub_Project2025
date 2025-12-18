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
        private  List<Comment> _commentList;
        private int _blogID;
        private static int _counter = 1;
        

        public DateTime Date
        {
            get; set; 
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
            Date = DateTime.Now;
        }
        
        #region Comments logic/methods
        public void AddComment(Comment comment) 
        {
            _commentList.Add(comment);                
        }

        public void EditComment(string updatedComment, int id)  
        {
            
            for (int i = 0; i < _commentList.Count; i++)
            {
                if (_commentList[i].CounterID == id)
                {
                    _commentList[i].MakeComment = updatedComment;
                }
            }
        }

        public void RemoveComment(int id)
        { 
            foreach (Comment c in _commentList)
            {
                if (c.CounterID == id)
                {
                    _commentList.Remove(c);
                    Console.WriteLine($"Comment \"{c.MakeComment}\" removed");//fjerne efter
                    break;
                }
            }

        }

        public void PrintComments()
        {
            foreach (Comment c in _commentList)
            {
                Console.WriteLine(c.MakeComment);
            }
        }
        #endregion

        public override string ToString()
        {
            return $"Member: {Member}   Headline: {Headline}    the Text: {TheText}    Description: {Description}   Date: {Date}    Comment Section: {_commentList}    ID: {_blogID}";
        }
    }
}