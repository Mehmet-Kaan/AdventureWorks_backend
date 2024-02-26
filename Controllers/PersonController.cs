using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks_backend.Controllers
{
    // Controller class for managing persons
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class PersonController : ControllerBase
    {
         // Static list to store persons (dummy data for demonstration)
        private static readonly List<Person> Person = new()
        {
            new Person()
        };
        private readonly IPersonService _personService;

        // Constructor to initialize PersonController with IPersonService dependency
        public PersonController(IPersonService personService) 
        {
            _personService = personService;
        }

        // Endpoint to get all persons
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> Get(){
            return Ok(await _personService.GetAllPersons());
        }

        // Endpoint to get a single person by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPersonDto>>> GetSingle(int id){
            return Ok(await _personService.GetPersonById(id));
        }

        // Endpoint to add a new person
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> AddPerson(AddPersonDTO newPerson){
            return Ok(await _personService.AddPerson(newPerson));
        }

        // Endpoint to update an existing person
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> UpdatePerson(UpdatePersonDto updatedPerson){
            var response = await _personService.UpdatePerson(updatedPerson);
            if(response.Data is null) {
                return NotFound(response);
            }
                return Ok(response);
        }

        // Endpoint to delete a person by ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPersonDto>>> DeletePerson(int id){
            var response = await _personService.DeletePerson(id);
            if(response.Data is null) {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
