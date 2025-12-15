using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Blogs;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Services
{
    public class BlogRepo : IBlogRepo
    {
        private List<Blog> _blogRepo;
        
        
        public int Count
        {
            get { return _blogRepo.Count; }
        }
       
        public BlogRepo()
        {
            
            _blogRepo = new List<Blog>();
        }

        #region Blog methods
        public void AddBlog(Blog blog) //tjekket
        {
            if (!BlogNameExist(blog.Headline))
            {
                _blogRepo.Add(blog);
            }
        }
        public bool BlogNameExist(string headline) //tjekket
        {
            foreach (Blog b in _blogRepo)
            {
                if (b.Headline == headline)
                {
                    return true;
                }
            }
            return false;
        }

        public Blog ReturnByDateRange(DateTime from, DateTime to) //return en liste af blog og vise det
        {
            foreach (Blog b in _blogRepo)
            {
                if (b.Date >= from && b.Date <= to)
                {
                    return b;
                }
            }
            return null;
        }

        public void EditBlog(Blog blog, string headline, string theText, string description) //tjekket
        //return type Blog? fordi når man har ændret en bestemt blog så returner man den?
        {
            foreach (Blog b in _blogRepo)
            {
                if (b.Headline == blog.Headline) //headline (og) the text osv
                {
                    b.Headline = headline;
                    b.TheText = theText;
                    b.Description = description;
                }
            }
        }
        public void Delete(Blog blog) //tjekket
        {
            _blogRepo.Remove(blog);
        }


        public void PrintAllComments() //tjekket
        {
            foreach (Blog b in _blogRepo) //laver en loop inde i en loop fordi...
            {
                Console.WriteLine();
                Console.WriteLine($"Udskriver kommentarer for blog {b.Headline}");
                foreach (Comment c in b._commentList)
                {
                   
                    Console.WriteLine(c.MakeComment);
                }
                
            }
        }

        public List<Blog> ReturnBlogHeadline(string headline) //tjekket
        {
            List<Blog> blogHeadline= new List<Blog>();
            
            for (int i = 0; i < _blogRepo.Count; i++)
            {

                if (_blogRepo[i].Headline.ToLower() == headline.ToLower() )
                {
                    
                    blogHeadline.Add(_blogRepo[i]);
                 
                }
                //return blogHeadline;
            }
            return blogHeadline; 
        }

        public void PrintAllBlog() //tjekket
        {
            foreach (Blog b in _blogRepo)
            {
                Console.WriteLine($"Headline: {b.Headline}\nDescription: {b.Description}"); //toString()?
            }
        }
        //public List<Comment> GetAllCommentsWithThisMember(Member member)
        //{

        //    List<Comment> blogList = new List<Comment>();
        //    //foreach (Blog b in _blogRepo)
        //    //{
        //        //foreach (Comment comment in _blogRepo.Contains(this.CommentsOnBlog))
        //        //{
        //        //    if (comment.Member == member)
        //        //    {
        //        //        blogList.Add(comment);
        //        //    }
        //        //}
        //    }
        //    return blogList;
        //}
        public Blog? GetBlog(int id)
        {
            foreach(Blog b in _blogRepo)
            {
                if(b.BlogID == id)
                {
                    return b;
                }
            }
            return null;
        }
        #endregion


    }
}