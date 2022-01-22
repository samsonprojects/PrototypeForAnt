using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sonol.Api.Models
{
    public class Entries
    {

        public string EntryNumber { get; set; }

        public string EntryDate { get; set; }

        public string EntryType { get; set; }

        public List<string> EntryText { get; set; }
    }


}