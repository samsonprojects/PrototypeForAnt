using System.Collections.Generic;
using Sonol.Api.Dtos;
using Sonol.Api.Models;

namespace Sonol.Api.Services
{
    public interface IDataService
    {
         List<EntryDto> _EntriesRepo {get;set;}
         List<EntryTextDto> _EntriesTextRepo{get;set;}
         ResponseScheduleOfNoticeOfLeasesDto TransformScheduleOfNoticeOfLeasesData(RequestScheduleOfNoticeOfLeasesDto scheduleOfNoticeOfLeasesDto);

         List<EntryDto> TransformReadEntriesToResponseEntriesDto(List<Entries> RequestEntries);
         EntryTextDto GetEntryByColumnName(string ColumnName,string Text);
    }
}