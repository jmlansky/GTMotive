using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    public sealed class CreateVehicleUseCaseTests
    {
        private static readonly DateTime UtcNow = new(2026, 6, 1, 0, 0, 0, DateTimeKind.Utc);

        [Fact]
        public async Task ExecuteWithAvailablePlateRegistersVehicleAndEmitsStandardResult()
        {
            var outputPort = new Mock<ICreateVehicleOutputPort>();
            var vehicleRepository = new Mock<IVehicleRepository>();
            vehicleRepository.Setup(r => r.ExistsByLicensePlate(It.IsAny<string>())).ReturnsAsync(false);
            var unitOfWork = new Mock<IUnitOfWork>();
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            dateTimeProvider.Setup(c => c.UtcNow).Returns(UtcNow);

            var useCase = new CreateVehicleUseCase(outputPort.Object, vehicleRepository.Object, unitOfWork.Object, dateTimeProvider.Object);
            var input = new CreateVehicleInput("Toyota", "Corolla", "ABC-123", new ManufactureDate(UtcNow.AddYears(-2)));

            await useCase.Execute(input);

            vehicleRepository.Verify(r => r.Add(It.IsAny<Vehicle>()), Times.Once);
            unitOfWork.Verify(u => u.Save(), Times.Once);
            outputPort.Verify(p => p.StandardHandle(It.IsAny<CreateVehicleOutput>()), Times.Once);
            outputPort.Verify(p => p.LicensePlateAlreadyExistsHandle(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ExecuteWithDuplicatePlateRejectsAndDoesNotPersist()
        {
            var outputPort = new Mock<ICreateVehicleOutputPort>();
            var vehicleRepository = new Mock<IVehicleRepository>();
            vehicleRepository.Setup(r => r.ExistsByLicensePlate(It.IsAny<string>())).ReturnsAsync(true);
            var unitOfWork = new Mock<IUnitOfWork>();
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            dateTimeProvider.Setup(c => c.UtcNow).Returns(UtcNow);

            var useCase = new CreateVehicleUseCase(outputPort.Object, vehicleRepository.Object, unitOfWork.Object, dateTimeProvider.Object);
            var input = new CreateVehicleInput("Toyota", "Corolla", "ABC-123", new ManufactureDate(UtcNow.AddYears(-2)));

            await useCase.Execute(input);

            outputPort.Verify(p => p.LicensePlateAlreadyExistsHandle(It.IsAny<string>()), Times.Once);
            vehicleRepository.Verify(r => r.Add(It.IsAny<Vehicle>()), Times.Never);
            outputPort.Verify(p => p.StandardHandle(It.IsAny<CreateVehicleOutput>()), Times.Never);
        }
    }
}
