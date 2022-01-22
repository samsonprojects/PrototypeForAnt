using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sonol.Api.Models
{
    public class LeasesSchedule
    {
        public string ScheduleType { get; set; }

        public List<Entries> ScheduleEntry { get; set; }
    }
}