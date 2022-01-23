using System.Collections.Generic;
using System.Text.Json;
using Sonol.Api.Dtos;
using Sonol.Api.Models;

namespace Sonol.UnitTests
{
    public class DataFixture
    {
        public RequestScheduleOfNoticeOfLeasesDto GenerateRequestedData()
        {

            var NewLeasesSchedule = new LeasesSchedule()
            {
                scheduleType = "SCHEDULE OF NOTICES OF LEASES",
                scheduleEntry = new List<Entries>()
                {
                    new Entries(){
                        entryNumber = "1",
                        entryDate = "",
                        entryType = "Schedule of Notices of Leases",
                        entryText= new List<string>()
                        {
                            "09.07.2009      Endeavour House, 47 Cuba      06.07.2009      EGL557357  ",
                            "Edged and       Street, London                125 years from             ",
                            "numbered 2 in                                 1.1.2009                   ",
                            "blue (part of)",
                            "NOTE: See entry in the Charges Register relating to a Deed of Rectification dated 26 January 2013"
                        }
                    },
                    new Entries(){
                        entryNumber = "2",
                        entryDate = "",
                        entryType = "Schedule of Notices of Leases",
                        entryText= new List<string>()
                        {
                            "09.07.2009      Endeavour House, 47 Cuba      06.07.2009      EGL557357  ",
                            "Edged and       Street, London                125 years from             ",
                            "numbered 2 in                                 1.1.2009                   ",
                            "blue (part of)"
                        }
                    },
                    new Entries(){
                        entryNumber = "3",
                        entryDate = "",
                        entryType = "Schedule of Notices of Leases",
                        entryText= new List<string>()
                        {
                            "22.02.2010      Flat 2308 Landmark West       03.02.2010      EGL568130  ",
                            "Edged and       Tower (twenty third floor     999 years from             ",
                            "numbered 4 in   flat)                         1.1.2009                   ",
                            "blue (part of)                                                           ",
                            "NOTE: See entry in the Charges Register relating to a Deed of Rectification dated 26 January 2018"
                        }
                    },
                    new Entries(){
                        entryNumber = "4",
                        entryDate = "",
                        entryType = "Schedule of Notices of Leases",
                        entryText= new List<string>()
                        {
                            "20.08.2010      Flat 2401 Landmark West       28.07.2010      EGL575743  ",
                            "Edged and       Tower (twenty fourth floor    999 years from             ",
                            "numbered 4 on   flat)                         1.1.2009                   ",
                            "blue (part of)                                                           ",
                            "NOTE: See entry in the Charges Register relating to a Deed of Variation dated 21 January 2015."
                        }
                    },
                    new Entries(){
                        entryNumber = "5",
                        entryDate = "",
                        entryType = "Schedule of Notices of Leases",
                        entryText= new List<string>()
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
                return FormedDataObject;
            
        }
    }
}