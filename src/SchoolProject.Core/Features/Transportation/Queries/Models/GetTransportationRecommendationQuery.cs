using System.ComponentModel.DataAnnotations;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Transportation.Queries.Results;

namespace SchoolProject.Core.Features.Transportation.Queries.Models;

public class GetTransportationRecommendationQuery : IRequest<Response<TransportationRecommendationResponse>>
{
    [Range(0, int.MaxValue)]
    public int DistanceInMeters { get; set; }
    public bool IsVehicleNeededAtDestination { get; set; }
}
