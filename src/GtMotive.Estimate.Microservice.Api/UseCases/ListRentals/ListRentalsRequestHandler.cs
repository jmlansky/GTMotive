using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListRentals;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ListRentals
{
    public sealed class ListRentalsRequestHandler(IListRentalsUseCase useCase, ListRentalsPresenter presenter) : IRequestHandler<ListRentalsRequest, IWebApiPresenter>
    {
        private readonly IListRentalsUseCase _useCase = useCase;
        private readonly ListRentalsPresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(ListRentalsRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new ListRentalsInput());

            return _presenter;
        }
    }
}
