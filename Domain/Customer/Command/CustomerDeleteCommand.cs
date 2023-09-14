using MediatR;

namespace ApiMediator.Domain.Customer.Command
{
    public class CustomerDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
