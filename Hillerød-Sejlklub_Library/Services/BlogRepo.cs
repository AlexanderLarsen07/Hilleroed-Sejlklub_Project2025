using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Blogs;
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
    }
}