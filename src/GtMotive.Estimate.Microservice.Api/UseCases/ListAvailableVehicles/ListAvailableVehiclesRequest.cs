using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Request to list the vehicles available to rent.
    /// </summary>
    public sealed class ListAvailableVehiclesRequest : IRequest<IWebApiPresenter>
    {
    }
}
