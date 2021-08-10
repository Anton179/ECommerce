using MediatR;

namespace ECommerce.Core.Application.CommandHandlers.ProductHandlers
{
    public class BaseCreateUpdateProductHandler
    {
        private readonly IMediator _mediator;

        public BaseCreateUpdateProductHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
