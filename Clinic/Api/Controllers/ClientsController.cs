using ClCoreShared.ModelViews;
using ClCoreShared.ModelViews.Cliente;
using Core.Domain;
using Manager.Implementatios;
using Manager.Interfaces;
using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using SerilogTimings;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClienteManager _clientManager;
        private readonly ILogger _logger;

        public ClientsController(IClienteManager clientManager, ILogger<ClientsController> logger)
        {
            this._clientManager = clientManager;
            this._logger=logger;
        }

        /// <summary> 
        ///     Return all Customers from Db
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        //public async Task<ActionResult<ServiceResponse<Client>>> Get()

        {
            var clients = await _clientManager.GetClientsAsync();
            if (clients is not null)
            {
                return Ok(clients);
            }
            return NotFound();
        }

        /// <summary>
        ///     Return a customer by id.
        /// </summary>
        /// <param name="id" example="123">Id of customer has to be an Int type</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {

            var cliente = await _clientManager.GetClientAsync(id);
            if (cliente is null)
                return NotFound();
            return Ok(cliente);
        }


        /// <summary>
        ///     Insert a new Customer on Db
        /// </summary>
        /// <param name="novoClient"></param>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoCliente novoClient)
        {
            _logger.LogInformation($"Objeto recebido {@novoClient}", novoClient);

            ClienteView insertedClient;
            using (Operation.Time("Customer creation time"))
            {
                _logger.LogInformation("A customer insersion was requested!");
                insertedClient = await _clientManager.InsertClientAsync(novoClient);

            };
            return CreatedAtAction(nameof(Get), new { id = insertedClient.Id }, insertedClient);
            //_logger.LogInformation("Request has ended!");

        }


        /// <summary>
        ///   Update a customer from Db.
        /// </summary>
        /// <param name="updatedClient"></param>
        [HttpPut]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Put(AlteraCliente updatedClient)
        {
            var editedClient = await _clientManager.UpdateClientAsync(updatedClient);
            if (editedClient==null) return NotFound();
            return Ok(editedClient);

        }
        /// <summary>
        /// Remove a customer from db.
        /// </summary>
        /// <param name="id" example="123"></param>
        /// <remarks>Delete a customer from database permanently</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteExcliudo = await _clientManager.DeleteClientAsync(id);
            if (clienteExcliudo == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
