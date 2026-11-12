using FitnessApp.Models;

namespace FitnessApp.Repositories
{
    public interface IExerciseRepository
    {
        List<Exercise> GetAll();
        Exercise? GetById(int id);
        Exercise Add(Exercise exercise);
        bool Update(int id, Exercise exercise);
        bool Delete(int id);
    }
}
