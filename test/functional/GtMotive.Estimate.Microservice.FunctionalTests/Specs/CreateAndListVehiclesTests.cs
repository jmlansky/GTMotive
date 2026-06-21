using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    [Collection(TestCollections.Functional)]
    public sealed class CreateAndListVehiclesTests(CompositionRootTestFixture fixture) : FunctionalTestBase(fixture)
    {
        [Fact]
        public async Task CreatedVehicleAppearsInTheAvailableList()
        {
            var licensePlate = $"FUNC-{Guid.NewGuid():N}";

            await Fixture.UsingHandlerForRequestResponse<CreateVehicleRequest, IWebApiPresenter>(async handler =>
            {
                var request = new CreateVehicleRequest
                {
                    Brand = "Toyota",
                    Model = "Corolla",
                    LicensePlate = licensePlate,
                    ManufactureDate = DateTime.UtcNow.AddYears(-1),
                };

                var presenter = await handler.Handle(request, CancellationToken.None);

                presenter.ActionResult.Should().BeOfType<CreatedResult>();
            });

            await Fixture.UsingHandlerForRequestResponse<ListAvailableVehiclesRequest, IWebApiPresenter>(async handler =>
            {
                var presenter = await handler.Handle(new ListAvailableVehiclesRequest(), CancellationToken.None);

                var result = presenter.ActionResult.Should().BeOfType<OkObjectResult>().Subject;
                var response = result.Value.Should().BeOfType<AvailableVehiclesResponse>().Subject;
                response.Vehicles.Should().Contain(vehicle => vehicle.LicensePlate == licensePlate);
            });
        }
    }
}
