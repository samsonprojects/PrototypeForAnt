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
        public RequestScheduleOfNoticeOfLeasesDto GenerateRecievedData()
        {

            var NewLeasesSchedule = new LeasesSchedule()
            {
                ScheduleType = "SCHEDULE OF NOTICES OF LEASES",
                ScheduleEntry = new List<Entries>()
                {
                    new Entries(){
                        EntryNumber = "1",
                        EntryDate = "",
                        EntryType = "Schedule of Notices of Leases",
                        EntryText= new List<string>()
                        {
                            "09.07.2009      Endeavour House, 47 Cuba      06.07.2009      EGL557357  ",
                            "Edged and       Street, London                125 years from             ",
                            "numbered 2 in                                 1.1.2009                   ",
                            "blue (part of)",
                            "NOTE: See entry in the Charges Register relating to a Deed of Rectification dated 26 January 2013"
                        }
                    },
                    new Entries(){
                        EntryNumber = "2",
                        EntryDate = "",
                        EntryType = "Schedule of Notices of Leases",
                        EntryText= new List<string>()
                        {
                            "09.07.2009      Endeavour House, 47 Cuba      06.07.2009      EGL557357  ",
                            "Edged and       Street, London                125 years from             ",
                            "numbered 2 in                                 1.1.2009                   ",
                            "blue (part of)"
                        }
                    },
                    new Entries(){
                        EntryNumber = "3",
                        EntryDate = "",
                        EntryType = "Schedule of Notices of Leases",
                        EntryText= new List<string>()
                        {
                            "22.02.2010      Flat 2308 Landmark West       03.02.2010      EGL568130  ",
                            "Edged and       Tower (twenty third floor     999 years from             ",
                            "numbered 4 in   flat)                         1.1.2009                   ",
                            "blue (part of)                                                           ",
                            "NOTE: See entry in the Charges Register relating to a Deed of Rectification dated 26 January 2018"
                        }
                    },
                    new Entries(){
                        EntryNumber = "4",
                        EntryDate = "",
                        EntryType = "Schedule of Notices of Leases",
                        EntryText= new List<string>()
                        {
                            "20.08.2010      Flat 2401 Landmark West       28.07.2010      EGL575743  ",
                            "Edged and       Tower (twenty fourth floor    999 years from             ",
                            "numbered 4 on   flat)                         1.1.2009                   ",
                            "blue (part of)                                                           ",
                            "NOTE: See entry in the Charges Register relating to a Deed of Variation dated 21 January 2015."
                        }
                    },
                    new Entries(){
                        EntryNumber = "5",
                        EntryDate = "",
                        EntryType = "Schedule of Notices of Leases",
                        EntryText= new List<string>()
                        {
                            "20.08.2010      Flat 1803 Landmark West       08.07.2010      EGL575744  ",
                            "Edged and       Tower (eighteenth floor       999 years from             ",
                            "numbered 4 in   flat)                         1.1.2009                   ",
                            "blue (part of)                                                           ",
                            "NOTE: See entry in the Charges Register relating to a Deed of Variation dated 10 February 2012."
                        }
                    }
                }

                
            };

            var FormedDataObject = new RequestScheduleOfNoticeOfLeasesDto()
                {leasesSchedule = NewLeasesSchedule};

            var Options = new JsonSerializerOptions { WriteIndented = true };
            string jsonResult = JsonSerializer.Serialize(FormedDataObject, Options);
            
            //an automapped LeasesSchedule from the thin Controller
            var DataResult = JsonSerializer.Deserialize<RequestScheduleOfNoticeOfLeasesDto>(jsonResult);
            return DataResult;
            
        }

        public ResponseScheduleOfNoticeOfLeasesDto TransformScheduleOfNoticeOfLeasesData(RequestScheduleOfNoticeOfLeasesDto RequestScheduleOfNoticeOfLeasesDto)
        {
            var responseScheduledOfNoticeLeasesDto = new ResponseScheduleOfNoticeOfLeasesDto();
            responseScheduledOfNoticeLeasesDto.ScheduleType = RequestScheduleOfNoticeOfLeasesDto.leasesSchedule.ScheduleType;
            responseScheduledOfNoticeLeasesDto.ScheduleEntry = TransformReadEntriesToResponseEntriesDto(RequestScheduleOfNoticeOfLeasesDto.leasesSchedule.ScheduleEntry);
            
            return responseScheduledOfNoticeLeasesDto;
        }

         public List<EntryDto> TransformReadEntriesToResponseEntriesDto(List<Entries> RequestEntries)
        {
            var ResultEntryTextDtos = new List<EntryDto>();
            for(int index = 0;index < RequestEntries.Count();index++)
            {
                var CurrentEntryDto = new EntryDto();
                var CurrentRequestEntry = RequestEntries[index];
                CurrentEntryDto.EntryDate = CurrentRequestEntry.EntryDate;
                CurrentEntryDto.EntryNumber = CurrentRequestEntry.EntryNumber;
                CurrentEntryDto.EntryType = CurrentRequestEntry.EntryType;

                CurrentEntryDto.EntryTexts =  MapToEntryTextDto(CurrentRequestEntry.EntryText);
                ResultEntryTextDtos.Add(CurrentEntryDto);

            }

            return ResultEntryTextDtos;

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