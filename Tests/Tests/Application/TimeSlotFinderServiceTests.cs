using Application.Services;
using Domain.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using Tests.Data;

namespace Tests.Application;

public class TimeSlotFinderServiceTests
{
    [Theory()]
    [InlineData(1, 8)]
    [InlineData(2, 4)]
    [InlineData(100, 0)]
    public async Task TimeSlotFinderService_ShouldReturnAvailableTimeSlots(int minNumberOfPeople, int numberOfAvailableTimeSlots)
    {
        // Arrange
        var mockScheduleRepository = new Mock<ISchedulesRepository>(MockBehavior.Strict);
        mockScheduleRepository.Setup(i => i.GetAllSchedules()).ReturnsAsync(MockSchedules.MockSchedulesResponse);

        var timeSlotService = new TimeSlotFinderService(mockScheduleRepository.Object);

        // Act
        var availableTimes = await timeSlotService.FindTimeSlots(minNumberOfPeople);

        // Assert
        Assert.Equal(numberOfAvailableTimeSlots, availableTimes.ToList().Count);
    }
}