using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Blogs;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Methods__Controllers.Blogs
{
    public class BlogMenuMethod
    {
        private static string ReadChoice(string choices)
        {
            Console.Write("\x1b[2J"); 
            Console.Write("\x1b[3J"); 
            Console.Write("\x1b[H");  
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }

        public void BlogMenu(Member? memberType, BlogRepo blogRepo, string choices)
        {

            
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
                              
                            }
                            break;
                        case "2":
                            {
                                Console.WriteLine("Look up start date and end date");
                                Console.WriteLine("write start date");
                                DateTime startDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("write end date");
                                DateTime endDate = DateTime.Parse(Console.ReadLine());  
                                Console.WriteLine(blogRepo.ReturnByDateRange(startDate, endDate));
                                Console.WriteLine("enter title of the blog you wish to see.");
                                string headLine = Console.ReadLine();
                                List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);
                                Console.WriteLine(blog);
                              
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
                                blogRepo.PrintAllBlog(); 
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
                                    Comment theComment = new Comment(comment, memberType);
                                    Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
                                }
                            }
                        break;

                        case "2":
                            {
                                Console.WriteLine("Look up start date and end date");
                                Console.WriteLine("write start date");
                                DateTime startDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("write end date");
                                DateTime endDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine(blogRepo.ReturnByDateRange(startDate, endDate));
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
                                    Comment theComment = new Comment(comment, memberType);
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

                else if (memberType.Role == RoleEnum.Administrator || memberType.Role == RoleEnum.Chairman)
                {
                    
                    switch (theChoice)
                    {
                        case "1":
                            {
                                blogRepo.PrintAllBlog();
                                Console.WriteLine("1. search for blog by title, \"q\" to quit ");
                            
                                     string choice = Console.ReadLine(); 
                                if (choice == "1") 
                                {
                                    Console.WriteLine("Search for headline");
                                    string headLine = Console.ReadLine();
                                    List<Blog> blog = blogRepo.ReturnBlogHeadline(headLine);
                                    Console.WriteLine(blog[0]);
                                   bool isFalse = true;

                                    if(headLine == "q")
                                    {
                                        isFalse = false;
                                    }

                                    while (isFalse)
                                    {
                                        if (blog.Count <= 0 ) 
                                        {   
                                            Console.WriteLine("No blog with the given headline was found.");
                                            Console.ReadLine();
                                            isFalse = false;
                                        }
                                        else if (blog.Count <= 1)
                                        {
                                            
                                            Console.WriteLine("Make your comment");
                                            string comment = Console.ReadLine();
                                            Comment theComment = new Comment(comment, memberType);
                                            Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
                                            isFalse = false;
                                        }
                                      
                                    }
                                    Console.WriteLine("press any key to comment.");                                    
                                }
                                else if(choice == "2")
                                {
                                   
                                   
                                }
                            }
                            break;

                        case "2":
                            {
                                Console.WriteLine("Look up start date and end date");
                                Console.WriteLine("write start date");
                                DateTime startDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("write end date");
                                DateTime endDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine(blogRepo.ReturnByDateRange(startDate, endDate));
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
                                    Comment theComment = new Comment(comment, memberType);
                                    Console.WriteLine($"Comment made to the blog {blog[0].Headline}");
                                }
                            }
                            break;

                        case "3":
                            {
                                Console.WriteLine("Add a headline");
                                string? headline = Console.ReadLine(); 

                                Console.WriteLine("Add a text");
                                string? text = Console.ReadLine(); 

                                Console.WriteLine("Add a description");
                                string? description = Console.ReadLine(); 

                                Blog blog = new Blog(headline, memberType, text, description); 
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
            }
        }
    }
}
