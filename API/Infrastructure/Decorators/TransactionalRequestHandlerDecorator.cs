using DixRacing.Domain.SharedKernel;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Infrastructure.Decorators
{
    public class TransactionalRequestHandlerDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _handler;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionalRequestHandlerDecorator(
            IRequestHandler<TRequest, TResponse> handler,
            IUnitOfWork unitOfWork)
        {
            _handler = handler;
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TResponse response = default!;

            await _unitOfWork.ExecuteInTransactionAsync(async () =>
                response = await _handler.Handle(request, cancellationToken));

            return response;
        }
    }
}
