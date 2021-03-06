using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Sonol.Api.Dtos;
using Sonol.Api.Models;
using Sonol.Api.Services;
using Xunit;

namespace Sonol.UnitTests
{
    //TODO: add Mock IDataService 
    //var DataServiceMock = new Mock<IDataService>()
    //
    public class DataServiceTests
    {
        //Reason for not mocking was due to time constraints, and wanted the test to be as easy as possible
        
        [Fact]
        public void DataService_TranformReadEntriesToResponseEntries_ReturnScheduledEntryDto()
        {   
            //Arrange
            var sutDataService = new DataService();
            var data = new DataFixture().GenerateRequestedData();

            var sampleEntries = data.leasesSchedule.scheduleEntry;

            //Act
            var result = sutDataService.TransformReadEntriesToResponseEntriesDto(sampleEntries);
            
            //Assert
            result.Should().HaveCountGreaterThan(0);

        }

        [Fact]
        public void DataService_TransformScheduleOfNoticeOfLeasesData_ReturnResponseScheduleOfNoticeOfLeasesDto()
        {
            // Arrange
            var sutDataService = new DataService();
            var data = new DataFixture().GenerateRequestedData();

            // Act
            var result = sutDataService.TransformScheduleOfNoticeOfLeasesData(data);

            // Assert
            result.Should().BeAssignableTo<ResponseScheduleOfNoticeOfLeasesDto>();
            result.ScheduleEntry.Count().Should().Be(data.leasesSchedule.scheduleEntry.Count());
            

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