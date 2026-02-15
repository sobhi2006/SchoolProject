using FluentAssertions;
using SchoolProject.Core.Features.Transportation.Queries.Handler;
using SchoolProject.Core.Features.Transportation.Queries.Models;
using System.Net;

namespace Testing.SchoolProject.Core.Tests.Transportation.Queries
{
    public class TransportationQueryHandlerTest
    {
        [Fact]
        public async Task GetRecommendation_VehicleNeededAtDestination_ShortDistance_ReturnsDrive()
        {
            // Arrange — car wash scenario: 100m but car must be there
            var query = new GetTransportationRecommendationQuery
            {
                DistanceInMeters = 100,
                IsVehicleNeededAtDestination = true
            };
            var handler = new TransportationQueryHandler();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.Data.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data!.Recommendation.Should().Be("Drive");
        }

        [Fact]
        public async Task GetRecommendation_VehicleNotNeeded_ShortDistance_ReturnsWalk()
        {
            // Arrange — e.g. going to a nearby store, 100m walk
            var query = new GetTransportationRecommendationQuery
            {
                DistanceInMeters = 100,
                IsVehicleNeededAtDestination = false
            };
            var handler = new TransportationQueryHandler();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.Data.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data!.Recommendation.Should().Be("Walk");
        }

        [Fact]
        public async Task GetRecommendation_VehicleNotNeeded_LongDistance_ReturnsDrive()
        {
            // Arrange — far destination, no vehicle needed but too far to walk
            var query = new GetTransportationRecommendationQuery
            {
                DistanceInMeters = 5000,
                IsVehicleNeededAtDestination = false
            };
            var handler = new TransportationQueryHandler();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.Data.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data!.Recommendation.Should().Be("Drive");
        }

        [Fact]
        public async Task GetRecommendation_VehicleNeeded_LongDistance_ReturnsDrive()
        {
            // Arrange — vehicle needed and far away
            var query = new GetTransportationRecommendationQuery
            {
                DistanceInMeters = 5000,
                IsVehicleNeededAtDestination = true
            };
            var handler = new TransportationQueryHandler();

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            result.Data.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data!.Recommendation.Should().Be("Drive");
        }
    }
}
