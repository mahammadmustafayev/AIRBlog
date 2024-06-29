﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRTaskBlog.Models;

public class Blog
{

    private static int _id=1;
    public int Id { get; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Hashtag { get; set; }
    
    public Blog(string title,string content,string hashTag)
    {
        this.Id = _id++;
        this.Title = title;
        this.Content = content;
        this.Hashtag = hashTag;
    }
    
}
