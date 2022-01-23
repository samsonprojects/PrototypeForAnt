using FluentAssertions;
using Sonol.Api.Helpers;
using Sonol.Api.Services;
using Xunit;

namespace Sonol.UnitTests
{
    public class EntryTextExtensionsTests
    {
        [Fact]
        public void EntryTextExtension_MapRegistrationDateAndPlanRef_ReturnNonNullObject()
        {

             // Arrange
            var sutDataService = new DataService();
            var sutDataServiceResult = new DataFixture().GenerateRequestedData();
            
            // Act
            var result = sutDataServiceResult.leasesSchedule.scheduleEntry[0].entryText.ReturnRegistrationDateAndPlanRef();

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Trim().Should().BeEquivalentTo("09.07.2009 Edged and");
        }

        [Fact]
        public void EntryTextExtension_MapNote_ReturnNonNullString()
        {
             // Arrange
            var sutDataService = new DataService();
            var sutDataServiceResult = new DataFixture().GenerateRequestedData();
            
            // Act
            var result = sutDataServiceResult.leasesSchedule.scheduleEntry[0].entryText.ReturnNote();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();

        }

        [Fact]
        public void EntryTextExtension_MapPropertyDescription_NonNullString()
        {
             // Arrange
            var sutDataService = new DataService();
            var sutDataServiceResult = new DataFixture().GenerateRequestedData();
            
            // Act
            var result = sutDataServiceResult.leasesSchedule.scheduleEntry[0].entryText.ReturnPropertyDescription();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
           public void EntryTextExtension_MapPropertyLeaseTitle_ReturnValidStringResult()
        {
             // Arrange
            var sutDataService = new DataService();
            var sutDataServiceResult = new DataFixture().GenerateRequestedData();
            
            // Act
            var result = sutDataServiceResult.leasesSchedule.scheduleEntry[0].entryText.ReturnLeaseTitle();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.ToLower().Should().BeEquivalentTo("EGL557357".ToLower());
        }

        [Fact]
           public void EntryTextExtension_MapDateOfLeaseAndTerm_ReturnValidStringResult()
        {
             // Arrange
            var sutDataService = new DataService();
            var sutDataServiceResult = new DataFixture().GenerateRequestedData();
            
            // Act
            var result = sutDataServiceResult.leasesSchedule.scheduleEntry[0].entryText.ReturnDateOfLeaseAndTerm();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.ToLower().Trim().Should().Contain("06.07.2009 125 years from".ToLower().Trim());
        }


    }
}