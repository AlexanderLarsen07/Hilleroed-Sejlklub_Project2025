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

        void EditBlog();
        void Delete();

        void CommentOnBlog(); //Skal nok have en anden return type 


        //en metode for tjekke administrator eller formand
    }
}