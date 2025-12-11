using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Blogs;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Methods__Controllers.Blogs
{
    public class BlogMenuMethod
    {
        private static string ReadChoice(string choices)
        {
            Console.Write("\x1b[2J"); // Clear screen
            Console.Write("\x1b[3J"); // Clear scrollback
            Console.Write("\x1b[H");  // Set cursor to home
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }

        public void BlogMenu(Member? memberType, BlogRepo blogRepo, CommentRepo commentRepo, string choices)
        {

            //        bool input = true;
            //        while (input)
            //        {
            //            //string userChoice = Console.ReadLine();
            //            //Member memer = new Member("name", 2, MembershipEnum.Medlem, "mail", "password", 007); //for at teste - normal skal man kunne logge ind først inden man når hertil korrekt?
            //            if (memberType.Role == RoleEnum.Member)
            //            {
            //                Console.WriteLine($"1. Add a blog\n2. Edit a blog\n3. Delete a blog\n\"q\"to quit");

            //                switch (userChoice)
            //                {

            //                    case "1":
            //                        {
            //                            blogRepo.PrintAllBlog();
            //                            Console.WriteLine("1. search for blog by title, \"q\" to quit ");
            //                            string headLine = Console.ReadLine();
            //                            List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);

            //                            bool isFalse = true;
            //                            while (isFalse)
            //                            {
            //                                Console.WriteLine(blog);

            //                                Console.WriteLine("press any key to comment. Press \"q\" to exit");

            //                                string choice = Console.ReadLine();

            //                                if (choice == "q".ToLower() || choice == "q".ToUpper())
            //                                {
            //                                    isFalse = false;
            //                                }
            //                                Console.WriteLine("Make your comment");
            //                                string comment = Console.ReadLine();
            //                                Comment theComment = new Comment(comment, memberType, blog[0]);
            //                                Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
            //                            }
            //                        }
            //                        break;
            //                    case "2":
            //                        {

            //                            Console.WriteLine("Look up start date and end date");//skriv format så user kan indsætte en valid datetime
            //                            Console.WriteLine("write start date");
            //                            DateTime startDate = DateTime.Parse(Console.ReadLine());
            //                            Console.WriteLine("write end date");
            //                            DateTime endDate = DateTime.Parse(Console.ReadLine());
            //                            Console.WriteLine(blogRepo.ReturnByDateRange(startDate, endDate).Headline);
            //                            Console.WriteLine("enter title of the blog you wish to see.");
            //                            string headLine = Console.ReadLine();
            //                            List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);

            //                            bool isFalse = true;
            //                            while (isFalse)
            //                            {
            //                                Console.WriteLine(blog);

            //                                Console.WriteLine("press any key to comment. Press \"q\" to exit");

            //                                string choice = Console.ReadLine();

            //                                if (choice == "q".ToLower() || choice == "q".ToUpper())
            //                                {
            //                                    isFalse = false;
            //                                }
            //                                Console.WriteLine("Make your comment");
            //                                string comment = Console.ReadLine();
            //                                Comment theComment = new Comment(comment, memberType, blog[0]);
            //                                Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
            //                            }
            //                        }
            //                        break;
            //                    case "q":
            //                        {
            //                            input = false;
            //                        }
            //                        break;
            //                    default:
            //                        {
            //                            Console.WriteLine("invalid input try these options:");
            //                        }
            //                        break;
            //                }
            //            }

            //            else if (memberType.Role == RoleEnum.Administrator)
            //            {
            //                Console.WriteLine("1. Print and search blogs\n2.Search blog by date\n3.Create a Blog\n4.Edit a blog\n5. Delete a blog");
            //                //ny userchoice for Admin
            //                string userchoice = Console.ReadLine(); //midlertidlig?
            //                switch (userChoice + member)
            //                {
            //                    case "1":
            //                        {
            //                            blogRepo.PrintAllBlog();
            //                            Console.WriteLine("1. search for blog by title, \"q\" to quit ");
            //                            string headLine = Console.ReadLine();
            //                            List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);

            //                            bool isFalse = true;
            //                            while (isFalse)
            //                            {
            //                                Console.WriteLine(blog);

            //                                Console.WriteLine("press any key to comment. Press \"q\" to exit");

            //                                string choice = Console.ReadLine();

            //                                if (choice == "q".ToLower() || choice == "q".ToUpper())
            //                                {
            //                                    isFalse = false;
            //                                }
            //                                Console.WriteLine("Make your comment");
            //                                string comment = Console.ReadLine();
            //                                Comment theComment = new Comment(comment, memberType, blog[0]);
            //                                Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
            //                            }
            //                        }
            //                        break;
            //                    case "2":
            //                        {

            //                            Console.WriteLine("Look up start date and end date");//skriv format så user kan indsætte en valid datetime
            //                            Console.WriteLine("write start date");
            //                            DateTime startDate = DateTime.Parse(Console.ReadLine());
            //                            Console.WriteLine("write end date");
            //                            DateTime endDate = DateTime.Parse(Console.ReadLine());
            //                            Console.WriteLine(blogRepo.ReturnByDateRange(startDate, endDate).Headline);
            //                            Console.WriteLine("enter title of the blog you wish to see.");
            //                            string headLine = Console.ReadLine();
            //                            List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);

            //                            bool isFalse = true;
            //                            while (isFalse)
            //                            {
            //                                Console.WriteLine(blog);

            //                                Console.WriteLine("press any key to comment. Press \"q\" to exit");

            //                                string choice = Console.ReadLine();

            //                                if (choice == "q".ToLower() || choice == "q".ToUpper())
            //                                {
            //                                    isFalse = false;
            //                                }
            //                                Console.WriteLine("Make your comment");
            //                                string comment = Console.ReadLine();
            //                                Comment theComment = new Comment(comment, memberType, blog[0]);
            //                                Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
            //                            }
            //                        }
            //                        break;
            //                    case "3":
            //                        {

            //                            Console.WriteLine("Add a headline");
            //                            string? headline = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

            //                            Console.WriteLine("Add a text");
            //                            string? text = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

            //                            Console.WriteLine("Add a description");
            //                            string? description = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

            //                            Blog blog = new Blog(headline, memberType, text, description); //skal det være memberType?
            //                            //_blogRepo.AddBlog(new Blog(headline, memer, text, description));

            //                            Console.WriteLine("Added the blog");
            //                        }
            //                        break;
            //                    case "4":
            //                        {
            //                            //edit blog
            //                        }
            //                        break;

            //                    case "5":
            //                        {
            //                            //delete blog
            //                            Console.WriteLine("Choose a blog to delete");

            //                        }
            //                        break;
            //                    case "q":
            //                        {
            //                            input = false;
            //                        }
            //                        break;
            //                    default:
            //                        {
            //                            Console.WriteLine("invalid input try these options:");
            //                        }
            //                        break;
            //                }
            //            }
            //            else if (memberType.Role == RoleEnum.Chairman)
            //            {
            //                //ny userchoice for chairman
            //                switch (userChoice + member)
            //                {
            //                    case "1":

            //                        break;
            //                }
            //            }
            //            else if (memberType?.Role == null)
            //            {
            //                //guests menu
            //                switch (userChoice)
            //                {
            //                    case "1":
            //                        //..
            //                        break;
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Sign in or sign up to see what's going on in the blog!");
            //            }
            //        }

            //    }


            //}
            string theChoice = ReadChoice(choices);
            while (theChoice != "q")
            {
                if (memberType == null)
                {
                    switch (theChoice)
                    {
                        case "1":
                            {
                                blogRepo.PrintAllBlog();
                                Console.WriteLine("1. search for blog by title, \"q\" to quit ");
                                string headLine = Console.ReadLine();
                                List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);
                                Console.WriteLine(blog[0]);
                                //bool isFalse = true;
                                //while (isFalse)
                                //{
                                //    Console.WriteLine(blog);

                                //    Console.WriteLine("press any key to comment. Press \"q\" to exit");

                                //    string choice = Console.ReadLine();

                                //    if (choice == "q".ToLower() || choice == "q".ToUpper())
                                //    {
                                //        isFalse = false;
                                //    }
                                //    Console.WriteLine("Make your comment");
                                //    string comment = Console.ReadLine();
                                //    Comment theComment = new Comment(comment, memberType, blog[0]);
                                //    Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
                                //}
                            }
                            break;
                        case "2":
                            {
                                Console.WriteLine("Look up start date and end date");//skriv format så user kan indsætte en valid datetime
                                Console.WriteLine("write start date");
                                DateTime startDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("write end date");
                                DateTime endDate = DateTime.Parse(Console.ReadLine()); //herfra og op kan man putte i returnByDateRange metoden og returner svaret tilbage her og printe?
                                Console.WriteLine(blogRepo.ReturnByDateRange(startDate, endDate).Headline);
                                Console.WriteLine("enter title of the blog you wish to see.");
                                string headLine = Console.ReadLine();
                                List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);
                                Console.WriteLine(blog);
                                //bool isFalse = true;
                                //while (isFalse)
                                //{
                                //    Console.WriteLine(blog);

                                //    Console.WriteLine("press any key to comment. Press \"q\" to exit");

                                //    string choice = Console.ReadLine();

                                //    if (choice == "q".ToLower() || choice == "q".ToUpper())
                                //    {
                                //        isFalse = false;
                                //    }
                                //    Console.WriteLine("Make your comment");
                                //    string comment = Console.ReadLine();
                                //    Comment theComment = new Comment(comment, memberType, blog[0]);
                                //    Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
                                //}
                            }
                            break;
                    }
                    theChoice = ReadChoice(choices);
                }

                else if (memberType.Role == RoleEnum.Member)
                {
                    switch (theChoice)
                    {

                        case "1":
                            {
                                blogRepo.PrintAllBlog(); //alt det her kan være som sagt en metode i blogRepo og at lave en comment er en anden metode i commentRepo
                                Console.WriteLine("1. search for blog by title, \"q\" to quit ");
                                string headLine = Console.ReadLine();
                                List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);
                                Console.WriteLine(blog[0]);
                                bool isFalse = true;
                                while (isFalse)
                                {
                                    Console.WriteLine(blog);

                                    Console.WriteLine("press any key to comment. Press \"q\" to exit");

                                    string choice = Console.ReadLine();

                                    if (choice == "q".ToLower() || choice == "q".ToUpper())
                                    {
                                        isFalse = false;
                                    }
                                    Console.WriteLine("Make your comment");
                                    string comment = Console.ReadLine();
                                    Comment theComment = new Comment(comment, memberType, blog[0]);
                                    Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
                                }
                            }
                        break;

                        case "2":
                            {
                                Console.WriteLine("Look up start date and end date");//skriv format så user kan indsætte en valid datetime
                                Console.WriteLine("write start date");
                                DateTime startDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("write end date");
                                DateTime endDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine(blogRepo.ReturnByDateRange(startDate, endDate).Headline);
                                Console.WriteLine("enter title of the blog you wish to see.");
                                string headLine = Console.ReadLine();
                                List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);

                                bool isFalse = true;
                                while (isFalse)
                                {
                                    Console.WriteLine(blog);

                                    Console.WriteLine("press any key to comment. Press \"q\" to exit"); //have den samme if else eller lignedene struktur som nede i admin?

                                    string choice = Console.ReadLine();

                                    if (choice == "q".ToLower() || choice == "q".ToUpper())
                                    {
                                        isFalse = false;
                                    }
                                    Console.WriteLine("Make your comment");
                                    string comment = Console.ReadLine();
                                    Comment theComment = new Comment(comment, memberType, blog[0]);
                                    Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
                                }
                            }
                            break;
                        
                        default:
                            {
                                Console.WriteLine("invalid input try these options:");
                            }
                            break;
                    }
                    theChoice = ReadChoice(choices);
                }

                else if (memberType.Role == RoleEnum.Administrator)
                {
                    //ny userchoice for Admin
                    switch (theChoice)
                    {
                        case "1":
                            {
                                blogRepo.PrintAllBlog(); //have alt det her i en metode i blogRepo og kald på den her, return type kan være Blog?
                                Console.WriteLine("1. search for blog by title, \"q\" to quit ");
                              

                                

                                     string choice = Console.ReadLine(); //hvad man kan gøre med en objekt af blog eller comment //have en while loop? quit måske?
                                if (choice == "1") //søg efter en blog
                                {
                                    Console.WriteLine("Search for headline");
                                    string headLine = Console.ReadLine(); //herfra og til cw("1. "); skal det være i en metode for sig selv i BlogRepo? søg efter blog via headline?
                                    List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);
                                    Console.WriteLine(blog[0]);

                                    bool isFalse = true;
                                    while (isFalse)
                                    {
                                        if (blog.Count == 1) //kommenter
                                        {
                                            Console.WriteLine("Make your comment");
                                            string comment = Console.ReadLine();
                                            Comment theComment = new Comment(comment, memberType, blog[0]);
                                            Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
                                        }
                                        else if (blog.Count == 2)
                                        {
                                            //rediger kommenter
                                            //commentRepo.EditComment(); //comment reference til at finde den comment man vil rediger?
                                        }
                                        else if (choice == "3")
                                        {
                                            //slet kommentar
                                        }
                                    }
                                    Console.WriteLine("press any key to comment.");



                                    //if (choice == "q".ToLower() || choice == "q".ToUpper())
                                    //{
                                    //    isFalse = false;
                                    //}
                                    
                                }
                            }
                            break;

                        case "2":
                            {
                                Console.WriteLine("Look up start date and end date");//skriv format så user kan indsætte en valid datetime
                                Console.WriteLine("write start date");
                                DateTime startDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("write end date");
                                DateTime endDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine(blogRepo.ReturnByDateRange(startDate, endDate).Headline);
                                Console.WriteLine("enter title of the blog you wish to see.");
                                string headLine = Console.ReadLine();
                                List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);

                                bool isFalse = true;
                                while (isFalse)
                                {
                                    Console.WriteLine(blog);

                                    Console.WriteLine("press any key to comment. Press \"q\" to exit");

                                    string choice = Console.ReadLine();

                                    if (choice == "q".ToLower() || choice == "q".ToUpper())
                                    {
                                        isFalse = false;
                                    }
                                    Console.WriteLine("Make your comment");
                                    string comment = Console.ReadLine();
                                    Comment theComment = new Comment(comment, memberType, blog[0]);
                                    Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
                                }
                            }
                            break;

                        case "3":
                            {
                                Console.WriteLine("Add a headline");
                                string? headline = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

                                Console.WriteLine("Add a text");
                                string? text = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

                                Console.WriteLine("Add a description");
                                string? description = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

                                Blog blog = new Blog(headline, memberType, text, description); //skal det være memberType?
                                                                                               //_blogRepo.AddBlog(new Blog(headline, memer, text, description));
                                Console.WriteLine("Added the blog");
                            }
                            break;
                        case "4":
                            {
                                //edit blog

                            }
                            break;
                        case "5":
                            {
                                //delete blog
                                Console.WriteLine("Choose a blog to delete");
                                
                                Console.WriteLine("Blog deleted");
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("invalid input try these options:");
                            }
                            break;
                    }
                    theChoice = ReadChoice(choices);
                }

                else if (memberType.Role == RoleEnum.Chairman)
                {
                    //ny userchoice for chairman
                    switch (theChoice)
                    {
                        case "1":

                            break;
                    }
                    theChoice = ReadChoice(choices);
                }
            }
        }
    }
}
//til Admin og chairman
//case "1":
//    {
//        Console.WriteLine("Add a headline");
//        string? headline = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

//        Console.WriteLine("Add a text");
//        string? text = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

//        Console.WriteLine("Add a description");
//        string? description = Console.ReadLine(); //exception for intet input? det kan i hvertfald null

//        _blogRepo.AddBlog(new Blog(headline, memer, text, description));

//        Console.WriteLine("Added the blog");
//    }
//    break;
//case "2":
//    {
//        //rediger blog og implementer at man faktisk kan det
//    }
//    break;
//case "3":
//    {
//        //slet en blog
//    }
//    break;
////case 4 for opdater listen a blog? og case 5 for at printe dem alle? case 5 for medlem
//case "q":
//    {
//        input = false;
//    }
//    break;
//default:
//    {
//        Console.WriteLine("invalid input try these options:");
//    }
//    break;
