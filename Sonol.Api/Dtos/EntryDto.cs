using System.Collections.Generic;
using Sonol.Api.Helpers;

namespace Sonol.Api.Dtos
{
    public class EntryDto
    {

        public string EntryNumber { get; set; }

        public string EntryDate { get; set; }

        public string EntryType { get; set; }

        public EntryTextDto EntryTexts { get; set; }
    }
}