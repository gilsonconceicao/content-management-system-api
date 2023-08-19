namespace cmsapplication.src.Models.Read; 

public class PersonReadModel
{ 
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }  
    public List<RelatedPersonReadModel> RelatedPosts { get; set; } 
}
