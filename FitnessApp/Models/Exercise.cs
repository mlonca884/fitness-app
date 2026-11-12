using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string MuscleGroup { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}