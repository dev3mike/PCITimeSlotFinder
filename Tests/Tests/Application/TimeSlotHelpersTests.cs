using Application.Helpers;
using Application.Services;
using Domain.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using Tests.Data;

namespace Tests.Application;

public class TimeSlotHelpersTests
{
    [Fact]
    public async Task GenerateTimeKeys_ShouldReturnTimeKeysWith15MinInterval_WhenValidStartEndTimeGiven()
    {
        // Arrange
        var startDateTime = DateTime.Parse("2015-12-14 08:00:00");
        var endDateTime = DateTime.Parse("2015-12-14 09:00:00");

        // Act
        var timeKeys = TimeSlotHelpers.GenerateTimeKeys(startDateTime, endDateTime);

        // Assert
        Assert.Equal(new[] { "0800-0815", "0815-0830", "0830-0845", "0845-0900" }, timeKeys);
    }

    [Fact]
    public async Task GetAvailableTimeSlots_ShouldReturnAvailableTimeSlots_WhenValidInputGiven()
    {
        // Arrange
        var notAvailableTimeSlotsList = new Dictionary<string, int>
        {
            { "1000-1015", 1 }
        };
        const int minNumberOfPersonnel = 2;
        const int numberOfTotalPersonnel = 3;
        var workingDayStartTime = DateTime.Parse("2015-12-14 10:00:00");
        var workingDayEndTime = DateTime.Parse("2015-12-14 10:30:00");

        // Act
        var availableTimeSlots = TimeSlotHelpers.GetAvailableTimeSlots(notAvailableTimeSlotsList, minNumberOfPersonnel,
            numberOfTotalPersonnel, workingDayStartTime, workingDayEndTime);

        // Assert
        Assert.Equal(new[] { "1000-1015", "1015-1030" }, availableTimeSlots);
    }

    [Fact]
    public async Task GetAvailableTimeSlots_ShouldNotReturnAnyTimeSlot_WhenAllOfThePeopleAreBusy()
    {
        // Arrange
        var notAvailableTimeSlotsList = new Dictionary<string, int>
        {
            { "1000-1015", 3 },
            { "1015-1030", 3 }
        };
        const int minNumberOfPersonnel = 2;
        const int numberOfTotalPersonnel = 3;
        var workingDayStartTime = DateTime.Parse("2015-12-14 10:00:00");
        var workingDayEndTime = DateTime.Parse("2015-12-14 10:30:00");

        // Act
        var availableTimeSlots = TimeSlotHelpers.GetAvailableTimeSlots(notAvailableTimeSlotsList, minNumberOfPersonnel,
            numberOfTotalPersonnel, workingDayStartTime, workingDayEndTime);

        // Assert
        Assert.Empty(availableTimeSlots);
    }
}