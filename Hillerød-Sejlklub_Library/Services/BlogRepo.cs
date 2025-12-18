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
        public void AddBlog(Blog blog) 
        {
            if (!BlogNameExist(blog.Headline))
            {
                _blogRepo.Add(blog);
            }
        }
        public bool BlogNameExist(string headline) 
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

        public List<Blog> ReturnByDateRange(DateTime from, DateTime to) 
        {
            List<Blog> list = new List<Blog>();

            foreach (Blog b in _blogRepo)
            {
                if (b.Date >= from && b.Date <= to)
                {
                    list.Add(b);
                }
            }
            return list;
        }

        public void EditBlog(Blog blog, string headline, string theText, string description) 
        {
            foreach (Blog b in _blogRepo)
            {
                if (b.Headline == blog.Headline) 
                {
                    b.Headline = headline;
                    b.TheText = theText;
                    b.Description = description;
                }
            }
        }
        public void DeleteBlog(Blog blog) 
        {
            foreach(Blog b in _blogRepo) 
            {
                if(b.BlogID == blog.BlogID)
                {
                    _blogRepo.Remove(b);
                    Console.WriteLine($"Blog \"{b.Headline}\" is deleted"); //fjern efter 
                    break;
                }
                
            }
        }


        public void PrintAllCommentsOnAllBlogs() 
        {
            foreach (Blog b in _blogRepo)
            {
                Console.WriteLine();
                Console.WriteLine($"Udskriver kommentarer for blog {b.Headline}"); //fjern efter
                b.PrintComments();

            }
        }

        public List<Blog> ReturnBlogHeadline(string headline) 
        {
            List<Blog> blogHeadline= new List<Blog>();
            
            for (int i = 0; i < _blogRepo.Count; i++)
            {

                if (_blogRepo[i].Headline.ToLower() == headline.ToLower() )
                {
                    
                    blogHeadline.Add(_blogRepo[i]);
                 
                }
                
            }
            return blogHeadline; 
        }

        public void PrintAllBlog() 
        {
            foreach (Blog b in _blogRepo)
            {
                Console.WriteLine($"Headline: {b.Headline}\nDescription: {b.Description}"); 
            }
        }

        public Blog? GetBlog(int id)
        {
            foreach (Blog b in _blogRepo)
            {
                if (b.BlogID == id)
                {
                    return b;
                }
            }
            return null;
        }
        #endregion


    }
}