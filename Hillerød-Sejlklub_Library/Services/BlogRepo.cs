using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models;
using System;
using System.Collections.Generic;
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

        }

        public void CreateBlog()
        {

        }

        public void EditBlog()
        {

        }
        public void Delete() //DeleteBlog metoden skal tilføjes i user story?
        {

        }

        public void CommentOnBlog() //Skal nok have en anden return type 
        {

        }


        //en metode for tjekke administrator eller formand
    }
}