using System.Collections.Generic;
using Sonol.Api.Models;

namespace Sonol.Api.Dtos
{
    public class ResponseScheduleOfNoticeOfLeasesDto
    {
        public string ScheduleType{get;set;}
        public List<EntryDto> ScheduleEntry {get;set;}
    }
}