using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    [Collection(TestCollections.TestServer)]
    public sealed class VehiclesEndpointTests(GenericInfrastructureTestServerFixture fixture) : InfrastructureTestBase(fixture)
    {
        [Fact]
        public async Task CreateVehicleWithMissingRequiredBrandReturnsBadRequest()
        {
            using var client = Fixture.Server.CreateClient();

            // Brand is intentionally omitted to trigger model validation.
            var payload = new
            {
                model = "Corolla",
                licensePlate = "INFRA-1",
                manufactureDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            };

            using var response = await client.PostAsJsonAsync(new Uri("/api/vehicles", UriKind.Relative), payload);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
