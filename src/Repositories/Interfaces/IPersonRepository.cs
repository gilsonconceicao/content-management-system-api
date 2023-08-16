﻿using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;

namespace cmsapplication.src.Repositories.Interfaces;

public interface IPersonRepository 
{
    ICollection<PersonReadModel> GetAllPerson();
    Person GetPersonById(Guid Id);
    void Insert(PersonCreateModel person); 
    void Update(Person personToUpdate, PersonUpdateModel post);
    void Delete(Person person); 
    void Save();
}

