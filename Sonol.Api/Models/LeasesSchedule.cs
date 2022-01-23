using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sonol.Api.Models
{
    public class LeasesSchedule
    {
        public string scheduleType { get; set; }

        public List<Entries> scheduleEntry { get; set; }
    }

    public class Root
    {
        public LeasesSchedule leaseschedule { get; set; }
    }


}