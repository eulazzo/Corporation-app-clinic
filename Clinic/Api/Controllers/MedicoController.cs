

using ClCoreShared.ModelViews.Medico;
using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoManager _doctorManager;

        public MedicosController(IMedicoManager doctorManager)
        {
            this._doctorManager = doctorManager;
        }

        /// <summary> 
        ///     Return all Doctors from Db
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MedicoView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            return Ok(await _doctorManager.GetMedicosAsync());
        }

        /// <summary>
        ///     Return a Doctors by given an id.
        /// </summary>
        /// <param name="Id" example="123-3423-34234-234234">Id of customer has to be an Guid type</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _doctorManager.GetMedicoAsync(id));
        }


        /// <summary>
        ///     Insert a new Doctor on Db
        /// </summary>
        /// <param name="Medico"></param>
        [HttpPost]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoMedico novoMedico)
        {
            var response = await _doctorManager.InsertMedicoAsync(novoMedico);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);

        }


        /// <summary>
        ///   Update a Doctor from Db.
        /// </summary>
        /// <param name="updatedDoctor"></param>
        [HttpPut]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Put(AlteraMedico  updatedDoctor)
        {
            var editedDoctor = await _doctorManager.UpdateMedicoAsync(updatedDoctor);
            if (editedDoctor == null) return NotFound();
            return Ok(editedDoctor);

        }
        /// <summary>
        /// Remove a Doctor from db.
        /// </summary>
        /// <param name="id" example="123"></param>
        /// <remarks>Delete a customer from database permanently</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status204NoContent)]
        [ProducesResponseType( StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _doctorManager.DeleteMedicoAsync(id);
            return NoContent();
        }
    }
}
