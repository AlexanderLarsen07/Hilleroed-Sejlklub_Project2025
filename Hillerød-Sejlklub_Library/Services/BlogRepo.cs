using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Blogs;
using Hillerød_Sejlklub_Library.Models.Events;
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

        public BlogRepo()
        {
            _blogRepo = new List<Blog>();
        }

        public void AddBlog(Blog blog) //tilføj blog object ind til listen
        {
            if (!BlogNameExist(blog.Headline))
            {
                _blogRepo.Add(blog);
            }
        }
        public bool BlogNameExist (string headline)
        {
            foreach (var b in _blogRepo)
            {
                if (b.Headline == headline)
                {
                    return true;
                }
            }
            return false;
        }

        public Blog ReturnByDateRange(DateTime from, DateTime to)
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

        public void EditBlog(Blog blog, string headline, string theText, string description) 
            //return type Blog? fordi når man har ændret en bestemt blog så returner man den?
        {
            foreach(Blog b in _blogRepo)
            {
                if(b == blog)
                {
                    b.Headline = headline;
                    b.TheText = theText;
                    b.Description = description;
                }
            }
        }
        public void Delete(Blog blog) //DeleteBlog metoden skal tilføjes i user story?
        {
            _blogRepo.Remove(blog);
        }

        
        public void PrintAllComments()
        {
            foreach(Blog c in _blogRepo)
            {
                Console.WriteLine(c.CommentsOnBlog);
            }
        }

        //en metode for tjekke administrator eller formand?

        public List<Blog> ReturnBlogHeadline(string title)
        {
            List<Blog> blogTitle = new List<Blog>();

            for(int i = 0; i < _blogRepo.Count; i++)
            {
                if (_blogRepo[i].Headline == title.ToLower() || _blogRepo[i].Headline == title.ToUpper())
                {
                    blogTitle.Add(_blogRepo[i]);
                }
                return blogTitle;
            }
            return null;
        }
        public void PrintAllBlog()
        {
            foreach(Blog b in _blogRepo)
            {
                Console.WriteLine(b.Headline + b.Description);
            }
        }
    }
}