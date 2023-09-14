using ApiMediator.Domain.Customer.Command;
using ApiMediator.Infra;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiMediator.Controllers
{
    // IMediator uma interface disponilizada pelo mediatR,
    // que disponibiliza o método Send, responsável por enviar nosso comando para a classe que o executará.
    //chama os métodos da classe CustomerHandler com base no objeto passado.

    //Exemplificando: recebemos no método Post o command CustomerCreateCommand,
    //passamos esse objeto para o método Send, que por sua vez,
    //vai procurar alguma classe com herança do IRequestHandler e invocar o método Handler
    //com base no objeto passado, com isso, nosso Send encontra a classe CustomerHandler invocando o método correto.

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IMediator mediator, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CustomerUpdateCommand command)
        {
            var response = _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = new CustomerDeleteCommand { Id = id };
            var result = await _mediator.Send(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _customerRepository.GetById(id);
            return Ok(result);
        }

    }
}
