using AIRTaskBlog.Models;
using AIRTaskBlog;
using AIRTaskBlog.Utilities;
using System.Text.Json;
namespace AIRTaskBlog;

class Program
{
    static async Task Main(string[] args)
    {
        var directory = Environment.CurrentDirectory;
        string path = Path.Combine(Directory.GetParent(directory).Parent.Parent.FullName, "SolutionItems", "BlogData.json");

        //List<Blog> blogList = new List<Blog>();
        List<Blog> blogList = await path.ReadBlogsFromJsonFile();

       
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
                    //Blog blog = new Blog(title,content,hashTag);
                    Blog blog = new Blog
                    {
                        Id=NextId(blogList),
                        Title = title,
                        Content = content,
                        Hashtag = hashTag
                    };
                    string data= await File.ReadAllTextAsync(path);
                    blogList = JsonSerializer.Deserialize<List<Blog>>(data);
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
    static int NextId(List<Blog> blogs)
    {
        if(blogs.Count == 0) return 1;

        int maxId = 0;
        foreach (var blog in blogs)
            if (blog.Id > maxId) maxId = blog.Id;
        
        return ++maxId;
    }

}