using Hillerød_Sejlklub_Library.Exceptions;
using Hillerød_Sejlklub_Library.Models.Blogs; 
using Hillerød_Sejlklub_Library.Models.Members; 
using Hillerød_Sejlklub_Library.Services;

BlogRepo blogRepoTester = new BlogRepo();



Member member1 = new Member("Bob", 40, MembershipEnum.Medlem, "mail@hotmail.com", "password1!", "10000001");
Member member2 = new Member("Kev", 31, MembershipEnum.Medlem, "kevmail@hotmail.com", "password1!", "10000001");

Blog blog1 = new Blog("Blog 1", member1, "Text er context", "This is the description of the blog");
Blog blog2 = new Blog("Blog 2",member1,"the blog is about Animals", "This is the description of first part of animals");
Blog blog3 = new Blog("Blog 3",member1,"Part 2 about animals", "This is the description of the blog about second part of animals");

Comment comment1 = new Comment("This blog is amazing!", member2); 
Comment comment2 = new Comment("I wanna read more!!", member2); 

Console.WriteLine("ADD BLOG METHOD");
Console.WriteLine("Number of blog in the list");
Console.WriteLine(blogRepoTester.Count); 
Console.WriteLine("Adding a blog to the list");
blogRepoTester.AddBlog(blog1);
blogRepoTester.AddBlog(blog2);
blogRepoTester.AddBlog(blog3);
Console.WriteLine("Number of blog in the list after adding:");
Console.WriteLine(blogRepoTester.Count);
blogRepoTester.PrintAllBlog();
Console.WriteLine("----------------------------------------------");

Console.WriteLine($"\nCHECKING BLOG NAME EXIST");
Console.WriteLine("Adding a blog to the list");
blogRepoTester.AddBlog(blog2);
Console.WriteLine("Number of blog in the list:");
Console.WriteLine(blogRepoTester.Count);
blogRepoTester.PrintAllBlog();
Console.WriteLine("----------------------------------------------");

Console.WriteLine($"\nRETURN BY DATE RANGE METHOD");
DateTime first = new DateTime(2000, 2, 18);
DateTime last = new DateTime(2026, 3, 1);
foreach (Blog b in blogRepoTester.ReturnByDateRange(first, last))
{
    Console.WriteLine(b.Headline + b.Date);
}
Console.WriteLine("----------------------------------------------");

Console.WriteLine($"\nEDIT BLOG METODE");
try
{
    Console.WriteLine("Edit Headline here");
    string headline = Console.ReadLine()!; //! = ikke null
    Console.WriteLine("Edit the text here");
    string theText = Console.ReadLine()!;
    Console.WriteLine("Edit description here");
    string description = Console.ReadLine()!;

    blogRepoTester.EditBlog(blog2, headline, theText, description);
    Console.WriteLine("Changes made");
    blogRepoTester.PrintAllBlog();
    Console.WriteLine("----------------------------------------------");
}
catch (Exception e)
{
    Console.WriteLine($"FEJL: {e.Message}");
}
Console.WriteLine($"\nDELETE BLOG METHOD");
blogRepoTester.DeleteBlog(blog3);

Console.WriteLine($"\nNumber of blogs: {blogRepoTester.Count}");
Console.WriteLine("----------------------------------------------");


Console.WriteLine($"\nRETURN BLOG BY HEADLINE METHOD");
List<Blog> test = blogRepoTester.ReturnBlogHeadline("Blog 1");
for (int i = 0; i < test.Count; i++)
{
    Console.WriteLine($"Headline: {test[i].Headline}");
}
Console.WriteLine("----------------------------------------------");

try { 
    Console.WriteLine($"\nADD COMMENTS METHOD");
    Console.WriteLine("Adding a comment");
    blogRepoTester.GetBlog(1).AddComment(comment1); 
    blogRepoTester.GetBlog(1).AddComment(comment2);

    Console.WriteLine("printing all comments:");
    blogRepoTester.PrintAllCommentsOnAllBlogs();
    Console.WriteLine("----------------------------------------------");
}
catch(Exception e)
{

    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("EDIT COMMENT METHOD");
    Blog? blog = blogRepoTester.GetBlog(1);
    Console.WriteLine("Write the ID for comment");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Write down the new text for the comment");
    string? updatedComment = Console.ReadLine();
    blog?.EditComment(updatedComment, id);

    blogRepoTester.PrintAllCommentsOnAllBlogs();
    Console.WriteLine("----------------------------------------------");

    Console.WriteLine("REMOVE COMMENT METHOD");

    blog = blogRepoTester.GetBlog(1);
    Console.WriteLine("Write the ID for comment");

    id = Convert.ToInt32(Console.ReadLine());

    blog.RemoveComment(id);

    blogRepoTester.PrintAllCommentsOnAllBlogs();
    Console.WriteLine("----------------------------------------------");
}
catch(FormatException e)
{
    Console.WriteLine($"Fejl: {e.Message}");
}

