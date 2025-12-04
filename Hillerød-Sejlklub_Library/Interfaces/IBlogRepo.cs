using Hillerød_Sejlklub_Library.Models;
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

        void EditBlog(Blog blog, string headline, string theText, string description);
        void Delete(Blog blog);

        void PrintAllComments();


        //en metode for tjekke administrator eller formand?
    }
}