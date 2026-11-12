using FitnessApp.Models;
using FitnessApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [ApiController]
    [Route("api/exercises")]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository _repository;

        public ExercisesController(IExerciseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Exercise>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Exercise> GetById(int id)
        {
            var exercise = _repository.GetById(id);

            if (exercise is null)
                return NotFound();

            return Ok(exercise);
        }

        [HttpPost]
        public ActionResult<Exercise> Add([FromBody] Exercise exercise)
        {
            var createdExercise = _repository.Add(exercise);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdExercise.Id },
                createdExercise);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Exercise exercise)
        {
            var updated = _repository.Update(id, exercise);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var deleted = _repository.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}