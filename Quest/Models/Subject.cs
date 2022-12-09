using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Models
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<QuestRoom> questRooms { get; set; }
        public Subject()
        {
            questRooms = new List<QuestRoom>();
        }
    }
}
