using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks_backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, GetPersonDto>();
            CreateMap<AddPersonDTO, Person>();
        }
    }
}