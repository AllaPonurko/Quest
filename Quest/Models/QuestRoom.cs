using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Models
{
    public class QuestRoom
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        [Required]
        public int Time { get; set; }
        [Required]
        public string LevelOfFear { get; set; }
        [Required]
        public string DifficultyLevel { get; set; }
        [Required]
        public int NumberOfPlayers { get; set; }
    }
}
