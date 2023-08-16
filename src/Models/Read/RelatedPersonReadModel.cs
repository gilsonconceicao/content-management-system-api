﻿namespace cmsapplication.src.Models.Read; 

public class RelatedPersonReadModel
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<CommentsReadModel>? Comments { get; set; }
    public bool HideLikesNumber { get; set; }
    public bool DisableComments { get; set; }
}
