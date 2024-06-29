using AIRTaskBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AIRTaskBlog.Utilities;

public static class BlogExtension
{
    public static async Task WriteBlogToJsonFile(this List<Blog> blogs,string filePath)
    {
        var opt = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        using (FileStream stream= File.Create(filePath))
        {
            await JsonSerializer.SerializeAsync(stream, blogs, opt);
        }
        await Console.Out.WriteLineAsync("Blog completely added");
    }
    public static async Task ReadAllBlogFromJsonFile(this string filePath)
    {
        string json= await File.ReadAllTextAsync(filePath);
        List<Blog> blogs= JsonSerializer.Deserialize<List<Blog>>(json);
        foreach (var blog in blogs)
        {
            await Console.Out.WriteLineAsync($"Id:{blog.Id} Baslıq:{blog.Title}");
        }
    }
    public static async Task GetIdBlogFromJsonFile(this string filePath,int id)
    {
        string json = await File.ReadAllTextAsync(filePath);
        List<Blog> blogs = JsonSerializer.Deserialize<List<Blog>>(json);
        Blog blog = blogs.FirstOrDefault(b=>b.Id == id);
        if (blog != null)
        {
            await Console.Out.WriteLineAsync($"ID:{blog.Id}");
            await Console.Out.WriteLineAsync($"Başlıq:{blog.Title}");
            await Console.Out.WriteLineAsync($"Mezmun:{blog.Content}");
            await Console.Out.WriteLineAsync($"Etiketler:{blog.Hashtag}");
        }
        else
        {
            await Console.Out.WriteLineAsync($"ID-si {id} olan data tapilmadi");

        }
    }

    public static async Task SearchWordBlogsFromJsonFile(this string filePath,string searchWord)
    {
        string json = await File.ReadAllTextAsync(filePath);
        List<Blog> blogs = JsonSerializer.Deserialize<List<Blog>>(json);
        var searchBlogs= blogs
                .Where(b => b.Title.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                            b.Content.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                            b.Hashtag.Contains(searchWord, StringComparison.OrdinalIgnoreCase))
                .ToList();

        if (searchBlogs.Any())
        {
            await Console.Out.WriteLineAsync("Axtardiqiniz soze gore Bloglar:");
            foreach (var searchBlog in searchBlogs)
            {
                await Console.Out.WriteLineAsync($"ID:{searchBlog.Id}");
                await Console.Out.WriteLineAsync($"Başlıq:{searchBlog.Title}");
                await Console.Out.WriteLineAsync($"Mezmun:{searchBlog.Content}");
                await Console.Out.WriteLineAsync($"Etiketler:{searchBlog.Hashtag}");
            }
        }
        else
        {
            await Console.Out.WriteLineAsync("Axtardiqiniz soz haqqinda melumat yoxdur.");
        }

    }
    
}
