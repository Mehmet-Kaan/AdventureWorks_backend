using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks_backend.Dtos.Person
{
    public class UpdatePersonDto
    {
        public int BusinessEntityID { get; set; }
        public string? PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string? Title { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Suffix { get; set; }
        public int EmailPromotion { get; set; }
        public string? AdditionalContactInfo { get; set; }
        // public string? Demographics { get; set; } = "<IndividualSurvey xmlns='http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/IndividualSurvey'><TotalPurchaseYTD>0</TotalPurchaseYTD></IndividualSurvey>";
        public string? Demographics { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}