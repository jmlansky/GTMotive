using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListRentals
{
    /// <summary>
    /// Request to list every rental.
    /// </summary>
    public sealed class ListRentalsRequest : IRequest<IWebApiPresenter>
    {
    }
}
