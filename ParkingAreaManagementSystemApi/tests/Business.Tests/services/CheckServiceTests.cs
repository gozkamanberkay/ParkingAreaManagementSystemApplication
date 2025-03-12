using Business.Models.Requests;
using Business.Models.Responses;
using Business.Services;
using Core.Constants;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Moq;

namespace Business.Tests.Services;

[TestFixture]
public class CheckServiceTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private CheckService _checkService;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _checkService = new CheckService(_unitOfWorkMock.Object);
    }

    [Test]
    public async Task CheckIn_ShouldReturnSuccess_WhenParkingSpotIsAvailable()
    {
        // Arrange

        // Act

        // Assert
    }

    [Test]
    public async Task CheckIn_ShouldReturnError_WhenVehicleAlreadyCheckedIn()
    {
        // Arrange

        // Act

        // Assert
    }

    [Test]
    public async Task CheckOut_ShouldReturnError_WhenParkingRecordNotFound()
    {
        // Arrange
        const string plateNumber = "NOPLATE";

        var request = new CheckOutRequestDto { PlateNumber = plateNumber };

        _unitOfWorkMock.Setup(unitOfWork => unitOfWork.ParkingRecords.GetByPlateNumberToCheckOutAsync(plateNumber))
            .ReturnsAsync((ParkingRecord?)null);

        // Act
        var result = await _checkService.CheckOut(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Status, Is.EqualTo(ResultStatus.Error));
            Assert.That(result.Message, Is.EqualTo(Messages.NotFound));
        });
    }

    [Test]
    public async Task CheckOut_ShouldReturnSuccess_WhenVehicleExists()
    {
        // Arrange
        var request = new CheckOutRequestDto { PlateNumber = "34MC123" };

        var parkingRecord = new ParkingRecord
        {
            PlateNumber = "34MC123",
            CheckedInAt = DateTime.UtcNow.AddHours(-2),
            Status = ParkingRecordStatusEnum.CheckedIn,
            ParkingSpot = new ParkingSpot { IsOccupied = true },
            HourlyFee = 10
        };

        _unitOfWorkMock.Setup(u => u.ParkingRecords.GetByPlateNumberToCheckOutAsync(request.PlateNumber))
            .ReturnsAsync(parkingRecord);
        _unitOfWorkMock.Setup(u => u.CommitAsync()).Returns(Task.FromResult(1));

        // Act
        var result = await _checkService.CheckOut(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Status, Is.EqualTo(ResultStatus.Ok));
            Assert.That(result.Data!.TotalFee, Is.GreaterThan(0));
        });
    }
}