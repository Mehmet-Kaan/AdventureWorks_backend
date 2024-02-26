using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks_backend.Services.PersonService
{
    public interface IPersonService
    {
        Task<ServiceResponse<List<GetPersonDto>>> GetAllPersons();
        Task<ServiceResponse<GetPersonDto>> GetPersonById(int id);
        Task<ServiceResponse<List<GetPersonDto>>> AddPerson(AddPersonDTO newPerson);
        Task<ServiceResponse<GetPersonDto>> UpdatePerson(UpdatePersonDto updatedPerson);
        Task<ServiceResponse<List<GetPersonDto>>> DeletePerson(int id);

    }
}