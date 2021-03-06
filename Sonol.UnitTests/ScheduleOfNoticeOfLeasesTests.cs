using System;
using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using Moq;
using Sonol.Api.Dtos;
using Sonol.Api.Models;
using Sonol.Api.Services;
using Xunit;
using Sonol.Api.Helpers;

namespace Sonol.UnitTests
{
    public class ScheduleOfNoticeOfLeasesTests
    {

        [Fact]
        public void DataService_GetAndValidateData_ReturnTrue()
        {
            // Arrange
            var sutDataService = new DataService();
            var scheduleTypeName = "SCHEDULE OF NOTICES OF LEASES".ToLower();
            
            // Act
            var sutDataServiceResult = new DataFixture().GenerateRequestedData();
            sutDataServiceResult.Should().NotBeNull();
            // Assert
            
            sutDataServiceResult.leasesSchedule.scheduleType.ToLower().Should().Be(scheduleTypeName,"because they have the same values");
            sutDataServiceResult.leasesSchedule.scheduleEntry.Should().HaveCountGreaterThan(0);
            
        }

        [Fact]
        public void DataService_TransformDtoToRequest_ReturnResponseDto()
        {
            // Arrange
            var sutDataService = new DataService();
            var sutDataServiceResult = new DataFixture().GenerateRequestedData();
            
        
            // Act
            var sutResponseData= sutDataService.TransformScheduleOfNoticeOfLeasesData(sutDataServiceResult);
        
            // Assert
            //sutResponseData.ScheduleEntry.EntryTexts[0].LeaseTitle.Should().BeEquivalentTo("EGL557357");
        }




    }

    
}
