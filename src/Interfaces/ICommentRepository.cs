﻿using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using cmsapplication.src.Models;

namespace cmsapplication.src.Interfaces;

public interface ICommentRepository
{
    CommentsReadModel GetCommentById(Guid postId);
    void Insert(Post post, CommentsCreateModel comment);
    void Update(Guid id, CommentUpdateModel comment);
    void Save();
}
