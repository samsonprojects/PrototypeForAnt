using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sonol.Api.Models
{
    public class Entries
    {

        public string entryNumber { get; set; }

        public string entryDate { get; set; }

        public string entryType { get; set; }

        public List<string> entryText { get; set; }
    }


}