using System.Collections.Generic;

namespace Sonol.Api.Dtos
{
    public class EntryTextDto
    {
        public string  RegistrationDateAndPlanRef {get;set;}
        public string Note{get;set;}
        public string PropertyDescription{get;set;}
        //TODO: check with Antony if it's not LeaseTitle
        public string LeaseTitle{get;set;}
        public string DateOfLeaseAndTerm{get;set;}


    }
}