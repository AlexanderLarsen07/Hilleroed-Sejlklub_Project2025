using Hillerød_Sejlklub_Library.Models.Blogs; //rigitg?
using Hillerød_Sejlklub_Library.Models.Members; //rigtig?
using Hillerød_Sejlklub_Library.Services;

BlogRepo blogRepoTester = new BlogRepo();
CommentRepo commentRepoTester = new CommentRepo();
MemberRepo memberRepoTester = new MemberRepo(); //ikke grund til at have? skal have member instanser

Member member1 = new Member("Bob", 40, MembershipEnum.Medlem, "mail@hotmail.com", "password1!", "10000001");
Member member2 = new Member("Kev", 31, MembershipEnum.Medlem, "kevmail@hotmail.com", "password1!", "10000001");

Blog blog1 = new Blog("Story Time", member1, "the story was inspirational for many journalists,", "This is the description of the blog");
Blog blog2 = new Blog("Second story time",member1,"the story was inspirational for many journalists,", "This is the description of the blog");
Blog blog3 = new Blog("Third and final part in the story time",member1,"the story was inspirational for many journalists,", "This is the description of the blog");

Comment comment1 = new Comment("the first Story Time is great!", member2, blog1); 
Comment comment2 = new Comment("I wanna read more!!", member2, blog1); 

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
Console.WriteLine(blogRepoTester.ReturnByDateRange(new DateTime(2000, 2, 18), new DateTime(2026, 3, 1)));  //Year - Month - Date
//FUNGER IKKE SOM DEN SKAL - FIKS DEN

Console.WriteLine("----------------------------------------------");

Console.WriteLine($"\nEDIT BLOG METODE");
string headline = Console.ReadLine();
string theText = Console.ReadLine();
string description = Console.ReadLine();
blogRepoTester.EditBlog(blog2, headline, theText, description);
Console.WriteLine("Changes made");
blogRepoTester.PrintAllBlog();
Console.WriteLine("----------------------------------------------");

Console.WriteLine($"\nDELTE BLOG METHOD");
blogRepoTester.Delete(blog3);
Console.WriteLine($"Number of blogs: {blogRepoTester.Count}");
Console.WriteLine("----------------------------------------------");


Console.WriteLine($"\nRETURN BLOG BY HEADLINE METHOD"); 
List<Blog> test = blogRepoTester.ReturnBlogHeadline("Story time");
for (int i = 0; i < test.Count; i++)
{
    Console.WriteLine($"Headline: { test[i].Headline}");
}
//foreach (Blog b in test) //hvorfor Blog i stedet for List<Blog>? Fordi...
//{
//    Console.WriteLine(b);
//}
Console.WriteLine("----------------------------------------------");

Console.WriteLine($"\nADD COMMENTS METHOD");
Console.WriteLine("Adding a comment"); //breakpoint her
blogRepoTester.GetBlog(1).AddComment(comment1);
blogRepoTester.GetBlog(1).AddComment(comment2);

Console.WriteLine("printing all comments:");
blogRepoTester.PrintAllComments();
Console.WriteLine("----------------------------------------------");


Console.WriteLine("EDIT COMMENT METHOD");
blogRepoTester.GetBlog(1).EditComment(comment1);


blogRepoTester.PrintAllComments();

Console.WriteLine("----------------------------------------------");

//Console.WriteLine("REMOVE COMMENT METHOD");

//blogRepoTester.RemoveComment(comment1);

//blogRepoTester.PrintAllCommentsOnBlog(blog1);
