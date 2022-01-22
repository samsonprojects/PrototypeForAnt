using System.Collections.Generic;
using Sonol.Api.Dtos;
using Sonol.Api.Models;

namespace Sonol.Api.Services
{
    public interface IDataService
    {
         RequestScheduleOfNoticeOfLeasesDto GenerateRecievedData();
         ResponseScheduleOfNoticeOfLeasesDto TransformScheduleOfNoticeOfLeasesData(RequestScheduleOfNoticeOfLeasesDto scheduleOfNoticeOfLeasesDto);

         List<EntryDto> TransformReadEntriesToResponseEntriesDto(List<Entries> RequestEntries);
    }
}