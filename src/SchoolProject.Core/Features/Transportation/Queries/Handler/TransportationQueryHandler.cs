using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Transportation.Queries.Models;
using SchoolProject.Core.Features.Transportation.Queries.Results;

namespace SchoolProject.Core.Features.Transportation.Queries.Handler;

public class TransportationQueryHandler : ResponseHandler,
    IRequestHandler<GetTransportationRecommendationQuery, Response<TransportationRecommendationResponse>>
{
    private const int WalkingDistanceThresholdMeters = 1000;

    public Task<Response<TransportationRecommendationResponse>> Handle(
        GetTransportationRecommendationQuery request,
        CancellationToken cancellationToken)
    {
        var response = new TransportationRecommendationResponse();

        if (request.IsVehicleNeededAtDestination)
        {
            response.Recommendation = "Drive";
            response.Reason = "The vehicle itself is needed at the destination, so you must drive regardless of distance.";
        }
        else if (request.DistanceInMeters > WalkingDistanceThresholdMeters)
        {
            response.Recommendation = "Drive";
            response.Reason = $"The distance is {request.DistanceInMeters} meters, which is over {WalkingDistanceThresholdMeters / 1000} km. Driving is recommended.";
        }
        else
        {
            response.Recommendation = "Walk";
            response.Reason = $"The distance is only {request.DistanceInMeters} meters and the vehicle is not needed at the destination. Walking is recommended.";
        }

        return Task.FromResult(Success(response));
    }
}
