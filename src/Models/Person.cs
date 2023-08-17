﻿using cmsapplication.src.Models.Read;
using System.ComponentModel.DataAnnotations;

namespace cmsapplication.src.Models;

public class Person
{ 
    public Guid Id {get; set;}  
    public string Name { get; set; } 
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }  
    public List<Post> RelatedPosts { get; set; } = new List<Post>();
}
