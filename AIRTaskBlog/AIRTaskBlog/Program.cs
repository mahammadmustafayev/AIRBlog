using AIRTaskBlog.Models;
using AIRTaskBlog;
using AIRTaskBlog.Utilities;
namespace AIRTaskBlog;

class Program
{
    static async Task Main(string[] args)
    {
        var directory = Environment.CurrentDirectory;
        string path = Path.Combine(Directory.GetParent(directory).Parent.Parent.FullName, "SolutionItems", "BlogData.json");

        List<Blog> blogList = new List<Blog>();

        //Blog blog1 = new Blog("Test", "qwerty", "#twitter");
        //Blog blog2 = new Blog("Deneme", "asdfg", "#insta");
        //Blog blog3 = new Blog("Dene", "gfh", "#olk");
        //blogList.Add(blog1);
        //blogList.Add(blog2);
        //blogList.Add(blog3);

        //await blogList.WriteBlogToJsonFile(path);

        //await path.ReadAllBlogFromJsonFile();

        // await path.GetIdBlogFromJsonFile(1);
        // await path.SearchWordBlogsFromJsonFile("OLK");
        await Console.Out.WriteLineAsync("Xos Gelmisiniz!");
        await Console.Out.WriteLineAsync("Secim Edin!");
        await Console.Out.WriteLineAsync(new string('-',15));
        int choise;
        do
        {
            await Console.Out.WriteLineAsync(new string('-',15));
            await Console.Out.WriteLineAsync("1-Bloglar");
            await Console.Out.WriteLineAsync("2-Blog yazin");
            await Console.Out.WriteLineAsync("3-Blog nomresi ile axtarin");
            await Console.Out.WriteLineAsync("4-Axtaris");
            await Console.Out.WriteLineAsync("5-Cixis");
            await Console.Out.WriteLineAsync(new string('-', 15));
            choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    await Console.Out.WriteLineAsync(new string('-', 15));
                    await path.ReadAllBlogFromJsonFile();
                    break;
                case 2:
                    await Console.Out.WriteLineAsync(new string('-', 15));
                    await Console.Out.WriteLineAsync("Basliq daxil edin.");
                    string title= Console.ReadLine();
                    await Console.Out.WriteLineAsync("Mezmun daxil edin.");
                    string content=Console.ReadLine();
                    await Console.Out.WriteLineAsync("Tag daxil edin.");
                    string hashTag=Console.ReadLine();
                    Blog blog = new Blog(title,content,hashTag);
                    blogList.Add(blog);
                    await blogList.WriteBlogToJsonFile(path);
                    break;
                case 3:
                    await Console.Out.WriteLineAsync(new string('-', 15));
                    await Console.Out.WriteLineAsync("Blog nomresi daxil edin.");
                    int number=Convert.ToInt32(Console.ReadLine());
                    await path.GetIdBlogFromJsonFile(number);
                    break;
                case 4:
                    await Console.Out.WriteLineAsync(new string('-', 15));
                    await Console.Out.WriteLineAsync("Soz daxil edin.");
                    string searchWord=Console.ReadLine();
                    await path.SearchWordBlogsFromJsonFile(searchWord);
                    break;
                case 5:
                    await Console.Out.WriteLineAsync(new string('-', 15));
                    await Console.Out.WriteLineAsync("Saqolun!!!");
                    break;
                default:
                    await Console.Out.WriteLineAsync("Bele bir secim yoxdur!");
                    break;
            }
        } while (choise!=5);
    }
    
}