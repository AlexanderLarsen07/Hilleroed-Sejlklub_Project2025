using Hillerød_Sejlklub_Library.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub_Library.Interfaces
{
    public interface IBlogRepo
    {

        void AddBlog(Blog blog);
        bool BlogNameExist(string headline);

        List<Blog> ReturnByDateRange(DateTime from, DateTime to);

        void EditBlog(Blog blog, string headline, string theText, string description);
        void Delete(Blog blog);

        void PrintAllCommentsOnAllBlogs();

        List<Blog> ReturnBlogHeadline(string title);

        void PrintAllBlog();

        //skal jeg have en metode der printer alle blogs?                   //skal jeg have en metode der printer alle blogs?                   //skal jeg have en metode der printer alle blogs?           
        //printe alle vil være via foreach loop

        //skal jeg have en metode der opdater listen af blogs?              //skal jeg have en metode der opdater listen af blogs?               //skal jeg have en metode der opdater listen af blogs?
        //tjek uml 1 og 2 for den her

        //en metode for tjekke administrator eller formand?
    }
}