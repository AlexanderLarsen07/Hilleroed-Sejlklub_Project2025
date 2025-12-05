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

        public void AddComment(Comment comment)
        {
            _commentRepo.Add(comment);
        }

        public void EditComment(Comment comment, string editMakeComment) //samme her bare med comment i stedet for?
        {
            for(int i = 0; i < _commentRepo.Count; i++)
            {
                if (_commentRepo[i] == comment)
                {
                    _commentRepo[i].MakeComment = editMakeComment;
                }
            }
        }

        public void RemoveComment(Comment comment)
        {
            _commentRepo.Remove(comment);
        }
        public List<Comment> ReturnAllCommentFromMembers()
        {
            return null;    //fjern
        }

        public void PrintAllCommentsOnBlog(Blog blog) //vil printe alle comments i den ene blog
        {
            for (int i = 0; i <_commentRepo.Count; i++)
            {
                Console.WriteLine(blog.CommentsOnBlog[i]); 
            }
        }
    }
}
