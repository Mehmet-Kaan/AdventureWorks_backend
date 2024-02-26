using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks_backend.Services.PersonService
{
    // Service class for managing persons
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        // Constructor to initialize PersonService with dependencies
        public PersonService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        // Method to add a new person
        public async Task<ServiceResponse<List<GetPersonDto>>> AddPerson(AddPersonDTO newPerson)
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();

            try
            {
                var person = _mapper.Map<Person>(newPerson);
                _context.Person.Add(person);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await GetAllPersonsInternal();
                serviceResponse.Message = "Person added successfully";
            }
            catch (Exception ex)
            {
                HandleException(serviceResponse, ex);
            }

            return serviceResponse;
        }

        // Method to delete a person by ID
        public async Task<ServiceResponse<List<GetPersonDto>>> DeletePerson(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();

            try
            {
                var person = await _context.Person.FirstOrDefaultAsync(c => c.BusinessEntityID == id);
                if (person == null)
                    throw new Exception($"Person with id '{id}' could not be found");

                _context.Person.Remove(person);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await GetAllPersonsInternal();
                serviceResponse.Message = "Person deleted successfully";
            }
            catch (Exception ex)
            {
                HandleException(serviceResponse, ex);
            }

            return serviceResponse;
        }

        // Method to get all persons
        public async Task<ServiceResponse<List<GetPersonDto>>> GetAllPersons()
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();

            try
            {
                serviceResponse.Data = await GetAllPersonsInternal();
            }
            catch (Exception ex)
            {
                HandleException(serviceResponse, ex);
            }

            return serviceResponse;
        }

        // Method to get a person by ID
        public async Task<ServiceResponse<GetPersonDto>> GetPersonById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();

            try
            {
                var dbPerson = await _context.Person.FirstOrDefaultAsync(c => c.BusinessEntityID == id);
                serviceResponse.Data = _mapper.Map<GetPersonDto>(dbPerson);
            }
            catch (Exception ex)
            {
                HandleException(serviceResponse, ex);
            }

            return serviceResponse;
        }

        // Method to update a person's details
        public async Task<ServiceResponse<GetPersonDto>> UpdatePerson(UpdatePersonDto updatedPerson)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();

            try
            {
                var person = await _context.Person.FirstOrDefaultAsync(c => c.BusinessEntityID == updatedPerson.BusinessEntityID);
                if (person == null)
                    throw new Exception($"Person with id '{updatedPerson.BusinessEntityID}' not found");

                UpdatePersonData(person, updatedPerson);

                _context.Person.Update(person);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetPersonDto>(person);
                serviceResponse.Message = "Person updated successfully";
            }
            catch (Exception ex)
            {
                HandleException(serviceResponse, ex);
            }

            return serviceResponse;
        }

        // Internal method to get all persons from the database
        private async Task<List<GetPersonDto>> GetAllPersonsInternal()
        {
            var dbPersons = await _context.Person.ToListAsync();
            return dbPersons.Select(c => _mapper.Map<GetPersonDto>(c)).ToList();
        }

        // Helper method to handle exceptions
        private void HandleException<T>(ServiceResponse<T> serviceResponse, Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        // Helper method to update person data
        private void UpdatePersonData(Person person, UpdatePersonDto updatedPerson)
        {
            person.Title = updatedPerson.Title;
            person.FirstName = updatedPerson.FirstName;
            person.MiddleName = updatedPerson.MiddleName;
            person.LastName = updatedPerson.LastName;
            person.NameStyle = updatedPerson.NameStyle;
            person.PersonType = updatedPerson.PersonType;
            person.EmailPromotion = updatedPerson.EmailPromotion;
            person.Suffix = updatedPerson.Suffix;
            person.Demographics = updatedPerson.Demographics;
            person.AdditionalContactInfo = updatedPerson.AdditionalContactInfo;
            person.ModifiedDate = DateTime.Now;
        }
    }
}
