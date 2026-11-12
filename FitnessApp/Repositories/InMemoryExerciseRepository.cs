using FitnessApp.Models;

namespace FitnessApp.Repositories
{
    public class InMemoryExerciseRepository : IExerciseRepository
    {

        private readonly List<Exercise> _exercises = new()
        {
            new Exercise
            {
                Id = 1,
                Name = "Čučanj",
                MuscleGroup = "Noge",
                Description = "Čučanj s vlastitom težinom."
            },
            new Exercise
            {
                Id = 2,
                Name = "Sklek",
                MuscleGroup = "Prsa",
                Description = "Sklek na podu."
            }
        };

        private int _nextId = 3;

        public List<Exercise> GetAll()
        {
            return _exercises;
        }

        public Exercise? GetById(int id)
        {
            return _exercises.FirstOrDefault(exercise => exercise.Id == id);
        }       

        public Exercise Add(Exercise exercise)
        {
            exercise.Id = _nextId++;
            _exercises.Add(exercise);

            return exercise;
        }

        public bool Update(int id, Exercise exercise)
        {
            var existingExercise = GetById(id);

            if (existingExercise is null)
                return false;

            existingExercise.Name = exercise.Name;
            existingExercise.MuscleGroup = exercise.MuscleGroup;
            existingExercise.Description = exercise.Description;

            return true;
        }

        public bool Delete(int id)
        {
            var existingExercise = GetById(id);

            if (existingExercise is null)
                return false;

            _exercises.Remove(existingExercise);

            return true;
        }

    }
}
