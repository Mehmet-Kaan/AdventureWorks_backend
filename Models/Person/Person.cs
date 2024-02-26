using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdventureWorks_backend.Models.Person
{
    public class Person
    {

        [Key]
        public int BusinessEntityID { get; set; }
        public string? PersonType { get; set; } = "ME";
        public bool? NameStyle { get; set; } = false;
        public string? Title { get; set; } = null;
        public string FirstName { get; set; } = "0";
        public string? MiddleName { get; set; } = null;
        public string LastName { get; set; } = "0";
        public string? Suffix { get; set; } = null;
        public int EmailPromotion { get; set; } = 0;
        public string? AdditionalContactInfo { get; set; } = null;
        public string? Demographics { get; set; } = null;
        public Guid Rowguid { get; set; } = Guid.NewGuid();
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

    }
    
}