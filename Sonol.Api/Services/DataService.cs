using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sonol.Api.Dtos;
using Sonol.Api.Helpers;
using Sonol.Api.Models;

namespace Sonol.Api.Services
{
    public class DataService :IDataService
    {
        //// This service would be injected into the controller 

        public List<EntryDto> _EntriesRepo {get;set;}
        public List<EntryTextDto> _EntriesTextRepo{get;set;}

        public DataService()
        {
            _EntriesTextRepo = new List<EntryTextDto>();
        }
        public ResponseScheduleOfNoticeOfLeasesDto TransformScheduleOfNoticeOfLeasesData(RequestScheduleOfNoticeOfLeasesDto RequestScheduleOfNoticeOfLeasesDto)
        {
            var responseScheduledOfNoticeLeasesDto = new ResponseScheduleOfNoticeOfLeasesDto();
            responseScheduledOfNoticeLeasesDto.ScheduleType = RequestScheduleOfNoticeOfLeasesDto.leasesSchedule.scheduleType;
            responseScheduledOfNoticeLeasesDto.ScheduleEntry = TransformReadEntriesToResponseEntriesDto(RequestScheduleOfNoticeOfLeasesDto.leasesSchedule.scheduleEntry);
            

            return responseScheduledOfNoticeLeasesDto;
        }

         public List<EntryDto> TransformReadEntriesToResponseEntriesDto(List<Entries> RequestEntries)
        {
            var ResultEntryTextDtos = new List<EntryDto>();
            for(int index = 0;index < RequestEntries.Count();index++)
            {
                var CurrentEntryDto = new EntryDto();
                var CurrentRequestEntry = RequestEntries[index];
                if(CurrentRequestEntry != null)
                {
                    CurrentEntryDto.EntryDate = CurrentRequestEntry.entryDate;
                    CurrentEntryDto.EntryNumber = CurrentRequestEntry.entryNumber;
                    CurrentEntryDto.EntryType = CurrentRequestEntry.entryType;

                    CurrentEntryDto.EntryTexts =  MapToEntryTextDto(CurrentRequestEntry.entryText);
                    ResultEntryTextDtos.Add(CurrentEntryDto);

                    //TODO: Must create a get all entriesdto  method when time permits
                    //Creating a simple entries repo so easier to search
                    //_EntriesRepo.AddRange(ResultEntryTextDtos);
                    _EntriesTextRepo.Add(CurrentEntryDto.EntryTexts);
                }

            }

            return ResultEntryTextDtos;

        }

        public EntryTextDto GetEntryByColumnName(string ColumnName,string Text)
        {
            var EntryTextDtoSearchResult = new EntryTextDto();
            if(ColumnName == "Note")
            {
                EntryTextDtoSearchResult = _EntriesTextRepo
                    .SingleOrDefault(n => !string.IsNullOrEmpty(n.Note) && n.Note.ToLower().Trim() == Text.ToLower().Trim());
                
            }
            else if(ColumnName == "PropertyDescription")
            {
                EntryTextDtoSearchResult = _EntriesTextRepo
                    .SingleOrDefault(n => !string.IsNullOrEmpty(n.PropertyDescription) && n.PropertyDescription.ToLower().Trim() == Text.ToLower().Trim());
            }
            else if(ColumnName == "LeaseTitle")
            {
                EntryTextDtoSearchResult = _EntriesTextRepo
                    .SingleOrDefault(n => !string.IsNullOrEmpty(n.LeaseTitle) && n.LeaseTitle.ToLower().Trim() == Text.ToLower().Trim());
            }
            else if(ColumnName == "DateOfLeaseAndTerm")
            {
                EntryTextDtoSearchResult = _EntriesTextRepo
                    .SingleOrDefault(n => !string.IsNullOrEmpty(n.DateOfLeaseAndTerm) && n.DateOfLeaseAndTerm.ToLower().Trim() == Text.ToLower().Trim());
            }
            //has to be Registration date and plan ref
            else
            {
                EntryTextDtoSearchResult = _EntriesTextRepo
                    .SingleOrDefault(n => !string.IsNullOrEmpty(n.RegistrationDateAndPlanRef) && n.RegistrationDateAndPlanRef.ToLower().Trim() == Text.ToLower().Trim());
            }

            return EntryTextDtoSearchResult;
        } 

        private EntryTextDto MapToEntryTextDto(List<string> EntryText)
        {
            var EntryResults = new EntryTextDto();
            EntryResults.DateOfLeaseAndTerm = EntryText.ReturnDateOfLeaseAndTerm();
            EntryResults.PropertyDescription = EntryText.ReturnPropertyDescription();
            EntryResults.Note = EntryText.ReturnNote();
            EntryResults.RegistrationDateAndPlanRef = EntryText.ReturnRegistrationDateAndPlanRef();
            EntryResults.LeaseTitle = EntryText.ReturnLeaseTitle();
  
            return EntryResults;

        }

        
    }
}