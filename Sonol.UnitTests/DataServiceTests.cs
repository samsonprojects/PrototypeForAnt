using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Sonol.Api.Dtos;
using Sonol.Api.Models;
using Sonol.Api.Services;
using Xunit;

namespace Sonol.UnitTests
{
    public class DataServiceTests
    {
        
        [Fact]
        public void DataService_TranformReadEntriesToResponseEntries_ReturnScheduledEntryDto()
        {   
            //Arrange
            var sutDataService = new DataService();
            var data= sutDataService.GenerateRecievedData();

            var sampleEntries = data.leasesSchedule.ScheduleEntry;

            //Act
            var result = sutDataService.TransformReadEntriesToResponseEntriesDto(sampleEntries);
            //var FirstEntryTextDtoResult =result[0];
            
            //Assert
            result.Should().HaveCountGreaterThan(0);

        }

        [Fact]
        public void DataService_TransformScheduleOfNoticeOfLeasesData_ReturnResponseScheduleOfNoticeOfLeasesDto()
        {
            // Arrange
            var sutDataService = new DataService();
            var data = sutDataService.GenerateRecievedData();

            // Act
            var result = sutDataService.TransformScheduleOfNoticeOfLeasesData(data);

            // Assert
            result.Should().BeAssignableTo<ResponseScheduleOfNoticeOfLeasesDto>();
            result.ScheduleEntry.Count().Should().Equals(data.leasesSchedule.ScheduleEntry.Count());
            

        }


        // [Fact]
        // public void DataService_CanQueryLeaseTitle_ReturnCorrectLeaseTitle()
        // {
        //     // Arrange
        //     var sutDataService = new DataService();
        //     var data = sutDataService.GenerateRecievedData();

        //     // Act
        //     var result = sutDataService.TransformScheduleOfNoticeOfLeasesData(data);
        //     //function iterates through collection of ScheduleEntryList
        //     // filter on where EntryTexts.Note matches query

        //     //Assert


        // }


    }
}